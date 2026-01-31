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
        // bikin string buat connect ke db sql server
        // bikin object sqlconnection yang nilainya null, karena di set pas udah di open di method open
        string conString = "Data Source=ZAKYNSA\\SQLEXPRESS; Initial Catalog=MobilEsemka; uid=kyzaadev; password=982003";
        public SqlConnection conn = null;

        public void Open()
        {
            // set object sqlconnection
            conn = new SqlConnection(conString);

            try
            {
                // ngecek apakah status dari koneksi belum terbuka
                // kalo belum terbuka baru dibuka pake Open()
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
                // ngecek apakah status koneksinya terbuka
                // ya kalo kebuka berarti ditutup
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
