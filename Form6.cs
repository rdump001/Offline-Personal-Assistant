using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace WindowsFormsApplication1
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            FileStream fs = new FileStream(@"E:\meetings.txt", FileMode.Append, FileAccess.Write, FileShare.Write);
            StreamWriter sw = new StreamWriter(fs);
            string a, b, c, d,f;
            a = textBox1.Text;
            b = dateTimePicker1.Text;
            c = dateTimePicker2.Text;
            d = textBox2.Text;
            f = textBox3.Text;
            if (textBox1.Text.Length > 0 && dateTimePicker1.Text.Length > 0 && dateTimePicker2.Text.Length > 0 && textBox2.Text.Length > 0 && textBox3.Text.Length > 0)
            {
                sw.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t", a, b, c, d, f);
                sw.Close();
                MessageBox.Show("MEETING SAVED");
                textBox1.Text = "";
                dateTimePicker1.Text = "";
                dateTimePicker2.Text = "";
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
                else if (dateTimePicker1.Text.Length == 0)
                {
                    dateTimePicker1.Focus();
                }
                else if (dateTimePicker2.Text.Length == 0)
                {
                    dateTimePicker2.Focus();
                }
                else if (textBox2.Text.Length == 0)
                {
                    textBox2.Focus();
                }
                else if (textBox3.Text.Length == 0)
                {
                    textBox3.Focus();
                }

            }
            Form7 obj = new Form7();
            obj.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 obj = new Form7();
            obj.Show();
            this.Hide();
        }

        private void Form6_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

       /* private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }*/

        private void Form6_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button1, "SAVE MEETING");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}