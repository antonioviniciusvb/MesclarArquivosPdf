using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MergeFilesPdf
{
    public partial class FrOpcoes : Form
    {

        private string[] txtTipo = new string[] {
            "Selecione um opção:",
            "1 - Arquivo de Texto (.txt)",
            "2 - Arquivo de Documento (.pdf)"
        };

        private string[] txtGeracaoConfigPdf = new string[] {
            "Selecione um opção:",
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
            "Selecione um opção:",
            "1 - Capas",
            "2 - Capas e Relatório com qntd dos Arquivos ",
            "3 - Relatório com Qntd dos Arquivos"
        };
        public FrOpcoes()
        {
            InitializeComponent();
            setarListBoxTipo(txtTipo);
            
        }

        private void setarListBoxGeracao(string[] txt)
        {
            lstGeracao.DataSource = txt;
        }

        private void setarListBoxTipo(string[] txt)
        {
            lsTipoArquivo.DataSource = txtTipo;
        }

        private void lsTipoArquivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lsTipoArquivo.SelectedIndex == 1)
            {
                setarListBoxGeracao(txtGeracaoConfigTexto);
            }
            else if (lsTipoArquivo.SelectedIndex == 2)
            {
                setarListBoxGeracao(txtGeracaoConfigPdf);
            }
        }
    }
}
