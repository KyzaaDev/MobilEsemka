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
    public partial class Pengembalian : Form
    {
        public Koneksi konek = new Koneksi();
        public Pengembalian()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            string query = @"SELECT t.id_transaksi, p.nama, m.nama_motor, m.no_motor, m.jenis,
                            t.tgl_sewa, t.tgl_kembali
                     FROM motor m
                     JOIN transaksi t ON m.id_motor = t.id_motor
                     JOIN pelanggan p ON p.id_pelanggan = t.id_pelanggan
                     WHERE p.nama LIKE @keyword OR t.id_pelanggan LIKE @keyword";

            SqlCommand cmd = new SqlCommand(query, konek.conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            cmd.Parameters.AddWithValue("@keyword", "%" + txtKey.Text + "%");
            da.Fill(dt);

            dgvMotor.DataSource = dt;

            dgvMotor.Columns["id_transaksi"].Visible = false;
            dgvMotor.Columns["Kembalikan"].Visible = true;
        }


        private void txtKey_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKey.Text))
            {
                dgvMotor.DataSource = null;
                dgvMotor.Columns["Kembalikan"].Visible = false;
                return;
            }   

            LoadData();
        }

        private void Pengembalian_Load(object sender, EventArgs e)
        {
            konek.Open();

            if (!dgvMotor.Columns.Contains("Kembalikan"))
            {
                DataGridViewButtonColumn kembaliCol = new DataGridViewButtonColumn();
                kembaliCol.Name = "Kembalikan";
                kembaliCol.HeaderText = "Kembalikan";
                kembaliCol.Text = "Kembalikan";
                kembaliCol.UseColumnTextForButtonValue = true;
                dgvMotor.Columns.Add(kembaliCol);
            }
            dgvMotor.Columns["Kembalikan"].Visible = false;
        }

        private void btnSewa_Click(object sender, EventArgs e)
        {
            new DaftarSewa().Show();
            this.Hide();
        }

        private void btnSewaBr_Click(object sender, EventArgs e)
        {
            new DaftarSewa().Show();
            //this.Hide();
        }

        private void dgvMotor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMotor.Columns[e.ColumnIndex].Name == "Kembalikan" && e.RowIndex >= 0)
            {
                DialogResult balik = MessageBox.Show("Yakin ingin kembalikan motor?", "Konfirmasi pengembalian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (balik == DialogResult.Yes)
                {

                    //update status motor disewa
                    string query = "UPDATE motor SET status = 'Aktif' WHERE no_motor = @no_motor; ";
                    SqlCommand cmdUpdateMotor = new SqlCommand(query, konek.conn);
                    cmdUpdateMotor.Parameters.AddWithValue("@no_motor", dgvMotor.Rows[e.RowIndex].Cells["no_motor"].Value.ToString());
                    cmdUpdateMotor.ExecuteNonQuery();

                    // update tgl_kembali di tabel transaksi
                    string query2 = "UPDATE transaksi SET tgl_kembali = @tgl_kembali WHERE id_transaksi = @id_transaksi";
                    SqlCommand cmdUpdateTransaksi = new SqlCommand(query2, konek.conn);
                    cmdUpdateTransaksi.Parameters.AddWithValue("@id_transaksi", dgvMotor.Rows[e.RowIndex].Cells["id_transaksi"].Value.ToString());
                    cmdUpdateTransaksi.Parameters.AddWithValue("@tgl_kembali", DateTime.Now);
                    cmdUpdateTransaksi.ExecuteNonQuery();

                    MessageBox.Show("Motor berhasil dikembalikan!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
            }
        }
    }
}
