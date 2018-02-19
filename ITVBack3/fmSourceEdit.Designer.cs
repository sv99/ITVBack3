namespace ITVBack
{
    partial class fmSourceEdit
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
            this.tbSource = new System.Windows.Forms.TextBox();
            this.buOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbSource
            // 
            this.tbSource.Location = new System.Drawing.Point(12, 12);
            this.tbSource.Name = "tbSource";
            this.tbSource.Size = new System.Drawing.Size(346, 20);
            this.tbSource.TabIndex = 0;
            // 
            // buOk
            // 
            this.buOk.Cursor = System.Windows.Forms.Cursors.Default;
            this.buOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buOk.Location = new System.Drawing.Point(273, 38);
            this.buOk.Name = "buOk";
            this.buOk.Size = new System.Drawing.Size(85, 24);
            this.buOk.TabIndex = 36;
            this.buOk.Text = "Ok";
            this.buOk.UseVisualStyleBackColor = true;
            // 
            // fmSourceEdit
            // 
            this.AcceptButton = this.buOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 70);
            this.Controls.Add(this.buOk);
            this.Controls.Add(this.tbSource);
            this.Name = "fmSourceEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "fmSourceEdit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbSource;
        private System.Windows.Forms.Button buOk;
    }
}