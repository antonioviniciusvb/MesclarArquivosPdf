namespace MergeFilesPdf
{
    partial class FRPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRPrincipal));
            this.opf = new System.Windows.Forms.OpenFileDialog();
            this.lstViewerArquivos = new System.Windows.Forms.ListView();
            this.menuFrm = new System.Windows.Forms.MenuStrip();
            this.menuArquivo = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConfi = new System.Windows.Forms.ToolStripMenuItem();
            this.lstViewerDetalhes = new System.Windows.Forms.ListView();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnStart = new System.Windows.Forms.Button();
            this.menuFrm.SuspendLayout();
            this.SuspendLayout();
            // 
            // opf
            // 
            this.opf.DefaultExt = "pdf";
            this.opf.InitialDirectory = "c:\\";
            this.opf.Multiselect = true;
            this.opf.Title = "Selecione os arquivos .pdf desejados";
            // 
            // lstViewerArquivos
            // 
            this.lstViewerArquivos.FullRowSelect = true;
            this.lstViewerArquivos.HideSelection = false;
            this.lstViewerArquivos.Location = new System.Drawing.Point(12, 55);
            this.lstViewerArquivos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstViewerArquivos.Name = "lstViewerArquivos";
            this.lstViewerArquivos.Size = new System.Drawing.Size(1245, 528);
            this.lstViewerArquivos.TabIndex = 3;
            this.lstViewerArquivos.UseCompatibleStateImageBehavior = false;
            this.lstViewerArquivos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lsArquivos_KeyDown);
            // 
            // menuFrm
            // 
            this.menuFrm.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuFrm.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuFrm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuArquivo,
            this.configuraçõesToolStripMenuItem});
            this.menuFrm.Location = new System.Drawing.Point(0, 0);
            this.menuFrm.Name = "menuFrm";
            this.menuFrm.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuFrm.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuFrm.Size = new System.Drawing.Size(1281, 28);
            this.menuFrm.TabIndex = 14;
            // 
            // menuArquivo
            // 
            this.menuArquivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem});
            this.menuArquivo.Name = "menuArquivo";
            this.menuArquivo.Size = new System.Drawing.Size(73, 24);
            this.menuArquivo.Text = "Arquivo";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(117, 26);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.menuAbrirArq_Click);
            // 
            // configuraçõesToolStripMenuItem
            // 
            this.configuraçõesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuConfi});
            this.configuraçõesToolStripMenuItem.Name = "configuraçõesToolStripMenuItem";
            this.configuraçõesToolStripMenuItem.Size = new System.Drawing.Size(102, 24);
            this.configuraçõesToolStripMenuItem.Text = "Ferramentas";
            // 
            // menuConfi
            // 
            this.menuConfi.Name = "menuConfi";
            this.menuConfi.Size = new System.Drawing.Size(179, 26);
            this.menuConfi.Text = "Configurações";
            this.menuConfi.Click += new System.EventHandler(this.MenuConfig_Click);
            // 
            // lstViewerDetalhes
            // 
            this.lstViewerDetalhes.FullRowSelect = true;
            this.lstViewerDetalhes.HideSelection = false;
            this.lstViewerDetalhes.Location = new System.Drawing.Point(12, 596);
            this.lstViewerDetalhes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstViewerDetalhes.Name = "lstViewerDetalhes";
            this.lstViewerDetalhes.Size = new System.Drawing.Size(1245, 72);
            this.lstViewerDetalhes.TabIndex = 15;
            this.lstViewerDetalhes.UseCompatibleStateImageBehavior = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 706);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1154, 23);
            this.progressBar1.TabIndex = 16;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(1182, 696);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 43);
            this.btnStart.TabIndex = 17;
            this.btnStart.Text = "Iniciar";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // FRPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(78)))), ((int)(((byte)(102)))));
            this.ClientSize = new System.Drawing.Size(1281, 763);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lstViewerDetalhes);
            this.Controls.Add(this.lstViewerArquivos);
            this.Controls.Add(this.menuFrm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuFrm;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FRPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mesclar Arquivos ";
            this.menuFrm.ResumeLayout(false);
            this.menuFrm.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog opf;
        private System.Windows.Forms.ListView lstViewerArquivos;
        private System.Windows.Forms.MenuStrip menuFrm;
        private System.Windows.Forms.ToolStripMenuItem menuArquivo;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraçõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuConfi;
        private System.Windows.Forms.ListView lstViewerDetalhes;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnStart;
    }
}

