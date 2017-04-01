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
            this.grpBoxOpcoesConfig = new System.Windows.Forms.GroupBox();
            this.grpBoxOpcoesConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstGeracao
            // 
            this.lstGeracao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstGeracao.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lstGeracao.FormattingEnabled = true;
            this.lstGeracao.HorizontalScrollbar = true;
            this.lstGeracao.ItemHeight = 15;
            this.lstGeracao.Location = new System.Drawing.Point(22, 115);
            this.lstGeracao.Name = "lstGeracao";
            this.lstGeracao.Size = new System.Drawing.Size(327, 94);
            this.lstGeracao.TabIndex = 14;
            // 
            // lsTipoArquivo
            // 
            this.lsTipoArquivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsTipoArquivo.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lsTipoArquivo.FormattingEnabled = true;
            this.lsTipoArquivo.ItemHeight = 20;
            this.lsTipoArquivo.Location = new System.Drawing.Point(22, 57);
            this.lsTipoArquivo.Name = "lsTipoArquivo";
            this.lsTipoArquivo.Size = new System.Drawing.Size(327, 24);
            this.lsTipoArquivo.TabIndex = 15;
            this.lsTipoArquivo.SelectedIndexChanged += new System.EventHandler(this.lsTipoArquivo_SelectedIndexChanged);
            // 
            // lblTipoArquivo
            // 
            this.lblTipoArquivo.AutoSize = true;
            this.lblTipoArquivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoArquivo.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lblTipoArquivo.Location = new System.Drawing.Point(19, 37);
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
            this.lblOpcoesProcessamento.Location = new System.Drawing.Point(19, 93);
            this.lblOpcoesProcessamento.Name = "lblOpcoesProcessamento";
            this.lblOpcoesProcessamento.Size = new System.Drawing.Size(63, 17);
            this.lblOpcoesProcessamento.TabIndex = 17;
            this.lblOpcoesProcessamento.Text = "Geração";
            // 
            // grpBoxOpcoesConfig
            // 
            this.grpBoxOpcoesConfig.BackColor = System.Drawing.Color.Silver;
            this.grpBoxOpcoesConfig.Controls.Add(this.lblTipoArquivo);
            this.grpBoxOpcoesConfig.Controls.Add(this.lstGeracao);
            this.grpBoxOpcoesConfig.Controls.Add(this.lblOpcoesProcessamento);
            this.grpBoxOpcoesConfig.Controls.Add(this.lsTipoArquivo);
            this.grpBoxOpcoesConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBoxOpcoesConfig.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grpBoxOpcoesConfig.Location = new System.Drawing.Point(12, 12);
            this.grpBoxOpcoesConfig.Name = "grpBoxOpcoesConfig";
            this.grpBoxOpcoesConfig.Size = new System.Drawing.Size(374, 351);
            this.grpBoxOpcoesConfig.TabIndex = 18;
            this.grpBoxOpcoesConfig.TabStop = false;
            this.grpBoxOpcoesConfig.Text = "Selecione as Opções desejadas:";
            // 
            // FrOpcoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(398, 375);
            this.Controls.Add(this.grpBoxOpcoesConfig);
            this.Name = "FrOpcoes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurações";
            this.grpBoxOpcoesConfig.ResumeLayout(false);
            this.grpBoxOpcoesConfig.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox lstGeracao;
        private System.Windows.Forms.ListBox lsTipoArquivo;
        private System.Windows.Forms.Label lblTipoArquivo;
        private System.Windows.Forms.Label lblOpcoesProcessamento;
        private System.Windows.Forms.GroupBox grpBoxOpcoesConfig;
    }
}