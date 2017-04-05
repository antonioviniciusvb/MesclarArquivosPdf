namespace MergeFilesPdf
{
    partial class FrOpcoes
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
            this.lstGeracao = new System.Windows.Forms.ListBox();
            this.lsTipoArquivo = new System.Windows.Forms.ListBox();
            this.lblTipoArquivo = new System.Windows.Forms.Label();
            this.lblOpcoesProcessamento = new System.Windows.Forms.Label();
            this.lstBoxLogica = new System.Windows.Forms.ListBox();
            this.lbLogica = new System.Windows.Forms.Label();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.tabConfig = new System.Windows.Forms.TabControl();
            this.tabPg1 = new System.Windows.Forms.TabPage();
            this.tabConfig.SuspendLayout();
            this.tabPg1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstGeracao
            // 
            this.lstGeracao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstGeracao.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lstGeracao.FormattingEnabled = true;
            this.lstGeracao.HorizontalScrollbar = true;
            this.lstGeracao.ItemHeight = 15;
            this.lstGeracao.Location = new System.Drawing.Point(6, 71);
            this.lstGeracao.Name = "lstGeracao";
            this.lstGeracao.Size = new System.Drawing.Size(327, 94);
            this.lstGeracao.TabIndex = 14;
            this.lstGeracao.SelectedIndexChanged += new System.EventHandler(this.lstGeracao_SelectedIndexChanged);
            // 
            // lsTipoArquivo
            // 
            this.lsTipoArquivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsTipoArquivo.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lsTipoArquivo.FormattingEnabled = true;
            this.lsTipoArquivo.ItemHeight = 18;
            this.lsTipoArquivo.Location = new System.Drawing.Point(6, 23);
            this.lsTipoArquivo.Name = "lsTipoArquivo";
            this.lsTipoArquivo.Size = new System.Drawing.Size(327, 22);
            this.lsTipoArquivo.TabIndex = 15;
            this.lsTipoArquivo.SelectedIndexChanged += new System.EventHandler(this.lsTipoArquivo_SelectedIndexChanged);
            // 
            // lblTipoArquivo
            // 
            this.lblTipoArquivo.AutoSize = true;
            this.lblTipoArquivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoArquivo.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lblTipoArquivo.Location = new System.Drawing.Point(3, 3);
            this.lblTipoArquivo.Name = "lblTipoArquivo";
            this.lblTipoArquivo.Size = new System.Drawing.Size(108, 17);
            this.lblTipoArquivo.TabIndex = 16;
            this.lblTipoArquivo.Text = "Tipo de Arquivo";
            // 
            // lblOpcoesProcessamento
            // 
            this.lblOpcoesProcessamento.AutoSize = true;
            this.lblOpcoesProcessamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpcoesProcessamento.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lblOpcoesProcessamento.Location = new System.Drawing.Point(3, 51);
            this.lblOpcoesProcessamento.Name = "lblOpcoesProcessamento";
            this.lblOpcoesProcessamento.Size = new System.Drawing.Size(63, 17);
            this.lblOpcoesProcessamento.TabIndex = 17;
            this.lblOpcoesProcessamento.Text = "Geração";
            // 
            // lstBoxLogica
            // 
            this.lstBoxLogica.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBoxLogica.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lstBoxLogica.FormattingEnabled = true;
            this.lstBoxLogica.HorizontalScrollbar = true;
            this.lstBoxLogica.ItemHeight = 15;
            this.lstBoxLogica.Location = new System.Drawing.Point(6, 190);
            this.lstBoxLogica.Name = "lstBoxLogica";
            this.lstBoxLogica.Size = new System.Drawing.Size(327, 94);
            this.lstBoxLogica.TabIndex = 18;
            this.lstBoxLogica.SelectedIndexChanged += new System.EventHandler(this.lstBoxLogica_SelectedIndexChanged);
            // 
            // lbLogica
            // 
            this.lbLogica.AutoSize = true;
            this.lbLogica.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLogica.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lbLogica.Location = new System.Drawing.Point(3, 168);
            this.lbLogica.Name = "lbLogica";
            this.lbLogica.Size = new System.Drawing.Size(50, 17);
            this.lbLogica.TabIndex = 19;
            this.lbLogica.Text = "Lógica";
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(10, 332);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(68, 25);
            this.btnLimpar.TabIndex = 19;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnAplicar
            // 
            this.btnAplicar.Location = new System.Drawing.Point(202, 332);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(68, 25);
            this.btnAplicar.TabIndex = 20;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(285, 332);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(68, 25);
            this.btnOk.TabIndex = 22;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // tabConfig
            // 
            this.tabConfig.Controls.Add(this.tabPg1);
            this.tabConfig.Location = new System.Drawing.Point(8, 12);
            this.tabConfig.Name = "tabConfig";
            this.tabConfig.SelectedIndex = 0;
            this.tabConfig.Size = new System.Drawing.Size(347, 315);
            this.tabConfig.TabIndex = 23;
            // 
            // tabPg1
            // 
            this.tabPg1.Controls.Add(this.lstBoxLogica);
            this.tabPg1.Controls.Add(this.lblTipoArquivo);
            this.tabPg1.Controls.Add(this.lbLogica);
            this.tabPg1.Controls.Add(this.lsTipoArquivo);
            this.tabPg1.Controls.Add(this.lblOpcoesProcessamento);
            this.tabPg1.Controls.Add(this.lstGeracao);
            this.tabPg1.Location = new System.Drawing.Point(4, 22);
            this.tabPg1.Name = "tabPg1";
            this.tabPg1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPg1.Size = new System.Drawing.Size(339, 289);
            this.tabPg1.TabIndex = 0;
            this.tabPg1.Text = "Processamento";
            this.tabPg1.UseVisualStyleBackColor = true;
            // 
            // FrOpcoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(360, 363);
            this.Controls.Add(this.tabConfig);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnAplicar);
            this.Controls.Add(this.btnLimpar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrOpcoes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurações";
            this.tabConfig.ResumeLayout(false);
            this.tabPg1.ResumeLayout(false);
            this.tabPg1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox lstGeracao;
        private System.Windows.Forms.ListBox lsTipoArquivo;
        private System.Windows.Forms.Label lblTipoArquivo;
        private System.Windows.Forms.Label lblOpcoesProcessamento;
        private System.Windows.Forms.ListBox lstBoxLogica;
        private System.Windows.Forms.Label lbLogica;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TabControl tabConfig;
        private System.Windows.Forms.TabPage tabPg1;
    }
}