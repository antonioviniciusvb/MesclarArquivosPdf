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

namespace MergeFilesPdf
{
    public partial class FrOpcoes : Form
    {
        #region Variáveis Privadas
        private string[] txtTipo = new string[] {
            "Selecione uma opção:",
            "1 - Arquivo de Texto (.txt)",
            "2 - Arquivo de Documento (.pdf)"
        };

        private string[] txtGeracaoConfigPdf = new string[] {
            "Selecione uma opção:",
            "1 - Apenas Capas",
            "2 - Apenas Mesclar Arquivos",
            "3 - Capas e Mesclar",
            "4 - Capas, Mesclar e Relatório de Intervalo de pgs",
            "5 - Capas, Mesclar e Relatório com qntd dos Arquivos",
            "6 - Capas, Mesclar e Todos os Relatórios ",
            "7 - Mesclar e Relatório de Intervalo de pgs",
            "8 - Mesclar e Relatório com Qntd dos Arquivos",
            "9 - Mesclar e Todos os Relatórios "
        };


        private string[] txtGeracaoConfigTexto = new string[] {
            "Selecione uma opção:",
            "1 - Capas",
            "2 - Capas e Relatório com qntd dos Arquivos ",
            "3 - Relatório com Qntd dos Arquivos"
        };


        private string[] txtLogicaArqTxt = new string[] {
            "Selecione uma opção:",
            "1 Registro - 1 linha",
            "1 Registro - 2 linhas",
            "1 Regsitro - 3 linhas",
            "1 Registro - 4 linhas",
            "1 Registro - 5 linhas",
            "Desconsiderar 1 linha",
            "Prefeitura de Brusque - contas de água"
        };

        private string[] txtLogicaArqPdf = new string[] {
            "Selecione uma opção:",
            "Simplex",
            "Duplex"
        };

        public int[] txtResultListBox;

#endregion

        public FrOpcoes()
        {
            InitializeComponent();

            //setarListBoxTipo(txtTipo);    
            setarListBox(lsTipoArquivo, txtTipo);
        }

        /// <summary>
        /// Método para setar os valores do array de string conforme o index selecionado do lstTipoArquivo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lsTipoArquivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lsTipoArquivo.SelectedIndex == 1)
            {
                setarListBox(lstGeracao, txtGeracaoConfigTexto);
                setarListBox(lstBoxLogica, txtLogicaArqTxt);

            }
            else if (lsTipoArquivo.SelectedIndex == 2)
            {
                setarListBox(lstGeracao, txtGeracaoConfigPdf);
                setarListBox(lstBoxLogica, txtLogicaArqPdf);
            }
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
        private bool verificaListBoxes()
        {
            if (lsTipoArquivo.SelectedIndex == 0 || lstBoxLogica.SelectedIndex == 0 || lstGeracao.SelectedIndex == 0)
                return false;
            else
                return true;
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


        }

        /// <summary>
        /// Evento para iniciar form principal, passando por parâmetro os resultados, pelo método main do program.cs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (verificaListBoxes())
            {
                //instânciando resultados
                txtResultListBox = new int[]
                {
                    lsTipoArquivo.SelectedIndex,
                    lstGeracao.SelectedIndex,
                    lstBoxLogica.SelectedIndex
                };

                //passando resultados
                DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("É obrigatório a seleção de todos os campos.", "Verifique todos o campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
