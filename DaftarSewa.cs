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

        // bikin object koneksi
        public Koneksi konek = new Koneksi();

        public DaftarSewa()
        {
            InitializeComponent();
        }

        // bikin function buat ngeload data motor
        public void LoadDataMotor()
        {

            // ngambil data yang diperluin aja bang

            string query = "SELECT id_motor, nama_motor, no_motor, jenis, harga, status FROM motor;";

            try
            {
                // seperti biasa, siapin command, data adapter, dan datatable
                SqlCommand cmd = new SqlCommand(query, konek.conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                // fill dt dari data adapter
                da.Fill(dt);

                // source dgvMotor dari dt
                dgvMotor.DataSource = dt;

                // cek apakah di column dgvMotor ada col sewa atau belum
                // kalo beum ada berarti hasilnya false, karena pake not jadi masuk ke if
                if (!dgvMotor.Columns.Contains("Sewa"))
                {

                    // bikin column button baru
                    DataGridViewButtonColumn sewaCol = new DataGridViewButtonColumn();
                    sewaCol.Name = "Sewa";
                    sewaCol.HeaderText = "Sewa";
                    sewaCol.Text = "Sewa";
                    sewaCol.UseColumnTextForButtonValue = true;
                    dgvMotor.Columns.Add(sewaCol);
                }

                // hide id_motor column
                if (dgvMotor.Columns.Contains("id_motor"))
                {
                    dgvMotor.Columns["id_motor"].Visible = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DaftarSewa_Load(object sender, EventArgs e)
        {
            // buka koneksi
            konek.Open();
            // langsung load semua data motor
            LoadDataMotor();
        }

        private void btnCari_Click(object sender, EventArgs e)
        {

            // kalo button cari di click

            // bangun query buatn nyari data motor
            // di query ini gua buat supaya semua data yang ditampilkan bisa jadi keyword pencarian
            // kaya nama motor, jenis, no motor, merk, harga
            string query = "SELECT id_motor, nama_motor, no_motor, jenis, harga, status FROM motor WHERE nama_motor LIKE @keyword OR jenis LIKE @keyword OR no_motor LIKE @keyword OR merk LIKE @keyword OR harga LIKE @keyword";

            try
            {
                // langsung siapin command, data adapter, dan datatable
                SqlCommand cmd = new SqlCommand(query, konek.conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                // binding parameter keyword dari textbox txtKey
                // tanda % untuk wildcard biar bisa nyari sebagian kata
                // pake di depan sama belakang biar bisa nyari di tengah kata juga
                cmd.Parameters.AddWithValue("@keyword", "%" + txtKey.Text + "%");

                // fill dt dari data adapter
                da.Fill(dt);
                // tampilin data hasil pencarian
                dgvMotor.DataSource = dt;

                // hide id_motor column
                if (dgvMotor.Columns.Contains("id_motor"))
                {
                    dgvMotor.Columns["id_motor"].Visible = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // optional doang buat nampilin jumlah data yang ditemukan
            // jumlah data diambil dari row count dgvMotor
            // dikurang 1 karena walau ada row kosong , row itu tetep dihitung
            int jumlahData = dgvMotor.Rows.Count - 1; // dvgMotor.Rows.Count itu ngitung semua row termasuk row kosong terakhir

            // cek kalo jumlah datanya 0 nampilin data tidak ditemukan
            if (jumlahData == 0)
            {
                MessageBox.Show("Data tidak ditemukan!");
            }
            // kalo data ada lebih dari 0 nampilin jumlah data yang ditemukan
            else
            {
                MessageBox.Show($"Ditemukan {jumlahData} data!");
            }
        }

        private void dgvMotor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            // cek kalo kolom yang di click itu kolom sewa
            // dan yang di klik itu baris data, bukan header
            if (dgvMotor.Columns[e.ColumnIndex].Name == "Sewa" && e.RowIndex >= 0)
            {
                
                // tampung data dari baris yang di click
                // row nyimpen semua data di baris itu
                // dan bisa diakses per kolomnya
                DataGridViewRow row = dgvMotor.Rows[e.RowIndex];

                // cek kolom status motor aktif atau nggak                    
                if (row.Cells["status"].Value.ToString().ToLower() == "aktif")
                {
                    // kalo aktif bikin object form sewa dulu
                    Sewa frm = new Sewa();

                    // isi properti di form sewa berdasarkan baris data yang di click
                    // karena di form sewa udah bikin setter sama getter
                    // jadi datanya tinggal kirim dari sini
                    // dan berdasar data dari row yang di click
                    frm.IdMotor = Convert.ToInt16(row.Cells["id_motor"].Value);
                    frm.NamaMotor = row.Cells["nama_motor"].Value.ToString();
                    frm.NoMotor = row.Cells["no_motor"].Value.ToString();
                    frm.Jenis = row.Cells["jenis"].Value.ToString();
                    frm.Harga = Convert.ToInt32(row.Cells["harga"].Value);
                    frm.Status = row.Cells["status"].Value.ToString();
                    // tampilkan form sewa sebagai dialog
                    frm.ShowDialog();

                    // load setelah form sewa ditutup
                    LoadDataMotor();
                }

                // kalo status motor ga aktif pas di cek diatas
                else
                {
                    // tampilin pesan ini aja
                    MessageBox.Show("Motor sedang tidak aktif atau sedang di sewa!");
                }

                
            }
        }

        private void btnPengembalian_Click(object sender, EventArgs e)
        {
            // kalo kembali di klik
            new Pengembalian().Show();
            // sembunyiin form daftar sewa
            this.Hide();
        }

        private void btnLaporan_Click(object sender, EventArgs e)
        {
            new Laporan().Show();
            this.Hide();
        }
    }
}
