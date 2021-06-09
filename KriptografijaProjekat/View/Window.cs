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
    public partial class Window : Form
    {
        public Window(String userName)
        {
            InitializeComponent();
            Text = userName;
            func(userName);
            FillComboBoxUsers();
        }

        private void addNods(TreeNode tr)
        {
            var home = (DirectoryInfo)tr.Tag;
            var files = home.GetFiles();
            var dirs = home.GetDirectories();
            foreach(var file in files)
            {
                if (!file.FullName.Contains("Shared"))
                {
                    if (!file.Extension.Equals(".key") && !file.Extension.Equals(".sign") && !file.Extension.Equals(".enc") && !file.Extension.Equals(".dec"))
                    {
                        TreeNode tn = new TreeNode()
                        {
                            Text = file.Name,
                            Tag = file
                        };
                        tr.Nodes.Add(tn);
                    }
                } else if(file.Extension.Equals(".enc"))
                {
                    TreeNode tn = new TreeNode()
                    {
                        Text = file.Name,
                        Tag = file
                    };
                    tr.Nodes.Add(tn);
                }
            }
            foreach (var dir in dirs)
            {
                TreeNode tn = new TreeNode()
                {
                    Text = dir.Name,
                    Tag = dir
                };
                tr.Nodes.Add(tn);
                addNods(tn);
            }
        }

        private void func(String username)
        {
            treeViewHome.Nodes.Clear();
            DirectoryInfo dinf = new DirectoryInfo(Application.StartupPath + "\\Users\\" + username);
            TreeNode tn = new TreeNode()
            {
                Text = username,
                Tag = dinf
            };
            treeViewHome.Nodes.Add(tn);
            addNods(tn);
            DirectoryInfo shared = new DirectoryInfo(Application.StartupPath + "\\Shared");
            TreeNode ts = new TreeNode()
            {
                Text = "Shared",
                Tag = shared
            };
            treeViewHome.Nodes.Add(ts);
            addNods(ts);
            treeViewHome.ExpandAll();
        }

        private void treeViewHome_DoubleClick(object sender, EventArgs e)
        {
            var selectedNode = treeViewHome.SelectedNode;
            if(selectedNode != null)
            {
                var x = selectedNode.Tag.GetType();
                if (x == typeof(FileInfo) && !selectedNode.Parent.FullPath.Contains("Shared"))
                {
                    var user = Application.StartupPath + "\\Users\\" + this.Text;
                    var file = (FileInfo)selectedNode.Tag;
                    var fileExtension = file.Extension;
                    var fileNoExtension = file.Name.Substring(0, file.Name.LastIndexOf('.'));
                    var directory = file.Directory;
                    String commandDec = "/c openssl des3 -d -in " + directory + "\\" + fileNoExtension + ".enc -out " + directory + "\\" + fileNoExtension + ".dec -k sigurnost -nosalt -base64";
                    Functions.executeCommandReturn(commandDec);
                    String fileDec = File.ReadAllText(directory + "\\" + fileNoExtension + ".dec");
                    String fileTxt = File.ReadAllText(directory + "\\" + fileNoExtension + fileExtension);
                    String command = "/c openssl dgst -prverify " + user + "\\" + this.Text + ".key" + " -signature " + directory + "\\" + fileNoExtension + ".sign " + directory + "\\" + file.Name;
                    String message = Functions.executeCommandReturn(command).Trim();
                    if (message.Equals("Verified OK") && fileDec.Equals(fileTxt))
                    {
                        Process p = System.Diagnostics.Process.Start(file.FullName);
                    }
                    else MessageBox.Show("File is corrupted");
                }
                else if (treeViewHome.SelectedNode != null && x == typeof(FileInfo) && selectedNode.Parent.FullPath.Contains("Shared"))
                {
                    var file = (FileInfo)selectedNode.Tag;
                    if (!file.Directory.Name.Contains("to-" + this.Text))
                        MessageBox.Show("You can't open file!");
                    else
                    {
                        var choosenFile = file.Name;
                        var user = Application.StartupPath + "\\Users\\" + this.Text;
                        var directory = file.Directory;

                        var fileExtension = File.ReadAllText(directory + "\\extension.ee");

                        if(File.Exists(directory + "\\" + file.Name.Substring(0, file.Name.LastIndexOf('.')) + fileExtension))
                        {
                            File.Delete(directory + "\\" + file.Name.Substring(0, file.Name.LastIndexOf('.')) + fileExtension);
                        }
                        DirectoryInfo dinf = new DirectoryInfo(directory.ToString());
                        var files = dinf.GetFiles();
                        var isDigEnvExists = false;
                        foreach (var f in files)
                        {
                            if (f.FullName.Contains("digEnvelope.txt"))
                                isDigEnvExists = true;
                        }
                        if (choosenFile.Equals("digEnvelope.enc"))
                        {
                            String commandDecDigEnvelope = "/c openssl rsautl -decrypt -in " + file.FullName.ToString() + " -out " + directory + "\\digEnvelope.txt -inkey " + user + "\\" + this.Text + ".key";
                            Functions.executeCommandReturn(commandDecDigEnvelope);
                            var datas = File.ReadAllText(directory + "\\digEnvelope.txt");
                            if (datas.Equals(""))
                            {
                                MessageBox.Show("You can't open original file!");
                                File.Delete(directory + "\\digEnvelope.txt");
                            }
                            else
                            {
                                MessageBox.Show("You can open original file!");
                            }
                        }
                        else if (isDigEnvExists)
                        {
                            var datas = File.ReadAllText(directory + "\\digEnvelope.txt");
                            if (datas.Equals(""))
                                MessageBox.Show("First click on file: \"digEnvelope!\"");
                            else
                            {
                                string[] dataString = datas.Split(' ');
                                String commandDec = "/c openssl " + dataString[0] + " -d -in " + directory + "\\" + choosenFile + " -out " + directory + "\\" + choosenFile.Substring(0, choosenFile.LastIndexOf('.')) + ".dec -k " + dataString[1] + " -nosalt -base64";
                                Functions.executeCommandReturn(commandDec);

                                String messageSender = directory.Name.Split('-')[1];

                                String command = "/c openssl dgst -prverify " + Application.StartupPath + "\\Users\\" + messageSender + "\\" + messageSender + ".key" + " -signature " + directory + "\\" + file.Name.Substring(0, file.Name.LastIndexOf('.')) + ".sign " + directory + "\\" + file.Name.Substring(0, file.Name.LastIndexOf('.')) + ".dec";
                                String message = Functions.executeCommandReturn(command).Trim();
                                if (message.Equals("Verified OK"))
                                {
                                    File.Copy(directory + "\\" + file.Name.Substring(0, file.Name.LastIndexOf('.')) + ".dec", directory + "\\" + file.Name.Substring(0, file.Name.LastIndexOf('.')) + fileExtension);
                                    var fileWithExtension = file.FullName.Substring(0, file.FullName.LastIndexOf('.')) + fileExtension;
                                    Process p = System.Diagnostics.Process.Start(fileWithExtension);
                                }
                                else MessageBox.Show("File is corupted!!!");

                            }

                        }
                        else
                            MessageBox.Show("First click on file: \"digEnvelope.enc\" ");
                    }
                    
                }
                func(this.Text);
            }
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            NewTxtFile file = new NewTxtFile(this.Text);
            file.ShowDialog();
            func(this.Text);
        }

        private void uploadBtn_Click(object sender, EventArgs e)
        {
            var user = Application.StartupPath + "\\Users\\" + this.Text;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (!File.Exists(openFileDialog.FileName))
                    MessageBox.Show("Error! Please choose another file!");
                else
                {
                    FileInfo selectedFile = new FileInfo(openFileDialog.FileName);
                    var selectedFileReplaced = selectedFile.Name.Replace(' ', '_').Replace('#', '_');
                    var selectedFileNoExtension = selectedFile.Name.Substring(0, selectedFile.Name.LastIndexOf('.'));
                    var selectedFileNoExtensionReplaced = selectedFileNoExtension.Replace(' ', '_').Replace('#', '_');
                    string newPath = user + "\\" + selectedFile.Name.Replace(' ', '_').Replace('#', '_');
                    File.Copy(openFileDialog.FileName, newPath);
                    String command = "/c openssl dgst -sign " + user + "\\" + this.Text + ".key" + " -sha256 -out " + user + "\\" + selectedFileNoExtensionReplaced + ".sign " + user + "\\" + selectedFileReplaced;
                    Functions.executeCommandReturn(command);
                    String commandEnc = "/c openssl des3 -in " + user + "\\" + selectedFileReplaced + " -out " + user + "\\" + selectedFileNoExtensionReplaced + ".enc -k sigurnost -nosalt -base64";
                    Functions.executeCommandReturn(commandEnc);
                }
                func(this.Text);
            }
        }

        private void downloadBttn_Click(object sender, EventArgs e)
        {
            var selectedNode = treeViewHome.SelectedNode;
            if (selectedNode != null)
            {
                var x = selectedNode.Tag.GetType();
                if (x == typeof(FileInfo))
                {
                    var file = (FileInfo)selectedNode.Tag;
                    if (file.Extension != ".enc")
                    {
                        var fileNoExtension = file.Name.Substring(0, file.Name.LastIndexOf('.'));
                        var user = Application.StartupPath + "\\Users\\" + this.Text;
                        var directory = file.Directory;
                        String commandDec = "/c openssl des3 -d -in " + directory + "\\" + fileNoExtension + ".enc -out " + directory + "\\" + fileNoExtension + ".dec -k sigurnost -nosalt -base64";
                        Functions.executeCommandReturn(commandDec);
                        String fileDec = File.ReadAllText(directory + "\\" + fileNoExtension + ".dec");
                        String fileReal = File.ReadAllText(directory + "\\" + fileNoExtension + file.Extension);
                        String command = "/c openssl dgst -prverify " + user + "\\" + this.Text + ".key" + " -signature " + directory + "\\" + fileNoExtension + ".sign " + directory + "\\" + file.Name;
                        String message = Functions.executeCommandReturn(command).Trim();
                        if (message.Equals("Verified OK") && fileDec.Equals(fileReal))
                        {
                            try
                            {
                                File.Copy(directory + "\\" + file.Name, "C:\\Users\\andje\\Desktop\\DecryptDownloads\\" + file.Name);
                                MessageBox.Show("File is downloaded!");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("File already exists!");
                            }
                        }
                        else
                            MessageBox.Show("You can't download file! File is corrupted!");
                    }
                    else MessageBox.Show("Please select file from your directory!");
                }
            }
            func(this.Text);
        }

        private void modifyBttn_Click(object sender, EventArgs e)
        {
            var selectedNode = treeViewHome.SelectedNode;
            if (selectedNode != null)
            {
                var x = selectedNode.Tag.GetType();
                if (x == typeof(FileInfo))
                {
                    var file = (FileInfo)selectedNode.Tag;
                    var fileNoExtension = file.Name.Substring(0, file.Name.LastIndexOf('.'));
                    if (file.Extension.Equals(".txt"))
                    {
                        var user = Application.StartupPath + "\\Users\\" + this.Text;
                        var directory = file.Directory;
                        String commandDec = "/c openssl des3 -d -in " + directory + "\\" + fileNoExtension + ".enc -out " + directory + "\\" + fileNoExtension + ".dec -k sigurnost -nosalt -base64";
                        Functions.executeCommandReturn(commandDec);
                        String fileDec = File.ReadAllText(directory + "\\" + fileNoExtension + ".dec");
                        String fileTxt = File.ReadAllText(directory + "\\" + fileNoExtension + ".txt");
                        String command = "/c openssl dgst -prverify " + user + "\\" + this.Text + ".key" + " -signature " + directory + "\\" + fileNoExtension + ".sign " + directory + "\\" + file.Name;
                        String message = Functions.executeCommandReturn(command).Trim();
                        if (message.Equals("Verified OK") && fileDec.Equals(fileTxt))
                        {
                            NewTxtFile uredi = new NewTxtFile(this.Text, fileTxt, fileNoExtension);
                            uredi.ShowDialog();
                        }
                        else MessageBox.Show("File is corrupted");
                    }
                }
            }
            func(this.Text);
        }

        private void treeViewHome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                var x = treeViewHome.SelectedNode.Tag.GetType();
                if (x == typeof(DirectoryInfo))
                {
                    var dirInfo = (DirectoryInfo)treeViewHome.SelectedNode.Tag;
                    var dirName = dirInfo.Name;
                    if (!dirName.Equals(this.Text) && !dirName.Equals("Shared"))
                        return;
                }
                else if (treeViewHome.SelectedNode != null && !treeViewHome.SelectedNode.FullPath.Contains("Shared"))
                {
                        var file = (FileInfo)treeViewHome.SelectedNode.Tag;
                        var fileNoExtension = file.Name.Substring(0, file.Name.LastIndexOf('.'));
                        var directory = file.Directory;
                        DirectoryInfo dinf = new DirectoryInfo(directory.ToString());
                        var files = dinf.GetFiles();
                        foreach (var f in files)
                        {
                            if (f.Name.StartsWith(fileNoExtension))
                                File.Delete(directory + "\\" + f);
                        }
                        treeViewHome.Nodes.Remove(treeViewHome.SelectedNode);
                    func(this.Text);
                }
            }
        }

       void FillComboBoxUsers()
        {
            DirectoryInfo dinf = new DirectoryInfo(Application.StartupPath + "\\Users\\");
            var directories = dinf.GetDirectories();
            List<String> lu = new List<string>();
            foreach(var d in directories)
            {
                if (d.Name != this.Text)
                    lu.Add(d.Name);
            }
            usersComboBox.DataSource = lu;
            if (lu.Count != 0)
                usersComboBox.SelectedIndex = 0;
            else
            {
                sendButton.Visible = false;
                usersComboBox.Visible = false;
            }
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            if (treeViewHome.SelectedNode != null)
            {
                var selectedNode = treeViewHome.SelectedNode;
                var nodeType = selectedNode.Tag.GetType();  /// dodati da mora biti nesto selektovano
                if (nodeType == typeof(FileInfo))
                {
                    if (treeViewHome.SelectedNode != null && usersComboBox.SelectedItem != null && !treeViewHome.SelectedNode.Parent.FullPath.Contains("Shared"))
                    {
                        var file = (FileInfo)selectedNode.Tag;
                        var fileNameForSend = file.Name;
                        string fileExtension = file.Extension;
                        var fileNoExtension = fileNameForSend.Substring(0, fileNameForSend.LastIndexOf('.'));
                        var userReceiver = usersComboBox.SelectedItem.ToString();
                        var user = Application.StartupPath + "\\Users\\" + this.Text;
                        var directory = file.Directory;
                        var validityDate = CertificateCheck.isCertificateValidDate(Application.StartupPath + "\\PKI\\certs\\" + userReceiver + ".pem");
                        var validityCrl = CertificateCheck.isCertificateValidCrl(Application.StartupPath + "\\PKI\\certs\\" + userReceiver + ".pem");
                        var validityCaTrusted = CertificateCheck.isCATrusted(Application.StartupPath + "\\OKI\\certs\\" + userReceiver + ".pem");
                        if (validityDate && validityCrl && validityCaTrusted)
                        {

                            String commandDec = "/c openssl des3 -d -in " + directory + "\\" + fileNoExtension + ".enc -out " + directory + "\\" + fileNoExtension + ".dec -k sigurnost -nosalt -base64";
                            Functions.executeCommandReturn(commandDec);
                            String fileDec = File.ReadAllText(directory + "\\" + fileNoExtension + ".dec"); //ne postoji ako ne otvorimo fajl bar jednom, nakon sto ga sacuvamo
                            String fileReal = File.ReadAllText(directory + "\\" + fileNoExtension + file.Extension);
                            String command = "/c openssl dgst -prverify " + user + "\\" + this.Text + ".key" + " -signature " + directory + "\\" + fileNoExtension + ".sign " + directory + "\\" + file.Name;
                            String message = Functions.executeCommandReturn(command).Trim();
                            if (message.Equals("Verified OK") && fileDec.Equals(fileReal))
                            {
                                string sending = "from-" + this.Text + "-to-" + userReceiver + DateTime.Now.ToString().Replace(':', '-').Replace(' ', '-').Replace('/', '-');
                                Directory.CreateDirectory(directory + "\\" + sending);
                                String commandEnc = "/c openssl chacha20 -in " + user + "\\" + file + " -out " + user + "\\" + sending + "\\" + fileNoExtension + ".enc -k sigurnost -nosalt -base64"; //enkriptovan original
                                Functions.executeCommandReturn(commandEnc);
                                File.Copy(directory + "\\" + fileNoExtension + ".sign", directory + "\\" + sending + "\\" + fileNoExtension + ".sign"); //prosljedjen potpis
                                File.WriteAllText(directory + "\\" + sending + "\\digEnvelope.txt", "chacha20 sigurnost"); //pravljenje digitalne envelope
                                String commandPubKey = "/c openssl rsa -in " + directory.Parent.FullName + "\\" + userReceiver + "\\" + userReceiver + ".key -pubout -out " + directory + "\\" + sending + "\\pub.key"; //izdvajanje javnog kljuca
                                Functions.executeCommandReturn(commandPubKey);
                                String commandCriptWithPubKey = "/c openssl rsautl -encrypt -in " + directory + "\\" + sending + "\\digEnvelope.txt -out " + directory + "\\" + sending + "\\digEnvelope.enc -inkey " + directory + "\\" + sending + "\\pub.key -pubin"; //kriptovanje digitalne envelope javnim kljucem primaoca
                                Functions.executeCommandReturn(commandCriptWithPubKey);
                                File.Delete(directory + "\\" + sending + "\\pub.key");
                                File.Delete(directory + "\\" + sending + "\\digEnvelope.txt");
                                Directory.Move(directory + "\\" + sending, Application.StartupPath + "\\Shared\\" + sending);
                                File.WriteAllText(Application.StartupPath + "\\Shared\\" + sending + "\\extension.ee", fileExtension);
                                func(this.Text);
                            }
                            else
                            {
                                MessageBox.Show("File is corrupted! Please select another one!");
                            }
                        }
                        else MessageBox.Show("User certificate is not valid! Plesa try again later.");
                    }
                    else MessageBox.Show("Please select file from your directory!");
                }
                else MessageBox.Show("Please select file for seding!");
            } else MessageBox.Show("Please select file from your directory!");
        }
    }
}