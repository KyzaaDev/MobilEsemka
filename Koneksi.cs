using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MobilEsemka
{
    public class Koneksi
    {
        string conString = "Data Source=ZAKYNSA\\SQLEXPRESS; Initial Catalog=MobilEsemka; uid=kyzaadev; password=982003";
        public SqlConnection conn = null;

        public void Open()
        {
            conn = new SqlConnection(conString);

            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Close()
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
