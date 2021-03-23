using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Student_Information_Management_System
{
    public partial class Statics : Form
    {
        public Statics()
        {
            InitializeComponent();
            comboBox1.Items.Add("CSE");
            comboBox1.Items.Add("EEE");
            comboBox1.Items.Add("TEX");

            comboBox2.Items.Add("1st");
            comboBox2.Items.Add("2nd");
            comboBox2.Items.Add("3rd");
            comboBox2.Items.Add("4th");
        }
        MySqlConnection con = new MySqlConnection(@"server= localhost; user name= root; database= sims");

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Main ss = new Main();
            // ss.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(@"server= localhost; user name= root; database= sims");
            con.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(ID) FROM student", con);

            Int32 count1 = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();

            label3.Text = count1.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(@"server= localhost; user name= root; database= sims");
            con.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(ID) FROM student WHERE Gender = 'Male'", con);

            Int32 count2 = Convert.ToInt32(cmd.ExecuteScalar());  
            con.Close();

            label2.Text = count2.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(@"server= localhost; user name= root; database= sims");
            con.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(ID) FROM student WHERE Gender = 'Female'", con);

            Int32 count3 = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();

            label4.Text = count3.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(@"server= localhost; user name= root; database= sims");
            con.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(ID) FROM student WHERE Department =('"+comboBox1.Text+"')", con);

            Int32 count4 = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();

            label6.Text = count4.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(@"server= localhost; user name= root; database= sims");
            con.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(ID) FROM student WHERE Year =('"+comboBox2.Text+"')", con);

            Int32 count5 = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();

            label7.Text = count5.ToString();
        }

        private void Statics_Load(object sender, EventArgs e)
        {

        }
    }
}
