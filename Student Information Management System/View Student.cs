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
using DGVPrinterHelper;

namespace Student_Information_Management_System
{
    public partial class View_Student: Form
    {
        int x = 255, y = 1;
        public View_Student()
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Main ss = new Main();
            // ss.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(@"server= localhost; user name= root; database= sims");
            con.Open();

            MySqlDataAdapter mySqlData = new MySqlDataAdapter("SELECT * FROM `student` WHERE `ID`=('" + textBox1.Text + "')", con);
            DataTable dtb = new DataTable(); //ID, Student_Name, Birthday, Gender, Email, Department, Year, Image

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 80;

            mySqlData.Fill(dtb);
            dataGridView1.DataSource = dtb;

            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)dataGridView1.Columns[10];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;

            mySqlData.Dispose();
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(@"server= localhost; user name= root; database= sims");
            con.Open();
            MySqlDataAdapter mySqlData = new MySqlDataAdapter("SELECT ID, Student_Name, Birthday, Gender, Email, Department, Year, Image FROM `student` WHERE `Year`=('" + comboBox2.Text + "')", con);
            DataTable dtb = new DataTable(); //ID, Student_Name, Birthday, Gender, Email, Department, Year, Image

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 80;

            mySqlData.Fill(dtb);
            dataGridView1.DataSource = dtb;

            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)dataGridView1.Columns[07];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;

            mySqlData.Dispose();
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(@"server= localhost; user name= root; database= sims");
            con.Open();
            MySqlDataAdapter mySqlData = new MySqlDataAdapter("SELECT ID, Student_Name, Birthday, Gender, Email, Department, Year, Image FROM `student` WHERE `Department`=('" + comboBox1.Text + "')", con);
            DataTable dtb = new DataTable(); //ID, Student_Name, Birthday, Gender, Email, Department, Year, Image

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height =70;

            mySqlData.Fill(dtb);
            dataGridView1.DataSource = dtb;

            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)dataGridView1.Columns[07];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;

            mySqlData.Dispose();
            con.Close();
        }

        Bitmap bm;
        private void button3_Click(object sender, EventArgs e)
        {
            /*
            int height = dataGridView1.Height;
            dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 2;
            bm = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(bm, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
            dataGridView1.Height = height;
            printDocument1.DefaultPageSettings.Landscape = true;
            printPreviewDialog1.ShowDialog();
            */

            
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Student Information"; //Report name
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true; 
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "SIMS"; 
            printer.FooterSpacing = 9;
            printer.printDocument.DefaultPageSettings.Landscape = true;
            printer.PrintDataGridView(dataGridView1);
            
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // e.Graphics.DrawImage(bm, 0, 0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.SetBounds(x,y,1,1);
            x++;
            if (x>=1200) { x = 1; }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void View_Student_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1;
            timer1.Start();
        }
    }
}
