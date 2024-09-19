using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace WindowsFormsApp44
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

            string connectionString = "User Id=NORTHWIND;Password=dbhunter;Data Source=localhost:1521/orclpdb";
            OracleConnection conn = new OracleConnection(connectionString);
            
            OracleCommand command = new OracleCommand("SELECT * FROM Categories", conn);
            conn.Open();
            OracleDataReader okuyucu = command.ExecuteReader();
            comboBox1.DisplayMember = "Category_Name";
            comboBox1.ValueMember = "Category_ID";

            List<Category> liste = new List<Category>();
            while (okuyucu.Read())
            {
                Category c = new Category();
                c.Category_ID = okuyucu.GetInt32(okuyucu.GetOrdinal("Category_ID"));
                c.Category_Name = okuyucu.GetString(okuyucu.GetOrdinal("Category_Name"));
                liste.Add(c);
            }
            conn.Close();
            comboBox1.DataSource = liste;
        }
        public void databaseIslemleri(string connection)
        {
            
            
        }
    }
}
