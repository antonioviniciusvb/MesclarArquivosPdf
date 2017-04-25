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

            if(lsTipoArquivo.SelectedIndex == 1)
            {
                setarListBox(lstGeracao, Configuracao.txtGeracaoConfigTexto);
                setarListBox(lstBoxLogica, Configuracao.txtLogicaArqTxt);

            }
            else if (lsTipoArquivo.SelectedIndex == 2)
            {
                setarListBox(lstGeracao, Configuracao.txtGeracaoConfigPdf);
                setarListBox(lstBoxLogica, Configuracao.txtLogicaArqPdf);
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
            if((lsTipoArquivo.SelectedIndex != 0) && (lstBoxLogica.SelectedIndex != 0) && (lstGeracao.SelectedIndex != 0))
                btnAplicar.Enabled = true;
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

            limparButtons();
        }

        /// <summary>
        /// Evento para iniciar form principal, passando por parâmetro os resultados, pelo método main do program.cs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIniciar_Click(object sender, EventArgs e)
        {
                //instânciando resultados
                txtResultListBox = new int[]
                {
                    lsTipoArquivo.SelectedIndex,
                    lstGeracao.SelectedIndex,
                    lstBoxLogica.SelectedIndex
                };

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
            Configuracao.CriarArquivoConfig(txtResultListBox);
            this.Close();
        }
    }
}
