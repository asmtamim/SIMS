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
using System.IO;

namespace Student_Information_Management_System
{
    public partial class Add_Student : Form
    {
        public static int id = 0;
        public void Seter()
        {
            textBox1.Text = id.ToString();
        }
        public Add_Student()
        {
            InitializeComponent();
            comboBox2.Items.Add("CSE");
            comboBox2.Items.Add("EEE");
            comboBox2.Items.Add("TEX");

            comboBox1.Items.Add("1st");
            comboBox1.Items.Add("2nd");
            comboBox1.Items.Add("3rd");
            comboBox1.Items.Add("4th");
        }
        string Gender;

        MySqlConnection con = new MySqlConnection(@"server= localhost; user name= root; database= sims");

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Main ss = new Main();
            // ss.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(@"server= localhost; user name= root; database= sims");
            con.Open();

            MySqlCommand cmd = new MySqlCommand("UPDATE `student` SET `Phone` = '" + textBox8.Text + "',`Email`='" + textBox9.Text + "',`Address`='" + richTextBox2.Text + "',`Department`='" + comboBox2.Text + "',`Year`='" + comboBox1.Text + "' WHERE `ID`=('" + textBox1.Text + "')", con);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Update Successful.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Add_Student page = new Add_Student();
            page.Refresh();
            this.Hide();
            page.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files(*.jpg; *.png) | *.jpg; *.png";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox4.Text = dialog.FileName;
                pictureBox1.Image = new Bitmap(dialog.FileName);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
            MySqlConnection con = new MySqlConnection(@"server= localhost; user name= root; database= sims");
            con.Open();

            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            byte[] img = ms.ToArray();

            MySqlCommand cmd = new MySqlCommand("INSERT INTO `student`(`ID`, `Student_Name`, `Father_Name`, `Birthday`, `Gender`, `Phone`, `Email`, `Address`, `Department`, `Year`, `Image`) VALUES ('" + textBox1.Text+ "','" + textBox2.Text + "','" + textBox3.Text + "','" + dateTimePicker1.Text + "', '"+Gender+"','" + textBox8.Text + "','" + textBox9.Text + "','" + richTextBox2.Text + "','" + comboBox2.Text + "','" + comboBox1.Text + "',@IMG)", con);
            cmd.Parameters.Add("@IMG", MySqlDbType.LongBlob);
            cmd.Parameters["@IMG"].Value = img;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Save Successful.","Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Gender = "Male";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Gender = "Female";
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Add_Student_Load(object sender, EventArgs e)
        {

        }
    }
}
