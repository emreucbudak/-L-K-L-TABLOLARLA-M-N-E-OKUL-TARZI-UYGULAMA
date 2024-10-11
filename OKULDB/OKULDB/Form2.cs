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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public string numara;
        SqlConnection conn = new SqlConnection(@"Data Source=emre\MSSQLSERVER01;Initial Catalog=OkulBonus;Integrated Security=True;Encrypt=False");
        private void Form2_Load(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand komut = new SqlCommand("Select * from TBL_NOTLAR INNER JOIN DERSLER ON TBL_NOTLAR.DERSID = DERSLER.DERSID  where OGRID = @k1", conn);
            komut.Parameters.AddWithValue("@k1", numara);
            SqlDataAdapter adapter = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();

        }
    }
}
