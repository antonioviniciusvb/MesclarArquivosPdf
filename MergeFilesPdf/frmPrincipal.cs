using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using Controle;
using System.IO;
using Vnsdll;


namespace MergeFilesPdf
{
    public partial class frPrincipal : Form
    {
        //object privado de controle
        private IndexadorInteiros controle;

        private List<FileInfo> infoArquivos;
        private DateTime time;
        //controle[0] == controle do button start
        //controle[1] == controle do método setarValoresTxtBox() -- ocioso
        //controle[2] == controle do event click do button btnSelectFiles()
        //controle[3] == controle do método definir definirNomesdeExclusao()
        //controle[4] == controle do para chamar método verificarDuplicidadeEndArq()


        //List que carregará os arquivos
        private List<Arquivo> lsArq, lsExclusao;

        private int qntArquivos;

        public frPrincipal()
        {

            InitializeComponent();
            getInfoAssembly();
            infoArquivos = new List<FileInfo>();
            controle = new IndexadorInteiros(0);
            criarColunasListView();
        }

        /// <summary>
        /// Método para inserir o número da versão do Assembly no text do form 
        /// </summary>
        private void getInfoAssembly()
        {
            var aux = AssemblyName.GetAssemblyName("MergeFilesPdf.exe");
            this.Text += String.Format(" -  Version: {0}", aux.Version);
            return;
        }

        /// <summary>
        /// Evento click do button start
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStart_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(ArqTexto.QntdArquivoTxt(lsArq[0].Nome).ToString());
            
            try
            {
                if (!(controle[0]))
                {
                    if (verificaQntdListView())
                    {
                        //if (Vnsdll.ValidacaoArquivo.validaExtensaoPdf(opf.FileNames.ToArray()))
                        //{
                            string nomeArqRelatorioArquivos = "Relatorio_", nomeArqMesclado = "", nomeArqRelatorioIntervaloPgs = "Relatorio_Intervalo_Pgs_";



                            toolStart.Image = Properties.Resources._1480398520_PauseNormalRed;
                            controle[0] = true;

                            //chamando método para carregar a classe com as informações dos arquivos
                            setarInfoFile();

                        //criando as capas de lote
                        for (int i = 0; i < lsArq.Count; i++)
                        {
                            Pdf.CriaCapasdeLotePdf(String.Format("Capa - {0}", infoArquivos[i].Name), lsArq[i].Pgs);
                        }

                        //string auxCapa = "";
                        //////criando as capas de lote txt
                        //for (int i = 0; i < lsArq.Count; i++)
                        //{
                        //    auxCapa = String.Format("Capa - {0}.pdf", infoArquivos[i].Name);
                        //    auxCapa = auxCapa.Replace(".TXT", "").Replace(".txt","");

                        //    Pdf.CriaCapasdeLotePdf(auxCapa, lsArq[i].Pgs);
                        //}


                        //instânciando classe MesclarPdf
                        MesclarPdf mPdf = new MesclarPdf();

                        //adicionando os arquivos para mescla 
                        for (int i = 0; i < lsArq.Count; i++)
                        {
                            mPdf.addArquivo(String.Format(infoArquivos[i].Name));
                        }

                        //instânciando a variável time para inserir a data no arquivo gerado
                        time = new DateTime();
                        time = DateTime.Now;

                        //chamando método de mescla
                        mPdf.MesclarArquivos(nomeArqMesclado = String.Format("MERGE-{0}{1}", String.Format("{0:dd-MM-yyyy_HH.mm.ss}", time)));


                        Pdf.CriarPdfApenasTexto(nomeArqRelatorioArquivos += String.Format("{0}.pdf", nomeArqMesclado), addInformacoesRelatorioArquivos(nomeArqMesclado));
                        Pdf.CriarPdfApenasTexto(nomeArqRelatorioIntervaloPgs += String.Format("{0}.pdf", nomeArqMesclado), addInformacoesRelatorioIntervaloPgs(nomeArqMesclado));


                        toolProgressBar.Value = 100;
                        toolProgressBar.ToolTipText = "Concluído";

                        toolStart.Image = Properties.Resources._1480398503_start;
                        MessageBox.Show("Todos os arquivos foram mesclados", "Operação realizada com sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        //}
                    }

                }
                else
                {
                    toolStart.Image = Properties.Resources._1480398503_start;
                    controle[0] = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Adicionando informações necessárias para gerar Relatório de Arquivos 
        /// </summary>
        /// <param name="nomeArquivoMesclado"></param>
        /// <returns></returns>
        private string addInformacoesRelatorioArquivos(string nomeArquivoMesclado)
        {
            string[] nomeArq;
            string InformacoesRelatorio = "";

            //cabeçalho do Relátorio de Arquivos 
            InformacoesRelatorio += String.Format("Arquivo Gerado: {0}\n---------------------------------Arquivos------------------------------------\n", nomeArquivoMesclado);

            //arquivos mesclados
            for (int i = 0; i < lsArq.Count; i++)
            {
                nomeArq = lsArq[i].Nome.Split('\\');
                InformacoesRelatorio += String.Format("Id: {0:00000}\n", lsArq[i].Id);
                InformacoesRelatorio += String.Format("Nome Arquivo: {0}\n", nomeArq[nomeArq.Length - 1]);
                InformacoesRelatorio += String.Format("Páginas: {0}\n", lsArq[i].Pgs);
                InformacoesRelatorio += "-----------------------------------------------------------------------------\n";
            }

            InformacoesRelatorio += String.Format("\n\nTOTAL = {0:00000}\n\n\n", Vnsdll.Pdf.ExtrairNumPgsArquivoPdf(nomeArquivoMesclado) - (lsArq.Count * 2));
            return InformacoesRelatorio;
        }

        /// <summary>
        /// Adicionando informações necessárias para gerar Relatório de Intervalo de Pgs
        /// </summary>
        /// <param name="nomeArquivoMesclado"></param>
        /// <returns></returns>
        private string addInformacoesRelatorioIntervaloPgs(string nomeArquivoMesclado)
        {
            string infoRelatorioPgs = "";
            int contPgs = 1;

            //cabeçalho do Relátorio de Intervalo de Pgs
            infoRelatorioPgs += String.Format("-------------------------------Intervalo de Pgs - Lotes----------------------\n");

            //adicionando as informações de intervalo
            for (int i = 0; i < lsArq.Count; i++)
            {
                infoRelatorioPgs += String.Format("                              Id:{0:0000} -- {1:000000} até {2:000000}\n", lsArq[i].Id, contPgs, contPgs += lsArq[i].Pgs + 1);
                contPgs++;
            }

            return infoRelatorioPgs;
        }

        /// <summary>
        /// Setando as informações dos Arquivos
        /// </summary>
        private void setarInfoFile()
        {
            for (int i = 0; i < lsArq.Count; i++)
            {
                infoArquivos.Add(new FileInfo(lsArq[i].Nome));
            }
        }
        /// <summary>
        /// Evento click do btnSelectFiles - reponsável por pegar os arquivos e setar no listViewer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectFiles_Click(object sender, EventArgs e)
        {
            try
            {
                if (opf.ShowDialog() == DialogResult.OK)
                {
                    if (opf.FileNames.Length > 0)
                    {
                        if (controle[2] == false)
                        {
                            criarListArquivos();
                            controle[2] = true;
                        }

                        if (controle[4] == true && verificarDuplicidadeEndArq() == false)
                        {
                            addItensList();
                            lstViewerArquivos.Items.Clear();
                            setarListViewcomArquivos();
                        }
                        else
                        {
                            addItensList();
                            lstViewerArquivos.Items.Clear();
                            setarListViewcomArquivos();
                            controle[4] = true;
                        }

                        setarValoresTxtBox();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return;
        }

        /// <summary>
        /// Método para garantir que não terá arquivos iguais
        /// </summary>
        /// <returns></returns>
        private bool verificarDuplicidadeEndArq()
        {
            for (int j = 0; j < opf.FileNames.Length; j++)
            {
                for (int i = 0; i < lsArq.Count; i++)
                {
                    if (lsArq[i].Nome.Equals(opf.FileNames[j]))
                        throw new Exception(String.Format("Arquivo já existente : {0} ", opf.FileNames[j]));
                }

            }

            return true;
        }

        /// <summary>
        /// Método para Adicionar itens no List
        /// </summary>
        private void addItensList()
        {
            int[] pgs;

            if (rdbPdf.Checked == true)
            pgs = Vnsdll.Pdf.ExtrairNumPgsArquivoPdf(opf.FileNames);
            else
              pgs = ArqTexto.QntdArquivoTxt(opf.FileNames, lstbLogica.SelectedIndex).ToArray<int>();



            for (int i = 0; i < opf.FileNames.Length; i++)
            {
                incrementarValorQntdArquivos();

                lsArq.Add(new Arquivo
                {
                    Id = qntArquivos,
                    Nome = opf.FileNames[i],
                    Pgs = pgs[i]
                });


                //for (int i = 0; i < opf.FileNames.Length; i++)
                //{
                //    incrementarValorQntdArquivos();

                //    lsArq.Add(new Arquivo
                //    {
                //        Id = qntArquivos,
                //        Nome = opf.FileNames[i],
                //        Pgs = pgs
                //    });
                //}

            }
        }
        /// <summary>
        /// Método para mostrar os arquivos selecionados na txtBox
        /// </summary>
        private void setarValoresTxtBox()
        {
            txtBoxArquivosSelecionados.Text = "";

            for (int i = 0; i < lsArq.Count(); i++)
            {
                txtBoxArquivosSelecionados.Text += (String.Format("Arquivo {0}: {1};", i + 1, lsArq[i].Nome));
            }

            if (txtBoxArquivosSelecionados.Text.Length > 1)
            {
                //retirando o ; do final da string
                txtBoxArquivosSelecionados.Text = txtBoxArquivosSelecionados.Text.Remove(txtBoxArquivosSelecionados.Text.Length - 1);
            }
            return;
        }

        /// <summary>
        /// Método para incrementar +1 no valor da variável qntArquivos
        /// </summary>
        private void incrementarValorQntdArquivos()
        {
            qntArquivos++;
            return;
        }

        /// <summary>
        /// Método para instânciar um list  
        /// </summary>
        private void criarListArquivos()
        {
            lsArq = new List<Arquivo>();
            return;
        }

        /// <summary>
        /// Método para instânciar um list  
        /// </summary>
        private void criarListExclusao()
        {
            lsExclusao = new List<Arquivo>();
            return;
        }
        /// <summary>
        /// Método para setar os dados do lsArquivos no ListViewer
        /// </summary>
        private void setarListViewcomArquivos()
        {
            //criando um array de propriedade da classe Arquivo
            var info = typeof(Arquivo).GetProperties();

            //Percorre lista de Arquivos
            foreach (Arquivo cliente in lsArq)
            {
                //Adiciona um item em branco no listView
                ListViewItem item = lstViewerArquivos.Items.Add("");

                lstViewerArquivos.CheckBoxes = true;
                item.Text = "";

                foreach (PropertyInfo p in info)
                {
                    item.Checked = true;
                    item.SubItems.Add(p.GetValue(cliente, null).ToString());

                }
            }

            return;
        }

        /// <summary>
        /// Método para criar as colunas do listViewer com base nos campos da classe Arquivo
        /// </summary>
        private void criarColunasListView()
        {
           
            //definindo a view do lisviewer com details, para mostrar o header
            lstViewerArquivos.View = View.Details;

            //criando um array de propriedade da classe Arquivo
            var info = typeof(Arquivo).GetProperties();

            ColumnHeader col1 = new ColumnHeader();
            col1.Text = "";
            col1.Width = 25;

            foreach (var item in info)
            {
                //criando nova coluna
                ColumnHeader col = new ColumnHeader();

                if (!(controle[1]))
                {
                    controle[1] = true;
                    lstViewerArquivos.Columns.Add(col1);
                }

                col.Text = item.Name;

                if (col.Text.Equals("Id") || col.Text.Equals("Pgs"))
                {
                    col.TextAlign = HorizontalAlignment.Center;
                    col.Width = -2;
                }
                else
                {
                    col.Width = 630;
                    col.TextAlign = HorizontalAlignment.Left;
                }

                //adicionando a coluna no listviewer
                lstViewerArquivos.Columns.Add(col);
            }
            return;
        }

        /// <summary>
        /// Evento keydown da ListViewer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lsArquivos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("Deseja excluir a seleção ?", "Atencão!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    definirNomesdeExclusao();
                    removerItensdaList();
                    lstViewerArquivos.Items.Clear();
                    setarListViewcomArquivos();
                    lstViewerArquivos.Refresh();
                    setarValoresTxtBox();
                }
            }
        }

        /// <summary>
        /// Método para limpar os items selecionados para exclusão da ListViewer
        /// </summary>
        private void definirNomesdeExclusao()
        {
            string aux1 = "", aux2 = "";
            string[] arquivosdeExclusao;

            //capturando todos os itens selecionados na ListViewer
            var items = lstViewerArquivos.SelectedItems.Cast<ListViewItem>().ToArray();

            if (controle[3] == false)
            {
                criarListExclusao();
                controle[3] = true;
            }

            for (int i = 0; i < items.Length; i++)
            {
                aux1 = "";

                for (int j = 0; j < items[i].SubItems.Count; j++)
                {
                    aux1 += items[i].SubItems[j].ToString();
                }

                aux2 = aux1.Replace("ListViewSubItem: ", "");
                aux1 = aux2.Replace("}", "");
                aux2 = aux1.Remove(0, 1);

                arquivosdeExclusao = aux2.Split('{');

                //criando list de exclusão
                lsExclusao.Add(new Arquivo
                {
                    Id = int.Parse(arquivosdeExclusao[1]),
                    Nome = arquivosdeExclusao[2],
                    Pgs = int.Parse(arquivosdeExclusao[3])

                });
            }

            return;
        }

        /// <summary>
        /// Método para excluir os itens  no lsArq, onde foram selecionados no Listviewer para exclusão 
        /// </summary>
        private void removerItensdaList()
        {
            for (int i = 0; i < lsExclusao.Count(); i++)
            {
                lsArq.Remove(lsArq.Find(x => x.Id == lsExclusao[i].Id));
            }

            lsExclusao.Clear();

            return;
        }

  


        /// <summary>
        /// Método para verificar se tem algum item no listviewer
        /// </summary>
        /// <returns></returns>
        private bool verificaQntdListView()
        {
            if (lstViewerArquivos.Items.Count > 1)
                return true;
            else
                throw new Exception("Lista não contém itens necessários para mescla!");
        }
    }
}
