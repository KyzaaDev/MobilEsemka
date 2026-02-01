using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobilEsemka
{
    public partial class Laporan : Form
    {

        public Koneksi konek = new Koneksi();
        public Laporan()
        {
            InitializeComponent();
        }

        private void Laporan_Load(object sender, EventArgs e)
        {
            konek.Open();
            LoadData();
        }

        private void LoadData()
        {
            string query = "SELECT t.id_transaksi, m.nama_motor, m.harga, t.lama, t.total_harga FROM motor m JOIN transaksi t ON m.id_motor = t.id_motor WHERE t.id_user = @id_user";

            SqlCommand cmd = new SqlCommand(query, konek.conn);
            cmd.Parameters.AddWithValue("@id_user", Session.idUser);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            
            da.Fill(dt);
            dgvLaporan.DataSource = dt;
            decimal totalPendapatan = 0;

            foreach (DataGridViewRow data in dgvLaporan.Rows)
            {
                if (!data.IsNewRow)
                {
                    totalPendapatan += Convert.ToDecimal(data.Cells["total_harga"].Value);
                }
            }

            lblTotal.Text = totalPendapatan.ToString("N0");


        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            string query = "SELECT t.id_transaksi, m.nama_motor, m.harga, t.lama, t.total_harga FROM motor m JOIN transaksi t ON m.id_motor = t.id_motor WHERE t.id_user = @id_user AND CONVERT(date, t.tgl_sewa) = @tgl_sewa";

            try
            {
                SqlCommand cmd = new SqlCommand(query, konek.conn);
                cmd.Parameters.AddWithValue("@id_user", Session.idUser);
                cmd.Parameters.AddWithValue("@tgl_sewa", dtpTanggal.Value.Date);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvLaporan.DataSource = dt;

                decimal totalPendapatan = 0;

                foreach (DataGridViewRow data in dgvLaporan.Rows)
                {
                    if (!data.IsNewRow)
                    {
                        totalPendapatan += Convert.ToDecimal(data.Cells["total_harga"].Value);
                    }
                }

                lblTotal.Text = totalPendapatan.ToString("N0");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnSewa_Click(object sender, EventArgs e)
        {
            new DaftarSewa().Show();
            this.Hide();
        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            new Pengembalian().Show();
            this.Hide();
        }
    }
}
