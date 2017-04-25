namespace MergeFilesPdf
{
    partial class Alert
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
            if(disposing && (components != null))
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
            this.pctBoxAlert = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxAlert)).BeginInit();
            this.SuspendLayout();
            // 
            // pctBoxAlert
            // 
            this.pctBoxAlert.Image = global::MergeFilesPdf.Properties.Resources.Alert;
            this.pctBoxAlert.InitialImage = global::MergeFilesPdf.Properties.Resources.Alert;
            this.pctBoxAlert.Location = new System.Drawing.Point(0, -6);
            this.pctBoxAlert.Name = "pctBoxAlert";
            this.pctBoxAlert.Size = new System.Drawing.Size(416, 210);
            this.pctBoxAlert.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctBoxAlert.TabIndex = 0;
            this.pctBoxAlert.TabStop = false;
            // 
            // Alert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(413, 244);
            this.Controls.Add(this.pctBoxAlert);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Alert";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxAlert)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pctBoxAlert;
    }
}