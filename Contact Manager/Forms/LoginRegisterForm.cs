using Contact_Manager.Core;
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

namespace Contact_Manager.Forms
{
    public partial class LoginRegisterForm : Form
    {
        User User = 

        public LoginRegisterForm()
        {
            InitializeComponent();
        }

        private void pb_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pb_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {

        }

        private void btn_Upload_Click(object sender, EventArgs e)
        {

        }

        private void btn_Register_Click(object sender, EventArgs e)
        {
            var fName = this.tb_RegisterFirstName.Text;
            var lName = this.tb_RegisterLastName.Text;
            var username = this.tb_RegisterUsername.Text;
            var password = this.tb_RegisterPassword.Text;

            if (this.VerifyFields("register"))
            {
                MemoryStream pic = new MemoryStream();
                pb_Register.Image.Save(pic, pb_Register.Image.RawFormat);

                // check if username already exist

            }
        }

        private void LoginRegisterForm_Load(object sender, EventArgs e)
        {

        }

        public bool VerifyFields(string operation)
        {
            var check = false;

            if(operation == "register")
            {
                if(!this.tb_RegisterUsername.Text.Equals("") || !this.tb_RegisterPassword.Text.Equals("") || !pb_Register.Image == null)
                {
                    check = true;
                }
            }
            else if(operation == "login")
            {
                if(!this.tb_LoginUsername.Text.Equals("") || !this.tb_LoginPassword.Text.Equals(""))
                {
                    check = true;
                }
            }

            return check;
        }
    }
}
