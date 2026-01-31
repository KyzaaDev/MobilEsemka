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
        public Koneksi konek = new Koneksi();

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
            this.Close();
        }

        private void LoadCBPelanggan()
        {
            string query = "SELECT id_pelanggan, nama FROM Pelanggan";
            try
            {
                SqlCommand cmd = new SqlCommand(query, konek.conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cbPelanggan.DataSource = dt;
                cbPelanggan.DisplayMember = "nama";
                cbPelanggan.ValueMember = "id_pelanggan";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadDataMotor()
        {
            txtNamaMotor.Text = NamaMotor;
            txtNoMotor.Text = NoMotor;
            txtHargaSewa.Text = Harga.ToString("N0");
        }
        private void Sewa_Load(object sender, EventArgs e)
        {
            konek.Open();
            LoadDataMotor();
            LoadCBPelanggan();
        }

        private void txtLama_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void txtLama_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtLama.Text, out int lamaSewa))
            {
                decimal totalHarga = Harga * lamaSewa;
                txtTotal.Text = totalHarga.ToString("N0");
            }
            else
            {
                txtTotal.Text = "0";
            }
        }

        private bool ValidateInput()
        {
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

            if (!ValidateInput())
            {
                return;
            }
            else
            {
                string query = "INSERT INTO transaksi (id_pelanggan, id_user, id_motor, tgl_sewa, lama, total_harga, jaminan, jatuh_tempo) VALUES (@id_pelanggan, @id_user, @id_motor, @tgl_sewa, @lama, @total_harga, @jaminan, @jatuh_tempo)";

                int idPelanggan = (int)cbPelanggan.SelectedValue;
                int idMotor = IdMotor;
                int idUser = Session.idUser;
                decimal totalHarga = Harga * int.Parse(txtLama.Text);
                var kembaliDate = dtpSewa.Value.AddDays(int.Parse(txtLama.Text));

                // binding parameters and query untuk sewa motor
                SqlCommand cmdInsert = new SqlCommand(query, konek.conn);
                cmdInsert.Parameters.AddWithValue("@id_pelanggan", idPelanggan);
                cmdInsert.Parameters.AddWithValue("@id_user", idUser);
                cmdInsert.Parameters.AddWithValue("@id_motor", idMotor);
                cmdInsert.Parameters.AddWithValue("@tgl_sewa", dtpSewa.Value);
                cmdInsert.Parameters.AddWithValue("@lama", int.Parse(txtLama.Text));
                cmdInsert.Parameters.AddWithValue("@total_harga", totalHarga);
                cmdInsert.Parameters.AddWithValue("@jaminan", txtJaminan.Text);
                cmdInsert.Parameters.AddWithValue("@jatuh_tempo", kembaliDate.AddDays(1));

                //execute
                cmdInsert.ExecuteNonQuery();
                MessageBox.Show("Data Berhasil Disimpan!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                SqlCommand cmdUpdate = new SqlCommand("UPDATE motor SET status = 'Disewa' WHERE id_motor = @id_motor", konek.conn);
                cmdUpdate.Parameters.AddWithValue("@id_motor", idMotor);
                cmdUpdate.ExecuteNonQuery();

            }
        }
    }
}
