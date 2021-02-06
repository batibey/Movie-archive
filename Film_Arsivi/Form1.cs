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



namespace Film_Arsivi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection bgl = new SqlConnection(@"Data Source=LAPTOP-090J43E4\SQLEXPRESS;Initial Catalog=FilmArsivim;Integrated Security=True");

        void filmler()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * FROM TBLFILMLER", bgl);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            filmler();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand komut = new SqlCommand("insert into TBLFILMLER (AD,KATEGORI,LINK) VALUES (@p1,@p2,@p3)", bgl);
            komut.Parameters.AddWithValue("@p1", TxtFilmAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtKategori.Text);
            komut.Parameters.AddWithValue("@p3", TxtLink.Text);
            komut.ExecuteNonQuery();
            bgl.Close();
            MessageBox.Show("Film Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            filmler();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            string link = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            webBrowser1.Navigate(link);
        }

        private void BtnHakkimizda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu Proje Mustafa Batı tarafından 22 Eylül 2020 de kodlandı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        

        private void BtnRenkDegistir_Click(object sender, EventArgs e)
        {
            BackColor = Color.Black;


        }

        private void AcikTema_Click(object sender, EventArgs e)
        {
            BackColor = Color.MediumTurquoise;
        }

        private void BtnTamEkran_Click(object sender, EventArgs e)
        {
            groupBox2.Location = new Point(276,103);
            groupBox2.Size = new Size(1116, 485);

        }
    }
}
