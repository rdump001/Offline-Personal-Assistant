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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button1, "SAVE CONTACT");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            FileStream fs = new FileStream(@"E:\contacts.doc", FileMode.Append, FileAccess.Write, FileShare.Write);
            StreamWriter sw = new StreamWriter(fs);
            string a, b, c, d;
            a = textBox1.Text;
            b = textBox4.Text;
            c = textBox2.Text;
            d = textBox3.Text;
            if (textBox1.Text.Length > 0 && textBox4.Text.Length > 0 && textBox2.Text.Length > 0 && textBox3.Text.Length > 0)
            {
                sw.WriteLine("{0}\t{1}\t{2}\t{3}\t", a, b, c, d);
                sw.Close();
                MessageBox.Show("CONTACT SAVED");
                textBox1.Text = "";
                textBox4.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox1.Focus();
            }
            else
            {
                MessageBox.Show("All fields Must be filled");
                if (textBox1.Text.Length == 0)
                {
                    textBox1.Focus();
                }
                else if (textBox4.Text.Length == 0)
                {
                    textBox4.Focus();
                }
                else if (textBox2.Text.Length == 0)
                {
                    textBox2.Focus();
                }
                else if (textBox3.Text.Length == 0)
                {
                    textBox3.Focus();
                }
                //sw.Close();
                Form3 obj = new Form3();
                obj.Show();
                this.Hide();

            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        /*private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }*/

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

    }
}


