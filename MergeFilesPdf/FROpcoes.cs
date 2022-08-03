using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace MergeFilesPdf
{
    public partial class FrOpcoes : Form
    {
        #region Variáveis Privadas
        public int[] txtResultListBox;

        #endregion

        public FrOpcoes()
        {
            InitializeComponent();
            limparButtons();
            Configuracao.DeletarArqConfig();
            setarListBox(lsTipoArquivo, Configuracao.txtTipo);
        }

        public FrOpcoes(int tipo)
        {
            InitializeComponent();
            limparButtons();
        }
        /// <summary>
        /// Método para limpar os buttons
        /// </summary>
        private void limparButtons()
        {
            btnOk.Enabled = false;
            btnAplicar.Enabled = false;
        }

        /// <summary>
        /// Método para setar os valores do array de string conforme o index selecionado do lstTipoArquivo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lsTipoArquivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnLimpar.Enabled = true;
            
            if (lsTipoArquivo.SelectedIndex == 1)
            {
                grbSplit.Enabled = false;
                setarListBox(lstGeracao, Configuracao.txtGeracaoConfigTexto);
                setarListBox(lstBoxLogica, Configuracao.txtLogicaArqTxt);
            }
            else if (lsTipoArquivo.SelectedIndex == 2)
            {
                grbSplit.Enabled = false;
                setarListBox(lstGeracao, Configuracao.txtGeracaoConfigPdf);
                setarListBox(lstBoxLogica, Configuracao.txtLogicaArqPdf);
            }
            else
            if (lsTipoArquivo.SelectedIndex == 3)
            {
                setarListBox(lstBoxLogica, Configuracao.txtLogicaArqPdf);
                lstGeracao.DataSource = new string[] { "Utilize as opções do Modo Split" };
                //lstBoxLogica.DataSource = new string[] { "Utilize as opções do Modo Split" };
                grbSplit.Enabled = true;
            }
                
            verificaListBoxes();
        }

        /// <summary>
        /// Método para setar o conteúdo dos ListBox
        /// </summary>
        /// <param name="txt"></param>
        private void setarListBox(ListBox list, string[] txt)
        {
            list.DataSource = txt;
            return;
        }

        /// <summary>
        /// Método para verificar se todos os listBoxes foram selecionados
        /// </summary>
        /// <returns></returns>
        private void verificaListBoxes()
        {
            if (((lsTipoArquivo.SelectedIndex != 0) && (lstBoxLogica.SelectedIndex != 0) && (lstGeracao.SelectedIndex != 0))
               ||((lsTipoArquivo.SelectedIndex == 3 && lstBoxLogica.SelectedIndex != 0) && ((rdRelatorioNao.Checked == true 
               || rdRelatorioSim.Checked == true) && (txtPos_X.Text != "0" && txtPos_Y.Text != "0" && txtPos_X.Text.Length > 0
               && txtPos_Y.Text.Length > 0) && lstBoxLogica.SelectedIndex != 0)))
            {
                btnAplicar.Enabled = true;

            }
            else
                btnAplicar.Enabled = false;
        }


        /// <summary>
        ///Método para limpar componentes 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limpar();
        }

        private void limpar()
        {
            //limpando todos os componentes
            lsTipoArquivo.SelectedIndex = 0;

            if (lstBoxLogica.Items.Count > 0)
                lstBoxLogica.SelectedIndex = 0;
            else
                lstBoxLogica.ClearSelected();

            if (lstGeracao.Items.Count > 0)
                lstGeracao.SelectedIndex = 0;
            else
                lstGeracao.ClearSelected();

            txtPos_X.Text = "0";
            txtPos_Y.Text = "0";
            txtRotacao.Text = "0";
            rdRelatorioSim.Checked = false;
            rdRelatorioNao.Checked = false;

            numSplit.Value = 1000;

            limparButtons();
        }

        /// <summary>
        /// Evento para iniciar form principal, passando por parâmetro os resultados, pelo método main do program.cs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (lsTipoArquivo.SelectedIndex == 1 || lsTipoArquivo.SelectedIndex == 2)
            {
                //instânciando resultados
                txtResultListBox = new int[]
                {
                    lsTipoArquivo.SelectedIndex,
                    lstGeracao.SelectedIndex,
                    lstBoxLogica.SelectedIndex
                };
            }

            btnAplicar.Enabled = false;
            btnOk.Enabled = true;
        }



        private void lstGeracao_SelectedIndexChanged(object sender, EventArgs e)
        {
            verificaListBoxes();
        }

        private void lstBoxLogica_SelectedIndexChanged(object sender, EventArgs e)
        {
            verificaListBoxes();
        }

        /// <summary>
        /// Evento parar o arquivo de criação
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (lsTipoArquivo.SelectedIndex == 1 || lsTipoArquivo.SelectedIndex == 2)
                Configuracao.CriarArquivoConfig(txtResultListBox);
            else
            {
                if (verificaMax((int)numSplit.Value))
                {
                    string resultConfig = splitResult();
                    Configuracao.CriarArquivoConfig(resultConfig);
                }
            }

            this.Close();
        }

        private string splitResult()
        {
            StringBuilder st = new StringBuilder();

            st.Append("3;");

            st.Append(rdRelatorioNao.Checked == true ? "0;" : "1;");

            //relatorio
            //if (rdRelatorioNao.Checked == true)
            //    st.Append("0;");
            //else
            //    st.Append("1;");


            //max;x;y;r
            st.Append($"{numSplit.Value};{txtPos_X.Text};{txtPos_Y.Text};{txtRotacao.Text};{lstBoxLogica.SelectedIndex}");

            return st.ToString();
        }

        private void rdRelatorioNao_CheckedChanged(object sender, EventArgs e)
        {
            verificaObjetosModoSplit();
        }

        private void verificaObjetosModoSplit()
        {
            if((rdRelatorioNao.Checked == true || rdRelatorioSim.Checked == true) &&
            (txtPos_X.Text != "0" && txtPos_Y.Text != "0" && txtPos_X.Text.Length > 0 && txtPos_Y.Text.Length > 0) &&
               lstBoxLogica.SelectedIndex != 0)
            {
                if(verificaCoordenardas(txtPos_X.Text, txtPos_X) && verificaCoordenardas(txtPos_Y.Text, txtPos_Y))
                    btnAplicar.Enabled = true;
                else
                    btnAplicar.Enabled = false;
            }
        }

        private bool verificaMax(int value)
        {
            if (value % 2 == 0)
                return true;
            else
            {
                MessageBox.Show("O número Max deverá ser par", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                numSplit.Value = 1000;
                return false;
            }     
        }

        private bool verificaCoordenardas(string text, TextBox textBox)
        {
            string pattern = @"^[0-9]+$";
            Regex regex = new Regex(pattern);
            MatchCollection match = regex.Matches(text);
            if (match.Count > 0)
                return true;
            else
            {
                MessageBox.Show("Campo permite apenas números", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox.Text = "0";
                return false;
            }

        }

        private void rdRelatorioSim_CheckedChanged(object sender, EventArgs e)
        {
            verificaObjetosModoSplit();
        }

        private void rdCapaSim_CheckedChanged(object sender, EventArgs e)
        {
            verificaObjetosModoSplit();
        }

        private void rdCapaNao_CheckedChanged(object sender, EventArgs e)
        {
            verificaObjetosModoSplit();
        }

        private void txtPos_X_TextChanged(object sender, EventArgs e)
        {
            verificaObjetosModoSplit();
        }

        private void txtPos_Y_TextChanged(object sender, EventArgs e)
        {
            verificaObjetosModoSplit();
        }

        private void numSplit_ValueChanged(object sender, EventArgs e)
        {
            verificaObjetosModoSplit();
        }
    }
}
