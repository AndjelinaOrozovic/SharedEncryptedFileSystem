using KriptografijaProjekat.Helper;
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

namespace KriptografijaProjekat.View
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
            hashComboBox.SelectedIndex = 0;
        }

        private void signupButton_Click(object sender, EventArgs e)
        {
            if (!userNameTxtBox.Text.Equals("") && !passwordTxtBox.Text.Equals("") && !confirmPaaswordLbl.Text.Equals(""))
            {
                DirectoryInfo dinf = new DirectoryInfo(Application.StartupPath + "\\Users");
                var files = dinf.GetFiles();
                var directories = dinf.GetDirectories();
                bool fleg = false;
                foreach (var x in files)
                {
                    if ((x.Name.Substring(0, x.Name.LastIndexOf('.'))).Equals(userNameTxtBox.Text))
                    {
                        fleg = true;
                    }
                }
                if (fleg)
                {
                    MessageBox.Show("Username already exists!");
                    userNameTxtBox.Text = "";
                }
                else if (passwordTxtBox.Text.Equals(confirmPasswordTxtBox.Text))
                {
                    try
                    {
                        Functions.executeCommandReturn("/c " + Application.StartupPath + "\\PKI\\" + "generateKeysForUsers.sh " + userNameTxtBox.Text);
                        Functions.executeCommandReturn("/c " + Application.StartupPath + "\\PKI\\" + "genereateCertificate.sh " + userNameTxtBox.Text);
                        String hashSelected = hashComboBox.SelectedItem.ToString();
                        String command = "";
                        if (hashSelected.Equals("MD5"))
                            command = "/c openssl passwd -1 -salt 12345678 " + passwordTxtBox.Text;
                        else if (hashSelected.Equals("SHA-512"))
                            command = "/c openssl passwd -6 -salt 12345678 " + passwordTxtBox.Text;
                        else
                            command = "/c openssl passwd -5 -salt 12345678 " + passwordTxtBox.Text;
                        String passHash = (Functions.executeCommandReturn(command)).Trim();
                        String[] lines = { userNameTxtBox.Text, passHash, hashSelected };
                        File.WriteAllLines(Application.StartupPath + "\\Users\\" + userNameTxtBox.Text + ".txt", lines);
                        Functions.executeCommandReturn("/c " + Application.StartupPath + "\\PKI\\" + "generateCrl.sh");
                        MessageBox.Show("Account is created!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("File is not created!");
                    };
                }
                else
                {
                    MessageBox.Show("Your password and confirmation password do not match.");
                    passwordTxtBox.Text = "";
                    confirmPasswordTxtBox.Text = "";
                }
            }
            else
                MessageBox.Show("Please enter data!");
        }

        private void logInLbl_Click(object sender, EventArgs e)
        {
            SignIn si = new SignIn();
            this.Hide();
            si.ShowDialog();
            this.Close();
        }

    }
}
