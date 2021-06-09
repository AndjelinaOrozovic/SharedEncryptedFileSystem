using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KriptografijaProjekat.Helper;

namespace KriptografijaProjekat.View
{
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void signinButton_Click(object sender, EventArgs e)
        {
            if (!userNameTxtBox.Text.Equals("") && !passwordTxtBox.Text.Equals(""))
            {
                DirectoryInfo dinf = new DirectoryInfo(Application.StartupPath + "\\Users\\");
                var files = dinf.GetFiles();
                var directories = dinf.GetDirectories();
                bool fleg = false;
                foreach (var x in files)
                {
                    var userNameExists = (x.Name.Substring(0, x.Name.LastIndexOf('.'))).Equals(userNameTxtBox.Text);
                    if (userNameExists)
                        fleg = true;
                }
                if (fleg)
                {
                    var validityDate = false;
                    var validityCrl = false;
                    String command = "";
                    String[] list = File.ReadAllLines(Application.StartupPath + "\\Users\\" + userNameTxtBox.Text + ".txt");
                    if (list[2].Equals("MD5"))
                        command = "/c openssl passwd -1 -salt 12345678 " + passwordTxtBox.Text;
                    else if (list[2].Equals("SHA-512"))
                        command = "/c openssl passwd -6 -salt 12345678 " + passwordTxtBox.Text;
                    else
                        command = "/c openssl passwd -5 -salt 12345678 " + passwordTxtBox.Text;
                    String passHash = (Functions.executeCommandReturn(command)).Trim();
                    var passExists = passHash.Equals(list[1]);
                    if (passExists)
                    {
                        validityDate = CertificateCheck.isCertificateValidDate(Application.StartupPath + "\\PKI\\certs\\" + userNameTxtBox.Text + ".pem");
                        validityCrl = CertificateCheck.isCertificateValidCrl(Application.StartupPath + "\\PKI\\certs\\" + userNameTxtBox.Text + ".pem");
                        if (validityDate && validityCrl)
                        {
                            Window w = new Window(userNameTxtBox.Text);
                            passwordTxtBox.Text = "";
                            userNameTxtBox.Text = "";
                            w.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Not valid certificate!");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Wrong password!");
                        passwordTxtBox.Text = "";
                    }

                }
                else
                {
                    MessageBox.Show("Username doesn't exists!");
                    userNameTxtBox.Text = "";
                }
            }
            else
                MessageBox.Show("Please enter data!");
        }

    }
}
