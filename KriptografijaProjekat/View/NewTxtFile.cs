using KriptografijaProjekat.Helper;
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

namespace KriptografijaProjekat.View
{
    public partial class NewTxtFile : Form
    {
        public NewTxtFile(String user)
        {
            InitializeComponent();
            Text = user;
        }

        public NewTxtFile(String user, String content, String txtName)
        {
            InitializeComponent();
            Text = user;
            contentTxtBox.Text = content;
            nameTxtBox.Text = txtName;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (!contentTxtBox.Text.Equals("") && !nameTxtBox.Text.Equals(""))
            {
                string user = Application.StartupPath + "\\Users\\" + this.Text;
                string userDoc = user + "\\" + nameTxtBox.Text + ".txt";
                string userDocNoExtension = userDoc.Substring(0, userDoc.LastIndexOf('.'));
                TextWriter txt = new StreamWriter(userDoc);
                txt.Write(contentTxtBox.Text);
                txt.Close();
                String command = "/c openssl dgst -sign " + user + "\\" + this.Text + ".key" + " -sha256 -out " + userDocNoExtension + ".sign " + userDoc;
                Functions.executeCommandReturn(command);
                String commandEnc = "/c openssl des3 -in " + userDoc + " -out " + userDocNoExtension + ".enc -k sigurnost -nosalt -base64";
                Functions.executeCommandReturn(commandEnc);
                this.Close();
            }
            else
                MessageBox.Show("Please enter data!");
        }
    }
}
