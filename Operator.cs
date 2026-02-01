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

namespace MobilEsemka
{
    public partial class Operator : Form
    {
        public Operator()
        {
            InitializeComponent();
        }

        private void Operator_Load(object sender, EventArgs e)
        {
            // Menampilkan data session
            lblGreet.Text += " " + Session.Nama;
            lblUser.Text += " " + Session.Level;
            // Menampilkan tanggal sekarang
            lblTgl.Text = DateTime.Now.ToString("d MMMM yyyy", new CultureInfo("id-ID"));
        }

        private void btnSewa_Click(object sender, EventArgs e)
        {
            // kalo sewa di klik
            // buka form daftar sewa
            // form ini di hide
            new DaftarSewa().Show();
            this.Hide();
        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            // kalo kembali di klik
            // buka form pengembalian
            // ini di hide
            new Pengembalian().Show();
            this.Hide();
        }
    }
}
