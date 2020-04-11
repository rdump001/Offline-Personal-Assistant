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
    public partial class Form10 : Form
    {
        int x;
        public Form10()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox4.Focus();
            textBox1.Text = "";
            dateTimePicker1.Text = "";
            dateTimePicker1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            FileStream ff = new FileStream(@"E:\meetings.txt", FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read);
            StreamReader ss = new StreamReader(ff);
            if (textBox4.Text.Length > 0)
            {
                while (!ss.EndOfStream)
                {
                    string line = ss.ReadLine();
                    string[] fields = line.Split('\t');

                    foreach (string s in fields)
                    {
                        if (textBox4.Text.Length > 0)
                        {
                            if (s.Equals(textBox4.Text))
                            {
                                x = Convert.ToInt32(s.Equals(textBox4.Text));
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
                                MessageBox.Show("NAME = " + fields[0] + "\n" + "From Date = " + fields[1] + "\n" + "To Date = " + fields[2] + "\n" + "Where = " + fields[3] + "\n" + "Description = " + fields[3]);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Enter a Name ");
                textBox4.Focus();
            }
            if (textBox4.Text.Length > 0)
            {
                if (textBox1.Text.Length == 0 && dateTimePicker1.Text.Length == 0)
                {
                    MessageBox.Show("No records Found");
                    textBox4.Focus();
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
                    textBox4.Text = opq;
                    textBox1.Text = "";
                    dateTimePicker1.Text = "";
                    dateTimePicker2.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Focus();
                    sp.Close();
                    MessageBox.Show("Reocrd deleted");
                    update();
                    textBox4.Text = " ";
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
            swq.WriteLine(textBox4.Text);
            swq.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 obj = new Form7();
            obj.Show();
            this.Hide();
        }
    }
}

