
namespace KriptografijaProjekat.View
{
    partial class Registration
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
            this.userNamelbl = new System.Windows.Forms.Label();
            this.passwordLbl = new System.Windows.Forms.Label();
            this.userNameTxtBox = new System.Windows.Forms.TextBox();
            this.passwordTxtBox = new System.Windows.Forms.TextBox();
            this.signupButton = new System.Windows.Forms.Button();
            this.confirmPaaswordLbl = new System.Windows.Forms.Label();
            this.confirmPasswordTxtBox = new System.Windows.Forms.TextBox();
            this.logInLbl = new System.Windows.Forms.Label();
            this.hashComboBox = new System.Windows.Forms.ComboBox();
            this.hashLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // userNamelbl
            // 
            this.userNamelbl.AutoSize = true;
            this.userNamelbl.BackColor = System.Drawing.Color.Transparent;
            this.userNamelbl.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userNamelbl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.userNamelbl.Location = new System.Drawing.Point(214, 70);
            this.userNamelbl.Name = "userNamelbl";
            this.userNamelbl.Size = new System.Drawing.Size(129, 24);
            this.userNamelbl.TabIndex = 0;
            this.userNamelbl.Text = "USERNAME:";
            // 
            // passwordLbl
            // 
            this.passwordLbl.AutoSize = true;
            this.passwordLbl.BackColor = System.Drawing.Color.Transparent;
            this.passwordLbl.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLbl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.passwordLbl.Location = new System.Drawing.Point(215, 144);
            this.passwordLbl.Name = "passwordLbl";
            this.passwordLbl.Size = new System.Drawing.Size(128, 24);
            this.passwordLbl.TabIndex = 1;
            this.passwordLbl.Text = "PASSWORD:";
            // 
            // userNameTxtBox
            // 
            this.userNameTxtBox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userNameTxtBox.Location = new System.Drawing.Point(220, 97);
            this.userNameTxtBox.Name = "userNameTxtBox";
            this.userNameTxtBox.Size = new System.Drawing.Size(224, 31);
            this.userNameTxtBox.TabIndex = 0;
            // 
            // passwordTxtBox
            // 
            this.passwordTxtBox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTxtBox.Location = new System.Drawing.Point(218, 171);
            this.passwordTxtBox.Name = "passwordTxtBox";
            this.passwordTxtBox.PasswordChar = '*';
            this.passwordTxtBox.Size = new System.Drawing.Size(226, 31);
            this.passwordTxtBox.TabIndex = 1;
            this.passwordTxtBox.UseSystemPasswordChar = true;
            // 
            // signupButton
            // 
            this.signupButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.signupButton.Font = new System.Drawing.Font("Stencil", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signupButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.signupButton.Location = new System.Drawing.Point(217, 352);
            this.signupButton.Name = "signupButton";
            this.signupButton.Size = new System.Drawing.Size(227, 31);
            this.signupButton.TabIndex = 4;
            this.signupButton.Text = "SIGN UP";
            this.signupButton.UseVisualStyleBackColor = false;
            this.signupButton.Click += new System.EventHandler(this.signupButton_Click);
            // 
            // confirmPaaswordLbl
            // 
            this.confirmPaaswordLbl.AutoSize = true;
            this.confirmPaaswordLbl.BackColor = System.Drawing.Color.Transparent;
            this.confirmPaaswordLbl.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmPaaswordLbl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.confirmPaaswordLbl.Location = new System.Drawing.Point(215, 216);
            this.confirmPaaswordLbl.Name = "confirmPaaswordLbl";
            this.confirmPaaswordLbl.Size = new System.Drawing.Size(228, 24);
            this.confirmPaaswordLbl.TabIndex = 5;
            this.confirmPaaswordLbl.Text = "CONFIRM PASSWORD:";
            // 
            // confirmPasswordTxtBox
            // 
            this.confirmPasswordTxtBox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmPasswordTxtBox.Location = new System.Drawing.Point(217, 243);
            this.confirmPasswordTxtBox.Name = "confirmPasswordTxtBox";
            this.confirmPasswordTxtBox.PasswordChar = '*';
            this.confirmPasswordTxtBox.Size = new System.Drawing.Size(226, 31);
            this.confirmPasswordTxtBox.TabIndex = 2;
            this.confirmPasswordTxtBox.UseSystemPasswordChar = true;
            // 
            // logInLbl
            // 
            this.logInLbl.AutoSize = true;
            this.logInLbl.BackColor = System.Drawing.Color.Transparent;
            this.logInLbl.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.logInLbl.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logInLbl.ForeColor = System.Drawing.Color.White;
            this.logInLbl.Location = new System.Drawing.Point(146, 402);
            this.logInLbl.Name = "logInLbl";
            this.logInLbl.Size = new System.Drawing.Size(368, 24);
            this.logInLbl.TabIndex = 5;
            this.logInLbl.Text = "Already have an account? Sign In!";
            this.logInLbl.Click += new System.EventHandler(this.logInLbl_Click);
            // 
            // hashComboBox
            // 
            this.hashComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hashComboBox.FormattingEnabled = true;
            this.hashComboBox.Items.AddRange(new object[] {
            "MD5",
            "SHA-512",
            "SHA-256"});
            this.hashComboBox.Location = new System.Drawing.Point(217, 313);
            this.hashComboBox.Name = "hashComboBox";
            this.hashComboBox.Size = new System.Drawing.Size(226, 24);
            this.hashComboBox.TabIndex = 3;
            // 
            // hashLbl
            // 
            this.hashLbl.AutoSize = true;
            this.hashLbl.BackColor = System.Drawing.Color.Transparent;
            this.hashLbl.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hashLbl.ForeColor = System.Drawing.SystemColors.Control;
            this.hashLbl.Location = new System.Drawing.Point(216, 286);
            this.hashLbl.Name = "hashLbl";
            this.hashLbl.Size = new System.Drawing.Size(74, 24);
            this.hashLbl.TabIndex = 8;
            this.hashLbl.Text = "HASH:";
            // 
            // Registration
            // 
            this.AcceptButton = this.signupButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::KriptografijaProjekat.Properties.Resources.iStock_884221008;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(634, 519);
            this.Controls.Add(this.hashLbl);
            this.Controls.Add(this.hashComboBox);
            this.Controls.Add(this.logInLbl);
            this.Controls.Add(this.confirmPasswordTxtBox);
            this.Controls.Add(this.confirmPaaswordLbl);
            this.Controls.Add(this.signupButton);
            this.Controls.Add(this.passwordTxtBox);
            this.Controls.Add(this.userNameTxtBox);
            this.Controls.Add(this.passwordLbl);
            this.Controls.Add(this.userNamelbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Registration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label userNamelbl;
        private System.Windows.Forms.Label passwordLbl;
        private System.Windows.Forms.TextBox userNameTxtBox;
        private System.Windows.Forms.TextBox passwordTxtBox;
        private System.Windows.Forms.Button signupButton;
        private System.Windows.Forms.Label confirmPaaswordLbl;
        private System.Windows.Forms.TextBox confirmPasswordTxtBox;
        private System.Windows.Forms.Label logInLbl;
        private System.Windows.Forms.ComboBox hashComboBox;
        private System.Windows.Forms.Label hashLbl;
    }
}