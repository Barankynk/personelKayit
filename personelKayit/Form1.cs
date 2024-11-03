using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace personelKayit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection request = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PersonelVeritabani;Integrated Security=True");
        void temizle()
        {
            foreach (Control control in groupBox1.Controls)
            {
                if (control is TextBox || control is MaskedTextBox || control is ComboBox)
                {
                    control.Text = string.Empty;
                }

            }
            TxtAd.Focus();
        }
       
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
         


        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'personelVeritabaniDataSet2.Tbl_Personel' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tbl_PersonelTableAdapter.Fill(this.personelVeritabaniDataSet2.Tbl_Personel);

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            request.Open();
            SqlCommand cmd= new SqlCommand("insert into Tbl_Personel (PerAd,PerSoyad,PerSehir,PerMaas,PerMeslek) values (@p1,@p2,@p3,@p4,@p5)", request);
            cmd.Parameters.AddWithValue("@p1", TxtAd.Text);
            cmd.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            cmd.Parameters.AddWithValue("@p3", cmbSehir.Text);
            cmd.Parameters.AddWithValue("@p4", mskmaas.Text);
            cmd.Parameters.AddWithValue("@p5", txtMeslek.Text);
            cmd.ExecuteNonQuery();//sorguyu çalıştır ekle - sil -güncelle
            request.Close();
            MessageBox.Show("Personel Eklendi");
        }

       

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            request.Open();
            SqlCommand cmdDelete = new SqlCommand("Delete From Tbl_Personel where perid=@k1", request);
            cmdDelete.Parameters.AddWithValue("@k1",Txtid.Text);
            cmdDelete.ExecuteNonQuery();
            request.Close();
            MessageBox.Show("Personel Silindi");
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;

            Txtid.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
            TxtAd.Text = dataGridView2.Rows[secilen].Cells[1].Value.ToString();
            TxtSoyad.Text = dataGridView2.Rows[secilen].Cells[2].Value.ToString();
            cmbSehir.Text = dataGridView2.Rows[secilen].Cells[3].Value.ToString();
            mskmaas.Text = dataGridView2.Rows[secilen].Cells[4].Value.ToString();
            txtMeslek.Text = dataGridView2.Rows[secilen].Cells[5].Value.ToString();
        }
       


        private void BtnUpdate_Click_1(object sender, EventArgs e)
        {
            request.Open();
            SqlCommand cmdUpdate = new SqlCommand("Update Tbl_Personel Set PerAd=@a1,PerSoyad=@a2,PerSehir=@a3,PerMaas=@a4,PerMeslek=@a5 where Perid=@a6", request);
            cmdUpdate.Parameters.AddWithValue("@a1", TxtAd.Text);
            cmdUpdate.Parameters.AddWithValue("@a2", TxtSoyad.Text);
            cmdUpdate.Parameters.AddWithValue("@a3", cmbSehir.Text);
            cmdUpdate.Parameters.AddWithValue("@a4", mskmaas.Text);
            cmdUpdate.Parameters.AddWithValue("@a5", txtMeslek.Text);
            cmdUpdate.Parameters.AddWithValue("@a6", Txtid.Text);
            cmdUpdate.ExecuteNonQuery();
            request.Close();
            MessageBox.Show("Personel Güncellendi");
        }

        private void Btnİstatistik_Click_1(object sender, EventArgs e)
        {
            Frmistatistik fr = new Frmistatistik();
            fr.Show();
        }

        private void BtnGrafikler_Click_1(object sender, EventArgs e)
        {
            FrmGrafik frg = new FrmGrafik();
            frg.Show();
        }
    }
}
