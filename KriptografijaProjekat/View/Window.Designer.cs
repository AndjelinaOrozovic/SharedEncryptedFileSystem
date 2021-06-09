
namespace KriptografijaProjekat.View
{
    partial class Window
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.treeViewHome = new System.Windows.Forms.TreeView();
            this.uploadBtn = new System.Windows.Forms.Button();
            this.createBtn = new System.Windows.Forms.Button();
            this.modifyBttn = new System.Windows.Forms.Button();
            this.downloadBttn = new System.Windows.Forms.Button();
            this.sendButton = new System.Windows.Forms.Button();
            this.usersComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // treeViewHome
            // 
            this.treeViewHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewHome.Location = new System.Drawing.Point(1, 39);
            this.treeViewHome.Name = "treeViewHome";
            this.treeViewHome.Size = new System.Drawing.Size(442, 465);
            this.treeViewHome.TabIndex = 0;
            this.treeViewHome.DoubleClick += new System.EventHandler(this.treeViewHome_DoubleClick);
            this.treeViewHome.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeViewHome_KeyDown);
            // 
            // uploadBtn
            // 
            this.uploadBtn.Location = new System.Drawing.Point(225, 6);
            this.uploadBtn.Name = "uploadBtn";
            this.uploadBtn.Size = new System.Drawing.Size(106, 29);
            this.uploadBtn.TabIndex = 2;
            this.uploadBtn.Text = "Upload";
            this.uploadBtn.UseVisualStyleBackColor = true;
            this.uploadBtn.Click += new System.EventHandler(this.uploadBtn_Click);
            // 
            // createBtn
            // 
            this.createBtn.Location = new System.Drawing.Point(1, 6);
            this.createBtn.Name = "createBtn";
            this.createBtn.Size = new System.Drawing.Size(106, 29);
            this.createBtn.TabIndex = 0;
            this.createBtn.Text = "New";
            this.createBtn.UseVisualStyleBackColor = true;
            this.createBtn.Click += new System.EventHandler(this.createBtn_Click);
            // 
            // modifyBttn
            // 
            this.modifyBttn.Location = new System.Drawing.Point(113, 6);
            this.modifyBttn.Name = "modifyBttn";
            this.modifyBttn.Size = new System.Drawing.Size(106, 29);
            this.modifyBttn.TabIndex = 1;
            this.modifyBttn.Text = "Modify";
            this.modifyBttn.UseVisualStyleBackColor = true;
            this.modifyBttn.Click += new System.EventHandler(this.modifyBttn_Click);
            // 
            // downloadBttn
            // 
            this.downloadBttn.Location = new System.Drawing.Point(337, 6);
            this.downloadBttn.Name = "downloadBttn";
            this.downloadBttn.Size = new System.Drawing.Size(106, 29);
            this.downloadBttn.TabIndex = 3;
            this.downloadBttn.Text = "Download";
            this.downloadBttn.UseVisualStyleBackColor = true;
            this.downloadBttn.Click += new System.EventHandler(this.downloadBttn_Click);
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(504, 6);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(129, 29);
            this.sendButton.TabIndex = 4;
            this.sendButton.Text = "Send to";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // usersComboBox
            // 
            this.usersComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usersComboBox.FormattingEnabled = true;
            this.usersComboBox.Location = new System.Drawing.Point(639, 7);
            this.usersComboBox.Name = "usersComboBox";
            this.usersComboBox.Size = new System.Drawing.Size(129, 26);
            this.usersComboBox.TabIndex = 5;
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = global::KriptografijaProjekat.Properties.Resources.breach;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(867, 534);
            this.Controls.Add(this.usersComboBox);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.downloadBttn);
            this.Controls.Add(this.modifyBttn);
            this.Controls.Add(this.createBtn);
            this.Controls.Add(this.uploadBtn);
            this.Controls.Add(this.treeViewHome);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "Window";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Window";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewHome;
        private System.Windows.Forms.Button uploadBtn;
        private System.Windows.Forms.Button createBtn;
        private System.Windows.Forms.Button modifyBttn;
        private System.Windows.Forms.Button downloadBttn;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.ComboBox usersComboBox;
    }
}