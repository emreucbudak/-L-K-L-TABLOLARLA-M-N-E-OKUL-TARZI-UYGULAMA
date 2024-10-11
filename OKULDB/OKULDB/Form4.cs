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

namespace OKULDB
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=emre\MSSQLSERVER01;Initial Catalog=OkulBonus;Integrated Security=True;Encrypt=False");
        void listele ()
        {
            SqlDataAdapter adapt = new SqlDataAdapter("Select * from KULUP",conn);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand komutekle = new SqlCommand("INSERT INTO KULUP (KULUPAD) values (@p1)",conn);
            komutekle.Parameters.AddWithValue("@p1", textBox2.Text);
            komutekle.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Kulüp Başarıyla Eklendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand komutekle = new SqlCommand("update KULUP SET KULUPAD = @a1  where KULUPID = @a2", conn);
            komutekle.Parameters.AddWithValue("@a1", textBox2.Text);
            komutekle.Parameters.AddWithValue("@a2", textBox1.Text);
            komutekle.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Kulüp Başarıyla Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand komutekle = new SqlCommand("delete from KULUP where KULUPAD = @b1", conn);
            komutekle.Parameters.AddWithValue("@b1", textBox2.Text);
            komutekle.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Kulüp Başarıyla Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Eğer baştaki kulüpleri silmek istersen öğrencileride silmen gerek uğraşmak istemedim mantığı önemli!
        }
    }
}
