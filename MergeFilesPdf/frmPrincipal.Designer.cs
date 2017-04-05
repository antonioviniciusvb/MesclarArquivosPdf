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
            this.tstProgresso = new System.Windows.Forms.ToolStrip();
            this.toolProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStart = new System.Windows.Forms.ToolStripButton();
            this.opf = new System.Windows.Forms.OpenFileDialog();
            this.lstViewerArquivos = new System.Windows.Forms.ListView();
            this.menuFrm = new System.Windows.Forms.MenuStrip();
            this.menuArquivo = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConfi = new System.Windows.Forms.ToolStripMenuItem();
            this.lstViewerDetalhes = new System.Windows.Forms.ListView();
            this.tstProgresso.SuspendLayout();
            this.menuFrm.SuspendLayout();
            this.SuspendLayout();
            // 
            // tstProgresso
            // 
            this.tstProgresso.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tstProgresso.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolProgressBar,
            this.toolStripSeparator2,
            this.toolStart});
            this.tstProgresso.Location = new System.Drawing.Point(0, 550);
            this.tstProgresso.Name = "tstProgresso";
            this.tstProgresso.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.tstProgresso.Size = new System.Drawing.Size(756, 25);
            this.tstProgresso.TabIndex = 0;
            // 
            // toolProgressBar
            // 
            this.toolProgressBar.Name = "toolProgressBar";
            this.toolProgressBar.Size = new System.Drawing.Size(681, 22);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStart
            // 
            this.toolStart.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStart.Image = global::MergeFilesPdf.Properties.Resources._1480398503_start;
            this.toolStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStart.Margin = new System.Windows.Forms.Padding(1, 1, 0, 2);
            this.toolStart.Name = "toolStart";
            this.toolStart.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.toolStart.Size = new System.Drawing.Size(23, 22);
            this.toolStart.Text = "Iniciar";
            this.toolStart.Click += new System.EventHandler(this.toolStart_Click);
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
            this.lstViewerArquivos.Location = new System.Drawing.Point(9, 43);
            this.lstViewerArquivos.Name = "lstViewerArquivos";
            this.lstViewerArquivos.Size = new System.Drawing.Size(740, 430);
            this.lstViewerArquivos.TabIndex = 3;
            this.lstViewerArquivos.UseCompatibleStateImageBehavior = false;
            this.lstViewerArquivos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lsArquivos_KeyDown);
            // 
            // menuFrm
            // 
            this.menuFrm.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuFrm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuArquivo,
            this.configuraçõesToolStripMenuItem});
            this.menuFrm.Location = new System.Drawing.Point(0, 0);
            this.menuFrm.Name = "menuFrm";
            this.menuFrm.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuFrm.Size = new System.Drawing.Size(756, 24);
            this.menuFrm.TabIndex = 14;
            // 
            // menuArquivo
            // 
            this.menuArquivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem});
            this.menuArquivo.Name = "menuArquivo";
            this.menuArquivo.Size = new System.Drawing.Size(61, 20);
            this.menuArquivo.Text = "Arquivo";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.menuAbrirArq_Click);
            // 
            // configuraçõesToolStripMenuItem
            // 
            this.configuraçõesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuConfi});
            this.configuraçõesToolStripMenuItem.Name = "configuraçõesToolStripMenuItem";
            this.configuraçõesToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.configuraçõesToolStripMenuItem.Text = "Ferramentas";
            // 
            // menuConfi
            // 
            this.menuConfi.Name = "menuConfi";
            this.menuConfi.Size = new System.Drawing.Size(151, 22);
            this.menuConfi.Text = "Configurações";
            this.menuConfi.Click += new System.EventHandler(this.MenuConfig_Click);
            // 
            // lstViewerDetalhes
            // 
            this.lstViewerDetalhes.FullRowSelect = true;
            this.lstViewerDetalhes.Location = new System.Drawing.Point(9, 488);
            this.lstViewerDetalhes.Name = "lstViewerDetalhes";
            this.lstViewerDetalhes.Size = new System.Drawing.Size(740, 59);
            this.lstViewerDetalhes.TabIndex = 15;
            this.lstViewerDetalhes.UseCompatibleStateImageBehavior = false;
            // 
            // FRPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(78)))), ((int)(((byte)(102)))));
            this.ClientSize = new System.Drawing.Size(756, 575);
            this.Controls.Add(this.lstViewerDetalhes);
            this.Controls.Add(this.lstViewerArquivos);
            this.Controls.Add(this.tstProgresso);
            this.Controls.Add(this.menuFrm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuFrm;
            this.MaximizeBox = false;
            this.Name = "FRPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mesclar Arquivos ";
            this.tstProgresso.ResumeLayout(false);
            this.tstProgresso.PerformLayout();
            this.menuFrm.ResumeLayout(false);
            this.menuFrm.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tstProgresso;
        private System.Windows.Forms.ToolStripButton toolStart;
        private System.Windows.Forms.ToolStripProgressBar toolProgressBar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.OpenFileDialog opf;
        private System.Windows.Forms.ListView lstViewerArquivos;
        private System.Windows.Forms.MenuStrip menuFrm;
        private System.Windows.Forms.ToolStripMenuItem menuArquivo;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraçõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuConfi;
        private System.Windows.Forms.ListView lstViewerDetalhes;
    }
}

