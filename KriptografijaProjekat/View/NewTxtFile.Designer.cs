
namespace KriptografijaProjekat.View
{
    partial class NewTxtFile
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
            this.contentTxtBox = new System.Windows.Forms.TextBox();
            this.nameTxtBox = new System.Windows.Forms.TextBox();
            this.nameLbl = new System.Windows.Forms.Label();
            this.contentLbl = new System.Windows.Forms.Label();
            this.saveBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // contentTxtBox
            // 
            this.contentTxtBox.Location = new System.Drawing.Point(79, 42);
            this.contentTxtBox.Multiline = true;
            this.contentTxtBox.Name = "contentTxtBox";
            this.contentTxtBox.Size = new System.Drawing.Size(699, 410);
            this.contentTxtBox.TabIndex = 1;
            // 
            // nameTxtBox
            // 
            this.nameTxtBox.Location = new System.Drawing.Point(79, 12);
            this.nameTxtBox.Name = "nameTxtBox";
            this.nameTxtBox.Size = new System.Drawing.Size(100, 22);
            this.nameTxtBox.TabIndex = 0;
            // 
            // nameLbl
            // 
            this.nameLbl.AutoSize = true;
            this.nameLbl.Location = new System.Drawing.Point(12, 12);
            this.nameLbl.Name = "nameLbl";
            this.nameLbl.Size = new System.Drawing.Size(49, 17);
            this.nameLbl.TabIndex = 2;
            this.nameLbl.Text = "Name:";
            // 
            // contentLbl
            // 
            this.contentLbl.AutoSize = true;
            this.contentLbl.Location = new System.Drawing.Point(12, 42);
            this.contentLbl.Name = "contentLbl";
            this.contentLbl.Size = new System.Drawing.Size(61, 17);
            this.contentLbl.TabIndex = 3;
            this.contentLbl.Text = "Content:";
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(79, 462);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 2;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // NewTxtFile
            // 
            this.AcceptButton = this.saveBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 497);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.contentLbl);
            this.Controls.Add(this.nameLbl);
            this.Controls.Add(this.nameTxtBox);
            this.Controls.Add(this.contentTxtBox);
            this.Name = "NewTxtFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewTxtFile";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox contentTxtBox;
        private System.Windows.Forms.TextBox nameTxtBox;
        private System.Windows.Forms.Label nameLbl;
        private System.Windows.Forms.Label contentLbl;
        private System.Windows.Forms.Button saveBtn;
    }
}