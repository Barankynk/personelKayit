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
    public partial class FrmGrafik : Form
    {
        public FrmGrafik()
        {
            InitializeComponent();
        }
        SqlConnection request = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PersonelVeritabani;Integrated Security=True");


        private void FrmGrafik_Load(object sender, EventArgs e)
        {
            request.Open();
            SqlCommand komutg1=new SqlCommand ("Select PerSehir,Count(*) From Tbl_Personel Group By PerSehir", request);
            SqlDataReader dr1 = komutg1.ExecuteReader();
            while (dr1.Read()) {
                chart1.Series["Sehirler"].Points.AddXY(dr1[0], dr1[1]);
                    }
            request.Close();
            request.Open();
            SqlCommand komutg2 = new SqlCommand("Select PerMeslek,Avg(PerMaas) From Tbl_Personel Group By PerMeslek", request);
            SqlDataReader dr2 = komutg2.ExecuteReader();
            while (dr2.Read())
            {
                chart2.Series["Meslek-Maas"].Points.AddXY(dr2[0], dr2[1]);
            }
            request.Close();

        }
    }
}
