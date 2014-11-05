namespace Ksu.Cis300.Decypher
{
    partial class UserInterface
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
            this.uxInput = new System.Windows.Forms.TextBox();
            this.uxResult = new System.Windows.Forms.TextBox();
            this.uxOpen = new System.Windows.Forms.Button();
            this.uxDecrypt = new System.Windows.Forms.Button();
            this.uxOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // uxInput
            // 
            this.uxInput.Location = new System.Drawing.Point(13, 22);
            this.uxInput.Multiline = true;
            this.uxInput.Name = "uxInput";
            this.uxInput.Size = new System.Drawing.Size(511, 109);
            this.uxInput.TabIndex = 0;
            // 
            // uxResult
            // 
            this.uxResult.Location = new System.Drawing.Point(13, 208);
            this.uxResult.Multiline = true;
            this.uxResult.Name = "uxResult";
            this.uxResult.ReadOnly = true;
            this.uxResult.Size = new System.Drawing.Size(511, 105);
            this.uxResult.TabIndex = 1;
            // 
            // uxOpen
            // 
            this.uxOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxOpen.Location = new System.Drawing.Point(124, 152);
            this.uxOpen.Name = "uxOpen";
            this.uxOpen.Size = new System.Drawing.Size(126, 34);
            this.uxOpen.TabIndex = 2;
            this.uxOpen.Text = "Open File";
            this.uxOpen.UseVisualStyleBackColor = true;
            this.uxOpen.Click += new System.EventHandler(this.uxOpen_Click);
            // 
            // uxDecrypt
            // 
            this.uxDecrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxDecrypt.Location = new System.Drawing.Point(272, 152);
            this.uxDecrypt.Name = "uxDecrypt";
            this.uxDecrypt.Size = new System.Drawing.Size(124, 34);
            this.uxDecrypt.TabIndex = 3;
            this.uxDecrypt.Text = "Decrypt";
            this.uxDecrypt.UseVisualStyleBackColor = true;
            this.uxDecrypt.Click += new System.EventHandler(this.uxDecrypt_Click);
            // 
            // uxOpenFile
            // 
            this.uxOpenFile.FileName = "openFileDialog1";
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 334);
            this.Controls.Add(this.uxDecrypt);
            this.Controls.Add(this.uxOpen);
            this.Controls.Add(this.uxResult);
            this.Controls.Add(this.uxInput);
            this.Name = "UserInterface";
            this.Text = "Decyphering";
            this.Load += new System.EventHandler(this.UserInterface_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox uxInput;
        private System.Windows.Forms.TextBox uxResult;
        private System.Windows.Forms.Button uxOpen;
        private System.Windows.Forms.Button uxDecrypt;
        private System.Windows.Forms.OpenFileDialog uxOpenFile;
    }
}

