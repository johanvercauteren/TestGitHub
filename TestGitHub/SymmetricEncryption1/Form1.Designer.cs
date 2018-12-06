namespace WindowsFormsApplication5
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
            this.buttonencrypt = new System.Windows.Forms.Button();
            this.buttonDecrypt = new System.Windows.Forms.Button();
            this.buttonEncryptString = new System.Windows.Forms.Button();
            this.textBoxEncryptedString = new System.Windows.Forms.TextBox();
            this.buttonDecryptString = new System.Windows.Forms.Button();
            this.textBoxDecryptedString = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonencrypt
            // 
            this.buttonencrypt.Location = new System.Drawing.Point(79, 47);
            this.buttonencrypt.Name = "buttonencrypt";
            this.buttonencrypt.Size = new System.Drawing.Size(75, 23);
            this.buttonencrypt.TabIndex = 0;
            this.buttonencrypt.Text = "Encrypt";
            this.buttonencrypt.UseVisualStyleBackColor = true;
            this.buttonencrypt.Click += new System.EventHandler(this.buttonencrypt_Click);
            // 
            // buttonDecrypt
            // 
            this.buttonDecrypt.Location = new System.Drawing.Point(79, 121);
            this.buttonDecrypt.Name = "buttonDecrypt";
            this.buttonDecrypt.Size = new System.Drawing.Size(75, 23);
            this.buttonDecrypt.TabIndex = 1;
            this.buttonDecrypt.Text = "Decrypt";
            this.buttonDecrypt.UseVisualStyleBackColor = true;
            this.buttonDecrypt.Click += new System.EventHandler(this.buttonDecrypt_Click);
            // 
            // buttonEncryptString
            // 
            this.buttonEncryptString.Location = new System.Drawing.Point(258, 25);
            this.buttonEncryptString.Name = "buttonEncryptString";
            this.buttonEncryptString.Size = new System.Drawing.Size(83, 23);
            this.buttonEncryptString.TabIndex = 2;
            this.buttonEncryptString.Text = "EncryptString";
            this.buttonEncryptString.UseVisualStyleBackColor = true;
            this.buttonEncryptString.Click += new System.EventHandler(this.buttonEncryptString_Click);
            // 
            // textBoxEncryptedString
            // 
            this.textBoxEncryptedString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEncryptedString.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEncryptedString.Location = new System.Drawing.Point(357, 28);
            this.textBoxEncryptedString.Name = "textBoxEncryptedString";
            this.textBoxEncryptedString.Size = new System.Drawing.Size(384, 20);
            this.textBoxEncryptedString.TabIndex = 3;
            // 
            // buttonDecryptString
            // 
            this.buttonDecryptString.Location = new System.Drawing.Point(258, 73);
            this.buttonDecryptString.Name = "buttonDecryptString";
            this.buttonDecryptString.Size = new System.Drawing.Size(83, 23);
            this.buttonDecryptString.TabIndex = 4;
            this.buttonDecryptString.Text = "Decrypt String";
            this.buttonDecryptString.UseVisualStyleBackColor = true;
            this.buttonDecryptString.Click += new System.EventHandler(this.buttonDecryptString_Click);
            // 
            // textBoxDecryptedString
            // 
            this.textBoxDecryptedString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDecryptedString.Location = new System.Drawing.Point(357, 75);
            this.textBoxDecryptedString.Name = "textBoxDecryptedString";
            this.textBoxDecryptedString.Size = new System.Drawing.Size(384, 20);
            this.textBoxDecryptedString.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 262);
            this.Controls.Add(this.textBoxDecryptedString);
            this.Controls.Add(this.buttonDecryptString);
            this.Controls.Add(this.textBoxEncryptedString);
            this.Controls.Add(this.buttonEncryptString);
            this.Controls.Add(this.buttonDecrypt);
            this.Controls.Add(this.buttonencrypt);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonencrypt;
        private System.Windows.Forms.Button buttonDecrypt;
        private System.Windows.Forms.Button buttonEncryptString;
        private System.Windows.Forms.TextBox textBoxEncryptedString;
        private System.Windows.Forms.Button buttonDecryptString;
        private System.Windows.Forms.TextBox textBoxDecryptedString;
    }
}

