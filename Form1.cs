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

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public string s1, s2;
        int ctr;
        public string s;
        public string s11;
        

        public Form1()
        {
            InitializeComponent();
        }

       /* public Form1(string p)
        {
            // TODO: Complete member initialization
            txtUsername.Text = p.ToString();
        }

        public Form1(string s, string s11)
        {
            // TODO: Complete member initialization
            this.s = s;
            this.s11 = s11;
            Display();
        
        }
        public void Display()
        {
            txtUsername.Text = s;
            txtPassword.Text = s11;

        }

       /* public Form1(string s1, string s2)
        {
            // TODO: Complete member initialization
            this.s1 = s1;
            this.s2 = s2;
            txtUsername.Text = s1;
            txtPassword.Text = s2;

        }*/

        private void cmdlogin_Click(object sender, EventArgs e)
        {
            string Password;
            //Loginname = txtUsername.Text;
            Password = txtPassword.Text;
            ctr = ctr + 1;
            if (Password=="pass" )
            {
                Form2 obj = new Form2();
                obj.Show();
                this.Hide();
            }
            else if (ctr < 3)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "please enter valid username or password";
                txtPassword.Focus();
            }
            else
            {
                MessageBox.Show("THE ENTERED DETAILS ARE NOT VALID ... ACCESS DENIED","DATA ENTERY ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                Close();
            }
        }

        private void lblMessage_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(cmdlogin, "LOGIN");
        }

        
    }
}
