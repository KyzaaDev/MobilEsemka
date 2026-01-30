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

        public string imageLoc = "";
        public Koneksi konek = new Koneksi();
        public tambah()
        {
            InitializeComponent();
        }


        private bool ValidateInput()
        {
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
            if (!int.TryParse(txtHargaSewa.Text, out _))
            {
                epTambah.SetError(txtHargaSewa, "Harga harus berisi angka!");
                return false;
            }
            return true;
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearForms()
        {
            txtJenis.Text = "";
            txtNoMotor.Text = "";
            txtMerk.Text = "";
            txtNamaMotor.Text = "";
            pictureBox1.ImageLocation = "";
            txtHargaSewa.Text = "";
        }
        private void btnPilihGBR_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dial = new OpenFileDialog();
                dial.Filter = "JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|All Files (*.*)|*.*";


                if (dial.ShowDialog() == DialogResult.OK)
                {
                    imageLoc = dial.FileName;

                    pictureBox1.ImageLocation = imageLoc;
                    lblPathGBR.Text = imageLoc;
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {

            if (!ValidateInput())
            {
                return;
            }
            else
            {
                string query = "INSERT INTO motor (jenis, no_motor, merk, nama_motor, gambar, harga) VALUES (@jenis, @no_motor, @merk, @nama_motor, @gambar, @harga)";
                string pathGambar = imageLoc;

                try
                {
                    SqlCommand cmd = new SqlCommand(query, konek.conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    //binding parameter
                    cmd.Parameters.AddWithValue("@jenis", txtJenis.Text);
                    cmd.Parameters.AddWithValue("@no_motor", txtNoMotor.Text);
                    cmd.Parameters.AddWithValue("@merk", txtMerk.Text);
                    cmd.Parameters.AddWithValue("@nama_motor", txtNamaMotor.Text);
                    cmd.Parameters.AddWithValue("@gambar", pathGambar);
                    cmd.Parameters.AddWithValue("@harga", txtHargaSewa.Text);

                    // execute
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Berhasil menyimpan data motor!");
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
            konek.Open();
        }
    }
}
