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
        public Koneksi konek = new Koneksi(); // bikin objek koneksi
        public Login()
        {
            InitializeComponent();
        }

        // bikin functio buat ngeclear form
        private void ClearForms()
        {
            txtUsername.Text = ""; // ngeclear textbox username
            txtPassword.Text = ""; // ngeclear textbox password
        }

        // bikin function buat validasi input
        private bool ValidateInput()
        {
            // ngeclear error provider
            errorProvideLogin.Clear();

            // ngecek kalo username sama password kosong
            // semisal kosong munculin error provider dan return false
            //biar waktu dicek pake if di btnLogin ga lanjut (dicek pake not)

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

            // kalo lolos semua baru return true
            return true;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            // waktu form login diload, koneksi di open pake method open yang dibikin di class Koneksi
            konek.Open();
        }

        
 
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // cek validate input, kalo yang di return dari function ValidateInput false (not false = true) ga lanjut
            // kalo yang di return dari function ValidateInput true (not true = false) lanjut
            if (!ValidateInput())
            {
                // kalo error ga lanjut
                return;
            }

            // ngambil username sama password dari textbox
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // bikin query buat ngecek username sama password di database
            // username dan password di compare pake collation Latin1_General_BIN biar case sensitive
            string query = "SELECT * FROM [users] WHERE username COLLATE Latin1_General_BIN = @username AND password COLLATE Latin1_General_BIN = @password;";
            SqlCommand cmd = new SqlCommand(query, konek.conn);

            // ngebind parameter username sama password
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);

            // ngeexecute reader
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                // ngecek kalo ada data yang sesuai
                if (reader.Read())
                {
                    // kalo ada yang sesuai, beberapa data user disimpen ke session
                    // data diambil dari reader yang isinya hasil query
                    Session.IsLogin = true;
                    Session.Username = reader["username"].ToString();
                    Session.Nama = reader["nama"].ToString();
                    Session.Level = reader["level"].ToString();
                    Session.idUser = Convert.ToInt32(reader["id_user"]);

                    MessageBox.Show("Login berhasil!");

                    // ngecek level/role user, buat nentuin kemana user harus diredirect
                    if (Session.Level.ToLower() == "admin")
                    {
                        // admin diredirect ke form Admin
                        new Admin().Show();
                        this.Hide();
                    }
                    else if (Session.Level.ToLower() == "operator")
                    {
                        // operator diredirect ke form Operator
                        new Operator().Show();
                        this.Hide();
                    }
                }
                // kalo ga ada data yang sesuai 
                else
                {
                    // tampilkan pesan gagal login
                    MessageBox.Show("Username atau password salah!");

                    // bershiin form input dari function yang udah dibuat
                    ClearForms();
                    // fokus ke textbox username
                    txtUsername.Focus();
                }
            }

            

        }
    }
}
