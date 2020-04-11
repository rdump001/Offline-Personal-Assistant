using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 obj = new Form3();
            obj.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 obj = new Form7();
            obj.Show();
            this.Hide();
        }
        /*private void Form2_Load(object sender, EventArgs e)
        {
           DialogResult dr = MessageBox.Show("WANT TO EXIT THIS APPLICATION", "CLOSING", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
           if (dr == DialogResult.Yes)
           {
               this.Close();
           }
           else
           {
               this.Activate();
           }*/

       /* private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("WANT TO EXIT THIS APPLICATION", "CLOSING", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                this.Activate();
            }
        }*/

        private void Form2_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button1, "CONTACTS");
            toolTip2.SetToolTip(button2, "MEETINGS");
            toolTip3.SetToolTip(button3, "BROWSER");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form9 obj = new Form9();
            obj.Show();
            this.Hide();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to Exit this application ?", "CONTACT DETAILS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            if (dr == DialogResult.No)
            {
                e.Cancel = true;
            }


        }
    }
}
