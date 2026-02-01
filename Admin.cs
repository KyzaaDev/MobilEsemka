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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            // pas form di load, dashboard bikin greeting berdasar session user yg login

            // contoh: "Selamat datang, Admin"
            lblGreet.Text += " " + Session.Nama;
            // contoh: "Level: Admin"
            lblUser.Text += " " + Session.Level;
        }

        public void LoadControl(UserControl uc)
        {
            pnlMotor.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlMotor.Controls.Add(uc);
        }

        private void btnMotor_Click(object sender, EventArgs e)
        {
            LoadControl(new USMotor());
        }
    }
}
