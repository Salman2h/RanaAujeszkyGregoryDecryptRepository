namespace Rana_Aujeszky_Gregory_Decrypt
{
    partial class UserInput
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
            this.cipherLabel = new System.Windows.Forms.Label();
            this.cipherTextBox = new System.Windows.Forms.TextBox();
            this.plainTextBox = new System.Windows.Forms.TextBox();
            this.plainTextLabel = new System.Windows.Forms.Label();
            this.decryptButton = new System.Windows.Forms.Button();
            this.lblDelimiter = new System.Windows.Forms.Label();
            this.cbDelimiter = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblCaption = new System.Windows.Forms.Label();
            this.loadDictionaryButton = new System.Windows.Forms.Button();
            this.loadDictionaryLabel = new System.Windows.Forms.Label();
            this.txtDictFileName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cipherLabel
            // 
            this.cipherLabel.AutoSize = true;
            this.cipherLabel.Location = new System.Drawing.Point(26, 109);
            this.cipherLabel.Name = "cipherLabel";
            this.cipherLabel.Size = new System.Drawing.Size(65, 13);
            this.cipherLabel.TabIndex = 3;
            this.cipherLabel.Text = "Enter Cipher";
            // 
            // cipherTextBox
            // 
            this.cipherTextBox.Location = new System.Drawing.Point(29, 125);
            this.cipherTextBox.Multiline = true;
            this.cipherTextBox.Name = "cipherTextBox";
            this.cipherTextBox.Size = new System.Drawing.Size(375, 98);
            this.cipherTextBox.TabIndex = 4;
            // 
            // plainTextBox
            // 
            this.plainTextBox.Location = new System.Drawing.Point(29, 294);
            this.plainTextBox.Multiline = true;
            this.plainTextBox.Name = "plainTextBox";
            this.plainTextBox.Size = new System.Drawing.Size(375, 61);
            this.plainTextBox.TabIndex = 6;
            // 
            // plainTextLabel
            // 
            this.plainTextLabel.AutoSize = true;
            this.plainTextLabel.Location = new System.Drawing.Point(26, 278);
            this.plainTextLabel.Name = "plainTextLabel";
            this.plainTextLabel.Size = new System.Drawing.Size(54, 13);
            this.plainTextLabel.TabIndex = 5;
            this.plainTextLabel.Text = "Plain Text";
            // 
            // decryptButton
            // 
            this.decryptButton.Location = new System.Drawing.Point(249, 234);
            this.decryptButton.Name = "decryptButton";
            this.decryptButton.Size = new System.Drawing.Size(155, 30);
            this.decryptButton.TabIndex = 9;
            this.decryptButton.Text = "Decrypt";
            this.decryptButton.UseVisualStyleBackColor = true;
            this.decryptButton.Click += new System.EventHandler(this.decryptButton_Click);
            // 
            // lblDelimiter
            // 
            this.lblDelimiter.AutoSize = true;
            this.lblDelimiter.Location = new System.Drawing.Point(26, 239);
            this.lblDelimiter.Name = "lblDelimiter";
            this.lblDelimiter.Size = new System.Drawing.Size(47, 13);
            this.lblDelimiter.TabIndex = 12;
            this.lblDelimiter.Text = "Delimiter";
            // 
            // cbDelimiter
            // 
            this.cbDelimiter.FormattingEnabled = true;
            this.cbDelimiter.Items.AddRange(new object[] {
            "Comma",
            "Tab",
            "Space"});
            this.cbDelimiter.Location = new System.Drawing.Point(79, 236);
            this.cbDelimiter.Name = "cbDelimiter";
            this.cbDelimiter.Size = new System.Drawing.Size(149, 21);
            this.cbDelimiter.TabIndex = 13;
            this.cbDelimiter.Text = "Comma";
            this.cbDelimiter.SelectedIndexChanged += new System.EventHandler(this.cbDelimiter_SelectedIndexChanged);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(142, 363);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(155, 30);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblCaption
            // 
            this.lblCaption.AutoSize = true;
            this.lblCaption.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaption.Location = new System.Drawing.Point(92, 9);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(251, 24);
            this.lblCaption.TabIndex = 15;
            this.lblCaption.Text = "Permutation Cryptanalysis";
            this.lblCaption.Click += new System.EventHandler(this.label1_Click);
            // 
            // loadDictionaryButton
            // 
            this.loadDictionaryButton.Location = new System.Drawing.Point(350, 71);
            this.loadDictionaryButton.Name = "loadDictionaryButton";
            this.loadDictionaryButton.Size = new System.Drawing.Size(54, 23);
            this.loadDictionaryButton.TabIndex = 16;
            this.loadDictionaryButton.Text = "- - ";
            this.loadDictionaryButton.UseVisualStyleBackColor = true;
            this.loadDictionaryButton.Click += new System.EventHandler(this.loadDictionaryButton_Click);
            // 
            // loadDictionaryLabel
            // 
            this.loadDictionaryLabel.AutoSize = true;
            this.loadDictionaryLabel.Location = new System.Drawing.Point(26, 55);
            this.loadDictionaryLabel.Name = "loadDictionaryLabel";
            this.loadDictionaryLabel.Size = new System.Drawing.Size(81, 13);
            this.loadDictionaryLabel.TabIndex = 17;
            this.loadDictionaryLabel.Text = "Load Dictionary";
            // 
            // txtDictFileName
            // 
            this.txtDictFileName.Enabled = false;
            this.txtDictFileName.Location = new System.Drawing.Point(29, 74);
            this.txtDictFileName.Name = "txtDictFileName";
            this.txtDictFileName.Size = new System.Drawing.Size(314, 20);
            this.txtDictFileName.TabIndex = 18;
            // 
            // UserInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 405);
            this.Controls.Add(this.txtDictFileName);
            this.Controls.Add(this.loadDictionaryLabel);
            this.Controls.Add(this.loadDictionaryButton);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cbDelimiter);
            this.Controls.Add(this.lblDelimiter);
            this.Controls.Add(this.decryptButton);
            this.Controls.Add(this.plainTextBox);
            this.Controls.Add(this.plainTextLabel);
            this.Controls.Add(this.cipherTextBox);
            this.Controls.Add(this.cipherLabel);
            this.Name = "UserInput";
            this.Text = "Rashid-Aujeszky-Gregory-Decrypt";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label cipherLabel;
        private System.Windows.Forms.TextBox cipherTextBox;
        private System.Windows.Forms.TextBox plainTextBox;
        private System.Windows.Forms.Label plainTextLabel;
        private System.Windows.Forms.Button decryptButton;
        private System.Windows.Forms.Label lblDelimiter;
        private System.Windows.Forms.ComboBox cbDelimiter;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.Button loadDictionaryButton;
        private System.Windows.Forms.Label loadDictionaryLabel;
        private System.Windows.Forms.TextBox txtDictFileName;
    }
}

