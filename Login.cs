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
    public partial class Login : Form
    {
        public Koneksi konek = new Koneksi();
        public Login()
        {
            InitializeComponent();
        }

        private void ClearForms()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        private bool ValidateInput()
        {
            errorProvideLogin.Clear();

            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                errorProvideLogin.SetError(txtUsername, "Username harus diisi!");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errorProvideLogin.SetError(txtPassword, "Password harus diisi!");
                return false;
            }

            return true;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            konek.Open();
        }

        
 
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }

            string username = txtUsername.Text;
            string password = txtPassword.Text;

            string query = "SELECT * FROM [users] WHERE username COLLATE Latin1_General_BIN = @username AND password COLLATE Latin1_General_BIN = @password;";
            SqlCommand cmd = new SqlCommand(query, konek.conn);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    Session.IsLogin = true;
                    Session.Username = reader["username"].ToString();
                    Session.Nama = reader["nama"].ToString();
                    Session.Level = reader["level"].ToString();
                    Session.idUser = Convert.ToInt32(reader["id_user"]);

                    MessageBox.Show("Login berhasil!");

                    if (Session.Level.ToLower() == "admin")
                    {
                        new Admin().Show();
                        this.Hide();
                    }
                    else if (Session.Level.ToLower() == "operator")
                    {
                        new Operator().Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Username atau password salah!");
                    ClearForms();
                    txtUsername.Focus();
                }
            }

            

        }
    }
}
