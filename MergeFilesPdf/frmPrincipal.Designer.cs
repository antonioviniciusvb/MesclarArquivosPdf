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
            this.toolstrip = new System.Windows.Forms.ToolStrip();
            this.toolProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStart = new System.Windows.Forms.ToolStripButton();
            this.txtBoxArquivosSelecionados = new System.Windows.Forms.TextBox();
            this.btnSelectFiles = new System.Windows.Forms.Button();
            this.opf = new System.Windows.Forms.OpenFileDialog();
            this.lstViewerArquivos = new System.Windows.Forms.ListView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lstbTxtLogica = new System.Windows.Forms.ListBox();
            this.lsBoxPdfLogica = new System.Windows.Forms.ListBox();
            this.grpbArquivos = new System.Windows.Forms.GroupBox();
            this.rdbPdf = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.menuFrm = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolstrip.SuspendLayout();
            this.grpbArquivos.SuspendLayout();
            this.menuFrm.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolstrip
            // 
            this.toolstrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolstrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolProgressBar,
            this.toolStripSeparator2,
            this.toolStart});
            this.toolstrip.Location = new System.Drawing.Point(0, 509);
            this.toolstrip.Name = "toolstrip";
            this.toolstrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolstrip.Size = new System.Drawing.Size(756, 25);
            this.toolstrip.TabIndex = 0;
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
            // txtBoxArquivosSelecionados
            // 
            this.txtBoxArquivosSelecionados.Location = new System.Drawing.Point(82, 38);
            this.txtBoxArquivosSelecionados.Name = "txtBoxArquivosSelecionados";
            this.txtBoxArquivosSelecionados.Size = new System.Drawing.Size(489, 20);
            this.txtBoxArquivosSelecionados.TabIndex = 1;
            // 
            // btnSelectFiles
            // 
            this.btnSelectFiles.Location = new System.Drawing.Point(590, 36);
            this.btnSelectFiles.Name = "btnSelectFiles";
            this.btnSelectFiles.Size = new System.Drawing.Size(42, 23);
            this.btnSelectFiles.TabIndex = 2;
            this.btnSelectFiles.Text = "...";
            this.btnSelectFiles.UseVisualStyleBackColor = true;
            this.btnSelectFiles.Click += new System.EventHandler(this.btnSelectFiles_Click);
            // 
            // opf
            // 
            this.opf.DefaultExt = "pdf";
            this.opf.Filter = "Arquivos pdf|*.pdf|Arquivos txt|*.txt";
            this.opf.InitialDirectory = "c:\\";
            this.opf.Multiselect = true;
            this.opf.Title = "Selecione os arquivos .pdf desejados";
            // 
            // lstViewerArquivos
            // 
            this.lstViewerArquivos.FullRowSelect = true;
            this.lstViewerArquivos.Location = new System.Drawing.Point(9, 180);
            this.lstViewerArquivos.Name = "lstViewerArquivos";
            this.lstViewerArquivos.Size = new System.Drawing.Size(740, 324);
            this.lstViewerArquivos.TabIndex = 3;
            this.lstViewerArquivos.UseCompatibleStateImageBehavior = false;
            this.lstViewerArquivos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lsArquivos_KeyDown);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lstbTxtLogica
            // 
            this.lstbTxtLogica.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstbTxtLogica.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstbTxtLogica.FormattingEnabled = true;
            this.lstbTxtLogica.Items.AddRange(new object[] {
            "1 Registro - 1 linha",
            "1 Registro - 2 linhas",
            "1 Regsitro - 3 linhas",
            "1 Registro - 4 linhas",
            "1 Registro - 5 linhas",
            "Desconsiderar 1 linha",
            "Prefeitura de Brusque - contas de água"});
            this.lstbTxtLogica.Location = new System.Drawing.Point(164, 244);
            this.lstbTxtLogica.Name = "lstbTxtLogica";
            this.lstbTxtLogica.ScrollAlwaysVisible = true;
            this.lstbTxtLogica.Size = new System.Drawing.Size(226, 67);
            this.lstbTxtLogica.TabIndex = 11;
            // 
            // lsBoxPdfLogica
            // 
            this.lsBoxPdfLogica.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lsBoxPdfLogica.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsBoxPdfLogica.FormattingEnabled = true;
            this.lsBoxPdfLogica.Items.AddRange(new object[] {
            "Simplex",
            "Duplex"});
            this.lsBoxPdfLogica.Location = new System.Drawing.Point(440, 255);
            this.lsBoxPdfLogica.Name = "lsBoxPdfLogica";
            this.lsBoxPdfLogica.ScrollAlwaysVisible = true;
            this.lsBoxPdfLogica.Size = new System.Drawing.Size(73, 41);
            this.lsBoxPdfLogica.TabIndex = 12;
            // 
            // grpbArquivos
            // 
            this.grpbArquivos.Controls.Add(this.rdbPdf);
            this.grpbArquivos.Controls.Add(this.radioButton1);
            this.grpbArquivos.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.grpbArquivos.Location = new System.Drawing.Point(346, 232);
            this.grpbArquivos.Name = "grpbArquivos";
            this.grpbArquivos.Size = new System.Drawing.Size(64, 71);
            this.grpbArquivos.TabIndex = 13;
            this.grpbArquivos.TabStop = false;
            this.grpbArquivos.Text = "Arquivos";
            // 
            // rdbPdf
            // 
            this.rdbPdf.AutoSize = true;
            this.rdbPdf.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rdbPdf.Location = new System.Drawing.Point(6, 19);
            this.rdbPdf.Name = "rdbPdf";
            this.rdbPdf.Size = new System.Drawing.Size(46, 17);
            this.rdbPdf.TabIndex = 4;
            this.rdbPdf.TabStop = true;
            this.rdbPdf.Text = "PDF";
            this.rdbPdf.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.radioButton1.Location = new System.Drawing.Point(6, 42);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(46, 17);
            this.radioButton1.TabIndex = 5;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "TXT";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // menuFrm
            // 
            this.menuFrm.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuFrm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem,
            this.configuraçõesToolStripMenuItem});
            this.menuFrm.Location = new System.Drawing.Point(0, 0);
            this.menuFrm.Name = "menuFrm";
            this.menuFrm.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuFrm.Size = new System.Drawing.Size(756, 24);
            this.menuFrm.TabIndex = 14;
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem});
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.arquivoToolStripMenuItem.Text = "Arquivo";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            // 
            // configuraçõesToolStripMenuItem
            // 
            this.configuraçõesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem1});
            this.configuraçõesToolStripMenuItem.Name = "configuraçõesToolStripMenuItem";
            this.configuraçõesToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.configuraçõesToolStripMenuItem.Text = "Ferramentas";
           
            // 
            // abrirToolStripMenuItem1
            // 
            this.abrirToolStripMenuItem1.Name = "abrirToolStripMenuItem1";
            this.abrirToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.abrirToolStripMenuItem1.Text = "Configurações";
           
            //
            // FRPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(78)))), ((int)(((byte)(102)))));
            this.ClientSize = new System.Drawing.Size(756, 534);
            this.Controls.Add(this.grpbArquivos);
            this.Controls.Add(this.lsBoxPdfLogica);
            this.Controls.Add(this.lstbTxtLogica);
            this.Controls.Add(this.lstViewerArquivos);
            this.Controls.Add(this.btnSelectFiles);
            this.Controls.Add(this.txtBoxArquivosSelecionados);
            this.Controls.Add(this.toolstrip);
            this.Controls.Add(this.menuFrm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuFrm;
            this.MaximizeBox = false;
            this.Name = "FRPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mesclar Arquivos ";
            this.toolstrip.ResumeLayout(false);
            this.toolstrip.PerformLayout();
            this.grpbArquivos.ResumeLayout(false);
            this.grpbArquivos.PerformLayout();
            this.menuFrm.ResumeLayout(false);
            this.menuFrm.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolstrip;
        private System.Windows.Forms.ToolStripButton toolStart;
        private System.Windows.Forms.ToolStripProgressBar toolProgressBar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.TextBox txtBoxArquivosSelecionados;
        private System.Windows.Forms.Button btnSelectFiles;
        private System.Windows.Forms.OpenFileDialog opf;
        private System.Windows.Forms.ListView lstViewerArquivos;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ListBox lstbTxtLogica;
        private System.Windows.Forms.ListBox lsBoxPdfLogica;
        private System.Windows.Forms.GroupBox grpbArquivos;
        private System.Windows.Forms.RadioButton rdbPdf;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.MenuStrip menuFrm;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraçõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem1;
    }
}

