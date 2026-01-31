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
    public partial class DaftarSewa : Form
    {
        public Koneksi konek = new Koneksi();

        public DaftarSewa()
        {
            InitializeComponent();
        }

        public void LoadDataMotor()
        {
            string query = "SELECT id_motor, nama_motor, no_motor, jenis, harga, status FROM motor;";

            try
            {
                SqlCommand cmd = new SqlCommand(query, konek.conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                dgvMotor.DataSource = dt;

                if (!dgvMotor.Columns.Contains("Sewa"))
                {
                    DataGridViewButtonColumn sewaCol = new DataGridViewButtonColumn();
                    sewaCol.Name = "Sewa";
                    sewaCol.HeaderText = "Sewa";
                    sewaCol.Text = "Sewa";
                    sewaCol.UseColumnTextForButtonValue = true;
                    dgvMotor.Columns.Add(sewaCol);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DaftarSewa_Load(object sender, EventArgs e)
        {
            konek.Open();
            LoadDataMotor();
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            string query = "SELECT id_motor, nama_motor, no_motor, jenis, harga, status FROM motor WHERE nama_motor LIKE @keyword OR jenis LIKE @keyword OR no_motor LIKE @keyword OR merk LIKE @keyword OR harga LIKE @keyword";

            try
            {
                SqlCommand cmd = new SqlCommand(query, konek.conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                cmd.Parameters.AddWithValue("@keyword", "%" + txtKey.Text + "%");

                da.Fill(dt);
                dgvMotor.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            int jumlahData = dgvMotor.Rows.Count - 1;
            if (jumlahData == 0)
            {
                MessageBox.Show("Data tidak ditemukan!");
            }
            else
            {
                MessageBox.Show($"Ditemukan {jumlahData} data!");
            }
        }

        private void dgvMotor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMotor.Columns[e.ColumnIndex].Name == "Sewa" && e.RowIndex >= 0)
            {
                
                DataGridViewRow row = dgvMotor.Rows[e.RowIndex];

                if (row.Cells["status"].Value.ToString().ToLower() == "aktif")
                {
                    Sewa frm = new Sewa();
                    frm.IdMotor = Convert.ToInt16(row.Cells["id_motor"].Value);
                    frm.NamaMotor = row.Cells["nama_motor"].Value.ToString();
                    frm.NoMotor = row.Cells["no_motor"].Value.ToString();
                    frm.Jenis = row.Cells["jenis"].Value.ToString();
                    frm.Harga = Convert.ToInt32(row.Cells["harga"].Value);
                    frm.Status = row.Cells["status"].Value.ToString();
                    frm.ShowDialog();

                    // load setelah form sewa ditutup
                    LoadDataMotor();
                }
                else
                {
                    MessageBox.Show("Motor sedang tidak aktif atau sedang di sewa!");
                }

                
            }
        }

        private void btnPengembalian_Click(object sender, EventArgs e)
        {
            new Pengembalian().Show();  
            this.Hide();
        }
    }
}
