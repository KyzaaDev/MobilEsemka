using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            lblGreet.Text += " " + Session.Nama;
            lblUser.Text += " " + Session.Level;
            lblTgl.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy");
        }

        private void btnSewa_Click(object sender, EventArgs e)
        {
            new DaftarSewa().Show();
            this.Hide();
        }
    }
}
