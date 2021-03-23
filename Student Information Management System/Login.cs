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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        MySqlConnection con = new MySqlConnection(@"server= localhost; user name= root; database= sims");

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
            con.Open();

            string username, password;
            username = textBox1.Text;
            password = textBox2.Text;
            MySqlCommand cmd = new MySqlCommand("select username, password from login where username='" + textBox1.Text + "' and password='" + textBox2.Text + "'", con);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                this.Hide();
                Main ss = new Main();
                ss.Show();     
            }
            else
            {
                MessageBox.Show("Invalid username or password! Please try Again");
            }
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox1.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ForgetPass ss = new ForgetPass();
            ss.Show();
        }
    }
}
