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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        public static int x;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           textBox1.Text = "";
           textBox5.Text= "";
           textBox2.Text= "";
           textBox3.Text= "";
            FileStream ff = new FileStream(@"E:\contacts.doc", FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read);
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
                                textBox5.Text = fields[1];
                                textBox2.Text = fields[2];
                                textBox3.Text = fields[3];
                                textBox1.Text = fields[0];
                                textBox5.Text = fields[1];
                                textBox2.Text = fields[2];
                                textBox3.Text = fields[3];
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
                if (textBox1.Text.Length == 0 && textBox5.Text.Length == 0)
                {
                    MessageBox.Show("No records Found");
                    textBox4.Focus();
                }
            }
            ss.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 obj = new Form3();
            obj.Show();
            this.Hide();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FileStream tr = new FileStream(@"E:\contacts.doc",FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read);
            StreamReader sp = new StreamReader(tr);
            string opq = sp.ReadToEnd();
            if (textBox1.Text.Length > 0 && textBox5.Text.Length > 0)
            {
                if (textBox2.Text.Length > 0 && textBox3.Text.Length > 0)
                {
                    opq = Regex.Replace(opq,textBox1.Text, " ");
                    opq = Regex.Replace(opq, textBox5.Text, " ");
                    opq = Regex.Replace(opq,textBox2.Text, " ");
                    opq = Regex.Replace(opq,textBox3.Text, " ");
                    textBox4.Text = opq;
                    textBox1.Text = "";
                    textBox5.Text = "";
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
            FileStream mn = new FileStream(@"E:\contacts.doc", FileMode.Truncate, FileAccess.Write, FileShare.Write);
            StreamWriter swq = new StreamWriter(mn);
            swq.WriteLine(textBox4.Text);
            swq.Close();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button1, "SEARCH CONTACT");
        }
    }
}
