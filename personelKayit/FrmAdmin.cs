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

namespace personelKayit
{
    public partial class FrmAdmin : Form
    {
        public FrmAdmin()
        {
            InitializeComponent();
        }
        SqlConnection request = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PersonelVeritabani;Integrated Security=True");


        private void button1_Click(object sender, EventArgs e)
        {
            request.Open();
            SqlCommand cmd = new SqlCommand("Select * From Tbl_Admin where Username=@p1 and Password=@p2", request);
            cmd.Parameters.AddWithValue("@p1", TxtUsername.Text);
            cmd.Parameters.AddWithValue("@p2", TxtPassword.Text);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read()) {
                Form1 form = new Form1();
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı ya da şifre hatalı!");
            }
            request.Close();

        }
    }
}
