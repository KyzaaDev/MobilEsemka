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
    public partial class tambah : Form
    {
        // bikin variable buat nyimpen lokasi gambar
        private string imageLoc = "";

        // bikin object koneksi
        public Koneksi konek = new Koneksi();
        public tambah()
        {
            InitializeComponent();
        }

        // method buat validasi input
        private bool ValidateInput()
        {
            // bersihin error provider
            epTambah.Clear();

            // validasi tiap input
            if (string.IsNullOrWhiteSpace(txtJenis.Text))
            {
                epTambah.SetError(txtJenis, "Jenis motor harus diisi!");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtNoMotor.Text))
            {
                epTambah.SetError(txtNoMotor, "Nomer motor harus diisi!");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtMerk.Text))
            {
                epTambah.SetError(txtMerk, "Merk motor harus diisi!");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtNamaMotor.Text))
            {
                epTambah.SetError(txtNamaMotor, "Nama motor harus diisi!");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtHargaSewa.Text))
            {
                epTambah.SetError(txtHargaSewa, "Harga harus diisi!");
                return false;
            }

            // buat ngecek kalo harga yang diinput user itu angka
            if (!int.TryParse(txtHargaSewa.Text, out _))
            {
                epTambah.SetError(txtHargaSewa, "Harga harus berisi angka!");
                return false;
            }
            return true;
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            // kalo batal, form ini ditutup
            this.Close();
        }

        // method buat bersihin form
        private void ClearForms()
        {
            txtJenis.Text = "";  // ngebersihin semua textbox
            txtNoMotor.Text = "";
            txtMerk.Text = "";
            txtNamaMotor.Text = "";
            pictureBox1.ImageLocation = ""; // ngebersihin gambar
            txtHargaSewa.Text = "";
        }

        // method buat milih gambar, nanti dipanggil di event klik tombol pilih gambar
        private void btnPilihGBR_Click(object sender, EventArgs e)
        {

            // pake try, biar kalo ada error bisa ketangkep
            try
            {
                // bikin open file dialog
                OpenFileDialog dial = new OpenFileDialog();

                // kasih filter biar cuma gambar yang bisa di uplaod
                // filter dimasukin lewat properti Filter   
                dial.Filter = "JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|All Files (*.*)|*.*";

                // cek kalo user milih file terus klik OK
                if (dial.ShowDialog() == DialogResult.OK)
                {
                    // simpen lokasi gambar ke variable global imageLoc
                    imageLoc = dial.FileName;

                    // tampilin gambar di picturebox
                    // ngambil gambarnya dari lokasi yang disimpen di imageLoc
                    pictureBox1.ImageLocation = imageLoc;
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            // validasi input dulu kaya yang di login
            // intinya kalo return dari ValidateInput itu false, berarti ada yang salah di input user
            // karena pake not, jadi kalo false bakal masuk ke if
            // kalo aman semua berarti input bener, dan masuk ke else
            if (!ValidateInput())
            {
                // ada yang salah di input user
                return;
            }
            else
            {
                // bikin query insert
                string query = "INSERT INTO motor (jenis, no_motor, merk, nama_motor, gambar, harga) VALUES (@jenis, @no_motor, @merk, @nama_motor, @gambar, @harga)";
                // path gambar diambil dari variable global imageLoc
                string pathGambar = imageLoc;

                // pake try catch biar kalo error bisa ketangkep
                try
                {
                    // siapin command buat eksekusi query
                    SqlCommand cmd = new SqlCommand(query, konek.conn);

                    //binding parameter yang ada di query
                    // nilainya diambil dari input user di textbox
                    // kecuali gambar, diambil dari variable pathGambar
                    // dan pathGambar itu isinya diambil dari variable global imageLoc
                    cmd.Parameters.AddWithValue("@jenis", txtJenis.Text);
                    cmd.Parameters.AddWithValue("@no_motor", txtNoMotor.Text);
                    cmd.Parameters.AddWithValue("@merk", txtMerk.Text);
                    cmd.Parameters.AddWithValue("@nama_motor", txtNamaMotor.Text);
                    cmd.Parameters.AddWithValue("@gambar", pathGambar);
                    cmd.Parameters.AddWithValue("@harga", txtHargaSewa.Text);

                    // eksekusi command
                    cmd.ExecuteNonQuery();
                    // kasih tau user kalo data berhasil disimpan 
                    MessageBox.Show("Berhasil menyimpan data motor!");
                    // bersihin form setelah data disimpan
                    ClearForms();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        private void tambah_Load(object sender, EventArgs e)
        {

            // kalo form ke load, koneksi dibuka
            konek.Open();
        }
    }
}
