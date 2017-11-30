namespace JohnRule
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
            this.ByttonGenerateRule = new System.Windows.Forms.Button();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ByttonGenerateRule
            // 
            this.ByttonGenerateRule.Location = new System.Drawing.Point(86, 148);
            this.ByttonGenerateRule.Name = "ByttonGenerateRule";
            this.ByttonGenerateRule.Size = new System.Drawing.Size(75, 23);
            this.ByttonGenerateRule.TabIndex = 0;
            this.ByttonGenerateRule.Text = "Generate Rule";
            this.ByttonGenerateRule.UseVisualStyleBackColor = true;
            this.ByttonGenerateRule.Click += new System.EventHandler(this.ButtonGenerateRule_Click);
            // 
            // textBoxResult
            // 
            this.textBoxResult.Location = new System.Drawing.Point(86, 35);
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.Size = new System.Drawing.Size(100, 20);
            this.textBoxResult.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.textBoxResult);
            this.Controls.Add(this.ByttonGenerateRule);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ByttonGenerateRule;
        private System.Windows.Forms.TextBox textBoxResult;
    }
}

