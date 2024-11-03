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
    public partial class Frmistatistik : Form
    {
        public Frmistatistik()
        {
            InitializeComponent();
        }
        SqlConnection request = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PersonelVeritabani;Integrated Security=True");

        private void Frmistatistik_Load(object sender, EventArgs e)
        {
            request.Open();
            SqlCommand cmd = new SqlCommand("Select Count(*) From Tbl_Personel", request);
            SqlDataReader dr1 = cmd.ExecuteReader();
            while (dr1.Read()) {
                label2.Text = dr1[0].ToString();//dr1[0]= sql tarafında 0 index de  toplam kullanıcıyı gösterir

            }
            request.Close();
            //Şehir sayısı
            request.Open();
            SqlCommand cmd2 = new SqlCommand("Select count(distinct(PerSehir)) From Tbl_Personel", request);//distinct benzersiz olmasını sağlar
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                label4.Text = dr2[0].ToString();

            }

            request.Close();

            //toplam maas
            request.Close();
            //Şehir sayısı
            request.Open();
            SqlCommand cmd3 = new SqlCommand("Select Sum(PerMaas) From Tbl_Personel", request);//sum  Toplama yapar
            SqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {
                label6.Text = dr3[0].ToString();

            }
            request.Close();
            //ortalama maaş
            request.Open();
            SqlCommand cmd4 = new SqlCommand("Select Avg(PerMaas) From Tbl_Personel", request);
            SqlDataReader dr4 = cmd4.ExecuteReader();
            while (dr4.Read())
            {
                label8.Text = dr4[0].ToString();

            }
            request.Close();

        }
    }
}
