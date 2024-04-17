namespace PasswordEncrypt
{
    partial class Form1
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
            this.lbl_Empcode = new System.Windows.Forms.Label();
            this.lbl_Password = new System.Windows.Forms.Label();
            this.txt_Empcode = new System.Windows.Forms.TextBox();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbl_Empcode
            // 
            this.lbl_Empcode.AutoSize = true;
            this.lbl_Empcode.Location = new System.Drawing.Point(22, 12);
            this.lbl_Empcode.Name = "lbl_Empcode";
            this.lbl_Empcode.Size = new System.Drawing.Size(52, 13);
            this.lbl_Empcode.TabIndex = 0;
            this.lbl_Empcode.Text = "Empcode";
            // 
            // lbl_Password
            // 
            this.lbl_Password.AutoSize = true;
            this.lbl_Password.Location = new System.Drawing.Point(22, 40);
            this.lbl_Password.Name = "lbl_Password";
            this.lbl_Password.Size = new System.Drawing.Size(53, 13);
            this.lbl_Password.TabIndex = 1;
            this.lbl_Password.Text = "Password";
            // 
            // txt_Empcode
            // 
            this.txt_Empcode.Location = new System.Drawing.Point(105, 9);
            this.txt_Empcode.MaxLength = 4;
            this.txt_Empcode.Name = "txt_Empcode";
            this.txt_Empcode.Size = new System.Drawing.Size(162, 20);
            this.txt_Empcode.TabIndex = 1;
            this.txt_Empcode.TextChanged += new System.EventHandler(this.txt_Empcode_TextChanged);
            // 
            // txt_Password
            // 
            this.txt_Password.Location = new System.Drawing.Point(105, 37);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.ReadOnly = true;
            this.txt_Password.Size = new System.Drawing.Size(162, 20);
            this.txt_Password.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 74);
            this.Controls.Add(this.txt_Password);
            this.Controls.Add(this.txt_Empcode);
            this.Controls.Add(this.lbl_Password);
            this.Controls.Add(this.lbl_Empcode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Password Encrypt";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Empcode;
        private System.Windows.Forms.Label lbl_Password;
        private System.Windows.Forms.TextBox txt_Empcode;
        private System.Windows.Forms.TextBox txt_Password;
    }
}

