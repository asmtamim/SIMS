using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Information_Management_System
{
    public partial class Main : Form
    {
        int x = 255, y = 1;
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login ss = new Login();
            ss.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // this.Hide();
            Add_Student ss = new Add_Student();
            ss.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // this.Hide();
            View_Student ss = new View_Student();
            ss.Show();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            // this.Hide();
            Statics ss = new Statics();
            ss.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // this.Hide();
            Update ss = new Update();
            ss.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1;
            timer1.Start();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.SetBounds(x, y, 1, 1);
            x++;
            if (x >= 1200) { x = 1; }
        }
    }
}
