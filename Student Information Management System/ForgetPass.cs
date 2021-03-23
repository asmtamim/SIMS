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
    public partial class ForgetPass : Form
    {
        public ForgetPass()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(@"server= localhost; user name= root; database= sims");
            con.Open();

            MySqlCommand cmd = new MySqlCommand("UPDATE `login` SET `password` = '" + textBox2.Text + "' WHERE `username`=('" + textBox1.Text + "')", con);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Password Updated.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.Close();
        }
    }
}
