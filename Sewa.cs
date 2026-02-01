using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MobilEsemka
{
    public partial class Sewa : Form
    {
        // koneksi database
        public Koneksi konek = new Koneksi();

        // properti untuk menyimpan data motor yang akan disewa
        // datanya dikirim dari form daftarsewa
        // berdasarkan data motor yang disewa
        public int IdMotor { get; set; }
        public string NamaMotor { get; set; }
        public string NoMotor { get; set; }
        public string Jenis { get; set; }
        public decimal Harga { get; set; }
        public string Status { get; set; }
        public Sewa()
        {
            InitializeComponent();
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            // tutup form
            this.Close();
        }

        // method buat ngeload data pelanggan ke combobox
        private void LoadCBPelanggan()
        {
            // ambil id_pelanggan dan nama dari tabel pelanggan
            string query = "SELECT id_pelanggan, nama FROM Pelanggan";

            try
            {
                SqlCommand cmd = new SqlCommand(query, konek.conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);
                cbPelanggan.DataSource = dt;
                cbPelanggan.DisplayMember = "nama"; // yang ditampilkan di combobox nama pelanggan
                cbPelanggan.ValueMember = "id_pelanggan"; // yang disimpan di value adalah id_pelanggan
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // ngeload data motor ke textbox
        // datanya dari properti yang diisi dari form DaftarSewa
        private void LoadDataMotor()
        {
            txtNamaMotor.Text = NamaMotor;
            txtNoMotor.Text = NoMotor;
            txtHargaSewa.Text = Harga.ToString("N0"); // format angka dengan pemisah ribuan
        }
        private void Sewa_Load(object sender, EventArgs e)
        {
            // buka koneksi
            konek.Open();
            // load data motor
            LoadDataMotor();
            // load data pelanggan ke combobox
            LoadCBPelanggan();
        }

        private void txtLama_KeyPress(object sender, KeyPressEventArgs e)
        {
            // hanya mengizinkan input angka saja
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void txtLama_TextChanged(object sender, EventArgs e)
        {
            // hitung total harga sewa
            // input dari txtLama di parse ke int
            // kalo berhasil, input masuk ke lamaSewa
            // baru hitung total harga dikali dengan lamaSewa
            if (int.TryParse(txtLama.Text, out int lamaSewa))
            {
                // hitung total harga
                decimal totalHarga = Harga * lamaSewa; // properti harga dapet value dari form DaftarSewa
                txtTotal.Text = totalHarga.ToString("N0"); // format angka dengan pemisah ribuan
            }

            // kalo input ga valid, total harga di set ke 0
            else
            {
                txtTotal.Text = "0";
            }
        }

        // method buat validasi input lagi
        private bool ValidateInput()
        {
            epSewa.Clear();
            if (string.IsNullOrWhiteSpace(txtLama.Text))
            {
                epSewa.SetError(txtLama, "Lama sewa harus diisi!");
                return false;
            }
            if (!int.TryParse(txtLama.Text, out _))
            {
                epSewa.SetError(txtLama, "Lama sewa harus berisi angka!");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtJaminan.Text))
            {
                epSewa.SetError(txtJaminan, "Jaminan harus diisi!");
                return false;
            }

            return true;
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            // validasi input
            if (!ValidateInput())
            {
                return;
            }
            else
            {
                SqlTransaction transaction = konek.conn.BeginTransaction();
                try
                {
                    // query insert data ke tabel transaksi
                    string query = "INSERT INTO transaksi (id_pelanggan, id_user, id_motor, tgl_sewa, lama, total_harga, jaminan, jatuh_tempo) VALUES (@id_pelanggan, @id_user, @id_motor, @tgl_sewa, @lama, @total_harga, @jaminan, @jatuh_tempo)";

                    int idPelanggan = (int)cbPelanggan.SelectedValue; // ambil value id_pelanggan dari combobox
                    int idMotor = IdMotor; // id motor dari properti, yang diisi dari form DaftarSewa
                    int idUser = Session.idUser; // id user dari sess login
                    decimal totalHarga = Harga * int.Parse(txtLama.Text); // total harga = harga motor * lama sewa
                    var jatuhTempo = dtpSewa.Value.AddDays(int.Parse(txtLama.Text)); // tanggal kembali = tanggal sewa + lama sewa

                    // tanggal kembali nanti keisi pas motor udah dikembalikan, ini cuma buat ngitung jatuh tempo doang
                    // jadi di insert ke db nya null

                    // binding parameters and query untuk sewa motor
                    SqlCommand cmdInsert = new SqlCommand(query, konek.conn, transaction);
                    cmdInsert.Parameters.AddWithValue("@id_pelanggan", idPelanggan); // dari combobox
                    cmdInsert.Parameters.AddWithValue("@id_user", idUser); // dari session login
                    cmdInsert.Parameters.AddWithValue("@id_motor", idMotor); // dari properti, yang diisi dari form DaftarSewa
                    cmdInsert.Parameters.AddWithValue("@tgl_sewa", dtpSewa.Value); // dari date time picker, ambil value nya
                    cmdInsert.Parameters.AddWithValue("@lama", int.Parse(txtLama.Text)); // dari inputan lama sewa, terus parse ke int
                    cmdInsert.Parameters.AddWithValue("@total_harga", totalHarga); // dari perhitungan tadi
                    cmdInsert.Parameters.AddWithValue("@jaminan", txtJaminan.Text); // dari inputan jaminan
                    cmdInsert.Parameters.AddWithValue("@jatuh_tempo", jatuhTempo); // jatuh tempo = lama sewa + 1 hari

                    //execute insert
                    cmdInsert.ExecuteNonQuery();

                    // update status motor jadi "Disewa" di tabel motor
                    SqlCommand cmdUpdate = new SqlCommand("UPDATE motor SET status = 'Disewa' WHERE id_motor = @id_motor", konek.conn, transaction);
                    cmdUpdate.Parameters.AddWithValue("@id_motor", idMotor); // binding dari properti IdMotor
                    cmdUpdate.ExecuteNonQuery(); // jalanin update

                    transaction.Commit(); // commit transaksi kalo semua berhasil

                    // info berhasil
                    MessageBox.Show("Data Berhasil Disimpan!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    transaction.Rollback(); // kalo error, rollback
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }
    }
}
