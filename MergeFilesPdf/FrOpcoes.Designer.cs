using System;

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
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.lsTipoArquivo = new System.Windows.Forms.ListBox();
            this.txtPos_X = new System.Windows.Forms.TextBox();
            this.txtPos_Y = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rdRelatorioNao = new System.Windows.Forms.RadioButton();
            this.grbSplit = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtRotacao = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdRelatorioSim = new System.Windows.Forms.RadioButton();
            this.numSplit = new System.Windows.Forms.NumericUpDown();
            this.lstBoxLogica = new System.Windows.Forms.ListBox();
            this.lbLogica = new System.Windows.Forms.Label();
            this.lstGeracao = new System.Windows.Forms.ListBox();
            this.lblOpcoesProcessamento = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.grbSplit.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSplit)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(191, 434);
            this.btnLimpar.Margin = new System.Windows.Forms.Padding(4);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(113, 31);
            this.btnLimpar.TabIndex = 19;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnAplicar
            // 
            this.btnAplicar.Location = new System.Drawing.Point(333, 434);
            this.btnAplicar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(113, 31);
            this.btnAplicar.TabIndex = 20;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(477, 434);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(113, 31);
            this.btnOk.TabIndex = 22;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lsTipoArquivo
            // 
            this.lsTipoArquivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsTipoArquivo.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lsTipoArquivo.FormattingEnabled = true;
            this.lsTipoArquivo.ItemHeight = 22;
            this.lsTipoArquivo.Location = new System.Drawing.Point(132, 44);
            this.lsTipoArquivo.Margin = new System.Windows.Forms.Padding(4);
            this.lsTipoArquivo.Name = "lsTipoArquivo";
            this.lsTipoArquivo.Size = new System.Drawing.Size(562, 26);
            this.lsTipoArquivo.TabIndex = 15;
            this.lsTipoArquivo.SelectedIndexChanged += new System.EventHandler(this.lsTipoArquivo_SelectedIndexChanged);
            // 
            // txtPos_X
            // 
            this.txtPos_X.Location = new System.Drawing.Point(54, 54);
            this.txtPos_X.MaxLength = 5;
            this.txtPos_X.Name = "txtPos_X";
            this.txtPos_X.Size = new System.Drawing.Size(48, 22);
            this.txtPos_X.TabIndex = 26;
            this.txtPos_X.Text = "0";
            this.txtPos_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPos_X.TextChanged += new System.EventHandler(this.txtPos_X_TextChanged);
            // 
            // txtPos_Y
            // 
            this.txtPos_Y.Location = new System.Drawing.Point(114, 54);
            this.txtPos_Y.MaxLength = 5;
            this.txtPos_Y.Name = "txtPos_Y";
            this.txtPos_Y.Size = new System.Drawing.Size(48, 22);
            this.txtPos_Y.TabIndex = 27;
            this.txtPos_Y.Text = "0";
            this.txtPos_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPos_Y.TextChanged += new System.EventHandler(this.txtPos_Y_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 17);
            this.label1.TabIndex = 28;
            this.label1.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(129, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 17);
            this.label2.TabIndex = 29;
            this.label2.Text = "Y";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(177, 17);
            this.label4.TabIndex = 31;
            this.label4.Text = "Registros MAX por arquivo";
            // 
            // rdRelatorioNao
            // 
            this.rdRelatorioNao.AutoSize = true;
            this.rdRelatorioNao.Location = new System.Drawing.Point(69, 29);
            this.rdRelatorioNao.Name = "rdRelatorioNao";
            this.rdRelatorioNao.Size = new System.Drawing.Size(55, 21);
            this.rdRelatorioNao.TabIndex = 34;
            this.rdRelatorioNao.TabStop = true;
            this.rdRelatorioNao.Text = "Não";
            this.rdRelatorioNao.UseVisualStyleBackColor = true;
            this.rdRelatorioNao.CheckedChanged += new System.EventHandler(this.rdRelatorioNao_CheckedChanged);
            // 
            // grbSplit
            // 
            this.grbSplit.BackColor = System.Drawing.Color.White;
            this.grbSplit.Controls.Add(this.groupBox1);
            this.grbSplit.Controls.Add(this.groupBox2);
            this.grbSplit.Controls.Add(this.label4);
            this.grbSplit.Controls.Add(this.numSplit);
            this.grbSplit.Enabled = false;
            this.grbSplit.Location = new System.Drawing.Point(492, 119);
            this.grbSplit.Name = "grbSplit";
            this.grbSplit.Size = new System.Drawing.Size(306, 269);
            this.grbSplit.TabIndex = 35;
            this.grbSplit.TabStop = false;
            this.grbSplit.Text = "Modo Split";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.txtRotacao);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPos_Y);
            this.groupBox1.Controls.Add(this.txtPos_X);
            this.groupBox1.Location = new System.Drawing.Point(17, 155);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 92);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Identificação de Arquivos";
            // 
            // txtRotacao
            // 
            this.txtRotacao.Location = new System.Drawing.Point(175, 54);
            this.txtRotacao.MaxLength = 3;
            this.txtRotacao.Name = "txtRotacao";
            this.txtRotacao.Size = new System.Drawing.Size(48, 22);
            this.txtRotacao.TabIndex = 39;
            this.txtRotacao.Text = "0";
            this.txtRotacao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(172, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 17);
            this.label7.TabIndex = 38;
            this.label7.Text = "Rotação";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdRelatorioSim);
            this.groupBox2.Controls.Add(this.rdRelatorioNao);
            this.groupBox2.Location = new System.Drawing.Point(17, 32);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(274, 66);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gerar Relatório ";
            // 
            // rdRelatorioSim
            // 
            this.rdRelatorioSim.AutoSize = true;
            this.rdRelatorioSim.Location = new System.Drawing.Point(171, 29);
            this.rdRelatorioSim.Name = "rdRelatorioSim";
            this.rdRelatorioSim.Size = new System.Drawing.Size(52, 21);
            this.rdRelatorioSim.TabIndex = 33;
            this.rdRelatorioSim.TabStop = true;
            this.rdRelatorioSim.Text = "Sim";
            this.rdRelatorioSim.UseVisualStyleBackColor = true;
            this.rdRelatorioSim.CheckedChanged += new System.EventHandler(this.rdRelatorioSim_CheckedChanged);
            // 
            // numSplit
            // 
            this.numSplit.Location = new System.Drawing.Point(216, 115);
            this.numSplit.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numSplit.Name = "numSplit";
            this.numSplit.Size = new System.Drawing.Size(66, 22);
            this.numSplit.TabIndex = 0;
            this.numSplit.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numSplit.ValueChanged += new System.EventHandler(this.numSplit_ValueChanged);
            // 
            // lstBoxLogica
            // 
            this.lstBoxLogica.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBoxLogica.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lstBoxLogica.FormattingEnabled = true;
            this.lstBoxLogica.HorizontalScrollbar = true;
            this.lstBoxLogica.ItemHeight = 18;
            this.lstBoxLogica.Location = new System.Drawing.Point(40, 263);
            this.lstBoxLogica.Margin = new System.Windows.Forms.Padding(4);
            this.lstBoxLogica.Name = "lstBoxLogica";
            this.lstBoxLogica.Size = new System.Drawing.Size(432, 112);
            this.lstBoxLogica.TabIndex = 18;
            this.lstBoxLogica.SelectedIndexChanged += new System.EventHandler(this.lstBoxLogica_SelectedIndexChanged);
            // 
            // lbLogica
            // 
            this.lbLogica.AutoSize = true;
            this.lbLogica.Enabled = false;
            this.lbLogica.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLogica.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lbLogica.Location = new System.Drawing.Point(36, 237);
            this.lbLogica.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbLogica.Name = "lbLogica";
            this.lbLogica.Size = new System.Drawing.Size(59, 20);
            this.lbLogica.TabIndex = 19;
            this.lbLogica.Text = "Lógica";
            // 
            // lstGeracao
            // 
            this.lstGeracao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstGeracao.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lstGeracao.FormattingEnabled = true;
            this.lstGeracao.HorizontalScrollbar = true;
            this.lstGeracao.ItemHeight = 18;
            this.lstGeracao.Location = new System.Drawing.Point(40, 119);
            this.lstGeracao.Margin = new System.Windows.Forms.Padding(4);
            this.lstGeracao.Name = "lstGeracao";
            this.lstGeracao.Size = new System.Drawing.Size(436, 112);
            this.lstGeracao.TabIndex = 14;
            this.lstGeracao.SelectedIndexChanged += new System.EventHandler(this.lstGeracao_SelectedIndexChanged);
            // 
            // lblOpcoesProcessamento
            // 
            this.lblOpcoesProcessamento.AutoSize = true;
            this.lblOpcoesProcessamento.Enabled = false;
            this.lblOpcoesProcessamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpcoesProcessamento.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lblOpcoesProcessamento.Location = new System.Drawing.Point(40, 92);
            this.lblOpcoesProcessamento.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOpcoesProcessamento.Name = "lblOpcoesProcessamento";
            this.lblOpcoesProcessamento.Size = new System.Drawing.Size(73, 20);
            this.lblOpcoesProcessamento.TabIndex = 17;
            this.lblOpcoesProcessamento.Text = "Geração";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FrOpcoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(841, 483);
            this.Controls.Add(this.lbLogica);
            this.Controls.Add(this.lstBoxLogica);
            this.Controls.Add(this.lblOpcoesProcessamento);
            this.Controls.Add(this.lstGeracao);
            this.Controls.Add(this.grbSplit);
            this.Controls.Add(this.lsTipoArquivo);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnAplicar);
            this.Controls.Add(this.btnLimpar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrOpcoes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurações";
            this.grbSplit.ResumeLayout(false);
            this.grbSplit.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSplit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ListBox lsTipoArquivo;
        private System.Windows.Forms.TextBox txtPos_X;
        private System.Windows.Forms.TextBox txtPos_Y;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rdRelatorioNao;
        private System.Windows.Forms.GroupBox grbSplit;
        private System.Windows.Forms.RadioButton rdRelatorioSim;
        private System.Windows.Forms.Label lbLogica;
        private System.Windows.Forms.ListBox lstBoxLogica;
        private System.Windows.Forms.ListBox lstGeracao;
        private System.Windows.Forms.Label lblOpcoesProcessamento;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtRotacao;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numSplit;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}