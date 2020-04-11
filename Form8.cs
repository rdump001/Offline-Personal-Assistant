using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form8 : Form
    {
        int x;
        public Form8()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dateTimePicker3.Focus();
            textBox1.Text = "";
            dateTimePicker1.Text = "";
            dateTimePicker1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            FileStream ff = new FileStream(@"E:\meetings.txt", FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read);
            StreamReader ss = new StreamReader(ff);
            if (dateTimePicker3.Text.Length > 0)
            {
                while (!ss.EndOfStream)
                {
                    string line = ss.ReadLine();
                    string[] fields = line.Split('\t');

                    foreach (string s in fields)
                    {
                        if (dateTimePicker3.Text.Length > 0)
                        {
                            if (s.Equals(dateTimePicker3.Text))
                            {
                                x = Convert.ToInt32(s.Equals(dateTimePicker3.Text));
                                textBox1.Text = fields[0];
                                dateTimePicker1.Text = fields[1];
                                dateTimePicker2.Text = fields[2];
                                textBox2.Text = fields[3];
                                textBox3.Text = fields[4];
                                textBox1.Text = fields[0];
                                dateTimePicker1.Text = fields[1];
                                dateTimePicker2.Text = fields[2];
                                textBox2.Text = fields[3];
                                textBox3.Text = fields[4];
                                MessageBox.Show("NAME = " + fields[0] + "\n" + "From Date = " + fields[1] + "\n" + "To Date = " + fields[2] + "\n" + "Where = " + fields[3]+ "\n" + "Description = " + fields[3]);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Enter a Name ");
                dateTimePicker3.Focus();
            }
            if (dateTimePicker3.Text.Length > 0)
            {
                if (textBox1.Text.Length == 0 && dateTimePicker1.Text.Length == 0)
                {
                    MessageBox.Show("No records Found");
                    dateTimePicker3.Focus();
                }
            }
            ss.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FileStream tr = new FileStream(@"E:\meetings.txt", FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read);
            StreamReader sp = new StreamReader(tr);
            string opq = sp.ReadToEnd();
            if (textBox1.Text.Length > 0 && dateTimePicker1.Text.Length > 0 && dateTimePicker2.Text.Length > 0)
            {
                if (textBox2.Text.Length > 0 && textBox3.Text.Length > 0)
                {
                    opq = Regex.Replace(opq, textBox1.Text, " ");
                    opq = Regex.Replace(opq, dateTimePicker1.Text, " ");
                    opq = Regex.Replace(opq, dateTimePicker2.Text, " ");
                    opq = Regex.Replace(opq, textBox2.Text, " ");
                    opq = Regex.Replace(opq, textBox3.Text, " ");
                    dateTimePicker3.Text = opq;
                    textBox1.Text = "";
                    dateTimePicker1.Text = "";
                    dateTimePicker2.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    dateTimePicker3.Focus();
                    sp.Close();
                    MessageBox.Show("Reocrd deleted");
                    update();
                    dateTimePicker3.Text = " ";
                }
            }
            else
            {
                MessageBox.Show("Nothing to delete");
            }
        }
        public void update()
        {
            FileStream mn = new FileStream(@"E:\meetings.txt", FileMode.Truncate, FileAccess.Write, FileShare.Write);
            StreamWriter swq = new StreamWriter(mn);
            swq.WriteLine(dateTimePicker3.Text);
            swq.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 obj = new Form7();
            obj.Show();
            this.Hide();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button1, "SEARCH MEETING");
            toolTip2.SetToolTip(dateTimePicker3, "SELECT DATE TO SEARCH");
        }
    }
}

