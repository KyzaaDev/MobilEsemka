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
    public partial class USMotor : UserControl
    {
        public Koneksi konek = new Koneksi();
        public USMotor()
        {
            InitializeComponent();
        }

        private void LoadDataMotor()
        {
            string query = "SELECT id_motor ,nama_motor, no_motor, jenis, merk, gambar,harga FROM motor;";

            try
            {
                SqlCommand cmd = new SqlCommand(query, konek.conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                dgvMotor.DataSource = dt;
                dgvMotor.Columns["gambar"].Visible = false;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void USMotor_Load(object sender, EventArgs e)
        {
            konek.Open();
            LoadDataMotor();
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            tambah frm = new tambah();
            frm.ShowDialog();

            // setelah form ditutup
            LoadDataMotor();
        }

        private void dgvMotor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvMotor_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int baris = dgvMotor.SelectedRows[0].Index;
            var barisData = dgvMotor.Rows[baris];

            lblJenis.Text = barisData.Cells[1].Value.ToString();
            lblNoMotor.Text = barisData.Cells[2].Value.ToString();
            lblMerk.Text = barisData.Cells[3].Value.ToString();
            lblNamaMotor.Text = barisData.Cells[4].Value.ToString();
            pbMotor.ImageLocation = barisData.Cells[5].Value.ToString();
            lblHargaSewa.Text = barisData.Cells[6].Value.ToString();
        }

        private void USMotor_Enter(object sender, EventArgs e)
        {
            LoadDataMotor();
        }
    }
}
