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
    public partial class Update : Form
    {
        public Update()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Main ss = new Main();
            // ss.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Add_Student ss = new Add_Student();
            Add_Student.id =Convert.ToInt32(textBox1.Text);
            ss.Seter();
            ss.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(@"server= localhost; user name= root; database= sims");
            con.Open();

            MySqlCommand cmd = new MySqlCommand("DELETE FROM `student` WHERE `ID` = ('"+textBox2.Text+"')", con);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Delete Successful.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }
    }
}
