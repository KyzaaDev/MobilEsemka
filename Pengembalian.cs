using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace MobilEsemka
{
    public partial class Pengembalian : Form
    {

        // bikin object koneksi
        public Koneksi konek = new Koneksi();
        public Pengembalian()
        {
            InitializeComponent();
        }

        // method buat load data ke datagridview
        private void LoadData()
        {
            // ngambil data yang diperlukan aja bang
            string query = @"SELECT m.id_motor, t.id_transaksi, p.nama, m.nama_motor, m.no_motor, m.jenis,
                            t.tgl_sewa, t.tgl_kembali
                     FROM motor m
                     JOIN transaksi t ON m.id_motor = t.id_motor
                     JOIN pelanggan p ON p.id_pelanggan = t.id_pelanggan
                     WHERE p.nama LIKE @keyword OR t.id_pelanggan LIKE @keyword";

            // seperti biasa, siapin command, data adapter, dan datatable
            SqlCommand cmd = new SqlCommand(query, konek.conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            // bind parameter keyword
            cmd.Parameters.AddWithValue("@keyword", "%" + txtKey.Text + "%");
            da.Fill(dt);

            dgvMotor.DataSource = dt;

            // sembunyiin kolom id_transaksi yang nanti mau dipake buat update 
            dgvMotor.Columns["id_transaksi"].Visible = false;
            dgvMotor.Columns["id_motor"].Visible = false;
        }


        private void txtKey_TextChanged(object sender, EventArgs e)
        {
            // kalo textboxnya dikosongin, datagridview dibersihin
            if (string.IsNullOrWhiteSpace(txtKey.Text))
            {
                // DataSource di set ke null biar bersih
                dgvMotor.DataSource = null;
                // sembunyiin kolom tombol kembalikan
                dgvMotor.Columns["Kembalikan"].Visible = false;
                return;
            }
            LoadData(); // load data setiap teks di textbox berubah
            dgvMotor.Columns["Kembalikan"].Visible = true; // nampilin kolom kembalikan
        }

       
        private void Pengembalian_Load(object sender, EventArgs e)
        {
            konek.Open(); // buka koneksi
            lblUsername.Text = " " + Session.Username; // nampilin username session
            lblTgl.Text = DateTime.Now.ToString("d MMMM yyyy", new CultureInfo("id-ID")); // nampilin tanggal hari ini


            DataGridViewButtonColumn kemCell = new DataGridViewButtonColumn();
            kemCell.Name = "Kembalikan";
            kemCell.Text = "Kembalikan";
            kemCell.HeaderText = "Kembalikan";
            kemCell.UseColumnTextForButtonValue = true;
            dgvMotor.Columns.Add(kemCell);

            dgvMotor.Columns["Kembalikan"].Visible = false; // sembunyiin kolom kembalikan


        }

        private void btnSewa_Click(object sender, EventArgs e)
        {
            new DaftarSewa().Show();
            this.Hide();
        }

        private void btnSewaBr_Click(object sender, EventArgs e)
        {
            new DaftarSewa().Show();
            this.Hide();
        }

        private void dgvMotor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // cek kalo yang di klik itu colom kembalikan
            // dan yang di klik itu baris data, bukan header
            if (dgvMotor.Columns[e.ColumnIndex].Name == "Kembalikan" && e.RowIndex >= 0)
            {
                // konfirmasi pengembalian
                // kalo user klik yes, lanjut
                DialogResult balik = MessageBox.Show("Yakin ingin kembalikan motor?", "Konfirmasi pengembalian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // kalo user klik yes
                if (balik == DialogResult.Yes)
                {
                    DataGridViewRow row = dgvMotor.Rows[e.RowIndex];
                    SqlTransaction trans = konek.conn.BeginTransaction();
                    try
                    {
                        //update status motor disewa
                        // update motor dengan identifier no_motor yang disewa
                        string queryUpdateMotor = "UPDATE motor SET status = 'Aktif' WHERE id_motor = @id_motor; ";
                        SqlCommand cmdUpdateMotor = new SqlCommand(queryUpdateMotor, konek.conn, trans);
                        cmdUpdateMotor.Parameters.AddWithValue("@id_motor", row.Cells["id_motor"].Value.ToString());
                        cmdUpdateMotor.ExecuteNonQuery();

                        // update tgl_kembali di tabel transaksi
                        // mengupdate transaksi dengan identifier id_transaksi
                        string queryUpdateTransaksi = "UPDATE transaksi SET tgl_kembali = @tgl_kembali WHERE id_transaksi = @id_transaksi";
                        SqlCommand cmdUpdateTransaksi = new SqlCommand(queryUpdateTransaksi, konek.conn, trans);
                        cmdUpdateTransaksi.Parameters.AddWithValue("@id_transaksi", row.Cells["id_transaksi"].Value.ToString());
                        cmdUpdateTransaksi.Parameters.AddWithValue("@tgl_kembali", DateTime.Now);
                        cmdUpdateTransaksi.ExecuteNonQuery();

                        trans.Commit(); // commit kalo semua berhasil
                        MessageBox.Show("Motor berhasil dikembalikan!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback(); // kalo error, rollback
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnLaporan_Click(object sender, EventArgs e)
        {
            new Laporan().Show();
            this.Hide();
        }
    }
}
