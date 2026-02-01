using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// library buat koneksi ke sql server
using System.Data.SqlClient; // harus pake ini buat segala hal yang berhubungan sama sql server

namespace MobilEsemka
{
    public partial class USMotor : UserControl
    {
        // bikin object koneksi
        public Koneksi konek = new Koneksi();
        public USMotor()
        {
            InitializeComponent();
        }

        // bikin method untuk load data motor
        private void LoadDataMotor()
        {
            // bangun query buat ngambil data tertentu yang mau ditampilin
            string query = "SELECT id_motor ,nama_motor, no_motor, jenis, merk, gambar,harga FROM motor;";

            // pake try catch biar kalo error bisa ketangkep
            try
            {
                // bikin command buat eksekusi query
                SqlCommand cmd = new SqlCommand(query, konek.conn);

                // bikin dataadapter buat nampung data dari command
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                // bikin datatable buat nampung data dari dataadapter
                DataTable dt = new DataTable();

                // isi datatable pake data yang ada di data adapter
                da.Fill(dt);

                // tampilin data di datagridview
                dgvMotor.DataSource = dt;

                // hide kolom id_motor dan gambar
                dgvMotor.Columns["gambar"].Visible = false;
                dgvMotor.Columns["id_motor"].Visible = false; 

            }
            catch(Exception ex)
            {
                // tangkep error
                MessageBox.Show(ex.Message);
            }
        }

        private void USMotor_Load(object sender, EventArgs e)
        {
            // buka koneksi
            konek.Open();

            //load data motor
            LoadDataMotor();
        }

        // event kalo btnTambah di klik
        private void btnTambah_Click(object sender, EventArgs e)
        {

            // bikin object form tambah
            tambah frm = new tambah();

            // tampilkan form tambah, modal
            // form utama ga bakal bisa diapa-apain
            // sampe lau tutup form tambah :v
            frm.ShowDialog();

            // abis tambah ditutup data langsung di refresh pake LoadDataMotor
            LoadDataMotor();
        }

        private void dgvMotor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // event kalo user double klik di datagridview
        private void dgvMotor_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            // cek kalo row yang di klik user bukan header
            // kalo valid, ambil data dari row yang di klik
            if (e.RowIndex >= 0)
            {
                // bikin object row buat nampung data row yang di klik
                DataGridViewRow row = dgvMotor.Rows[e.RowIndex];

                // tampilin data di label dan picturebox dari data yang di klik
                // data berdasarkan nama kolom di database
                // dan data yang dimasukan saat tambah motor
                lblJenis.Text = row.Cells["jenis"].Value.ToString();
                lblNoMotor.Text = row.Cells["no_motor"].Value.ToString();
                lblMerk.Text = row.Cells["merk"].Value.ToString();
                lblNamaMotor.Text = row.Cells["nama_motor"].Value.ToString();
                pbMotor.ImageLocation = row.Cells["gambar"].Value.ToString();
                lblHargaSewa.Text = row.Cells["harga"].Value.ToString();

            }
        }

        private void USMotor_Enter(object sender, EventArgs e)
        {
            LoadDataMotor();
        }
    }
}
