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
using System.Diagnostics;


namespace MergeFilesPdf
{
    public partial class FRPrincipal : Form
    {
        //object privado de controle
        private IndexadorInteiros controle;

        private List<FileInfo> infoArquivos;
        private DateTime time;
        //controle[0] == controle do button start
        //controle[1] == controle do método setarValoresTxtBox() -- ocioso
        //controle[2] == controle do event click do button btnSelectFiles()
        //controle[3] == controle do método definir definirNomesdeExclusao()
        //controle[4] == controle  para chamar método verificarDuplicidadeEndArq()

        private string config;

        //List que carregará os arquivos
        private List<Arquivo> lsArq, lsExclusao;


        private Detalhe details;
        

        private int qntArquivos;

        public FRPrincipal()
        {
            InitializeComponent();
            getInfoAssembly();
            limparArqConfig();
            infoArquivos = new List<FileInfo>();
            controle = new IndexadorInteiros(0);
            criarColunasListView(lstViewerArquivos, "MergeFilesPdf.Arquivo");
            criarColunasListView(lstViewerDetalhes, "MergeFilesPdf.Detalhe");
        }

        private void definirConfigForm()
        {
            config = lerArqConfig();
            if (config[0] == '1')
                opf.Filter = "Arquivos de Texto|*.txt";
            else
                opf.Filter = "Arquivos Pdf|*.pdf";
        }

        private string lerArqConfig()
        {
            string linha = "", aux = "";
            using (StreamReader str = new StreamReader(Configuracao.txtConfig))
                while ((aux = str.ReadLine()) != null)
                    linha = aux;
            return linha;
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
        /// Método para limpar o arquivo de configuração
        /// </summary>
        private void limparArqConfig()
        {
            //limpando arquivo de configuração
            try
            {
                using (StreamWriter stw = new StreamWriter(Configuracao.txtConfig,false))
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

        }
        /// <summary>
        /// Evento click do button start
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStart_Click(object sender, EventArgs e)
        {
            try
            {
    
                if (!(controle[0]))
                {
                    if (verificaQntdListView())
                    {
                        switch (config[0])
                        {
                            
                            //************** Entrada para Funções de txt *******************
                            case '1':
                                
                                switch (config[1])
                                {
                                    case '1':
                                        //Gerar Apenas Capas 
                                        for (int i = 0; i < lsArq.Count; i++)
                                            Pdf.CriaCapasdeLoteArqTxt(lsArq[i].Nome, lsArq[i].Pgs);
                                        break;

                                        

                                    case '2':

                                        string nomeArqRelatorioArquivos = string.Format("Relatorio_Total_{0}.pdf", details.Total);

                                        //Gerar Capas e relatório qntd 
                                        for (int i = 0; i < lsArq.Count; i++)
                                        {
                                            Pdf.CriaCapasdeLoteArqTxt(lsArq[i].Nome, lsArq[i].Pgs);
                                            Pdf.CriarPdfApenasTexto(nomeArqRelatorioArquivos, addInformacoesRelatorioArquivosTxt(lsArq));
                                        }
                                        break;

                                    case '3':
                                        //Gerar Capas e relatório qntd 
                                        for (int i = 0; i < lsArq.Count; i++)
                                        {
                                            string nomeArqRelatorioArquivos2 = string.Format("Relatorio_Total_{0}.pdf", details.Total);

                                            //Gerar Apenas Relatório qntd
                                            addInformacoesRelatorioArquivosTxt(lsArq);
                                            Pdf.CriarPdfApenasTexto(nomeArqRelatorioArquivos2, addInformacoesRelatorioArquivosTxt(lsArq));
                                        }
                                        
                                        break;
                                }
                                // ************************* Fim *****************************
                                break;

                            //Entrada para Funções de pdf
                            case '2':

                                switch (config[1])
                                {
                                    
                                }

                                break;
                        }

                      // 
                        //string[] nomesDasCapas = new string[lsArq.Count];


                        toolStart.Image = Properties.Resources._1480398520_PauseNormalRed;
                        controle[0] = true;

                        //chamando método para carregar a classe com as informações dos arquivos
                        setarInfoFile();

                        ////criando as capas de lote
                        //for (int i = 0; i < lsArq.Count; i++)
                        //{
                        //    Pdf.CriaCapasdeLotePdf(String.Format("Capa_{0}", infoArquivos[i].Name), lsArq[i].Pgs);
                        //}

                        //string[] nomeCapas = Pdf.getNomeCapas();



                        


                        ////instânciando classe MesclarPdf
                        //MesclarPdf mPdf = new MesclarPdf();

                        ////adicionando os arquivos para mescla
                        //for (int i = 0; i < lsArq.Count; i++)
                        //{
                        //    mPdf.addArquivo(String.Format(lsArq[i].Nome));
                        //    //mPdf.addArquivo(nomeCapas[i]);
                        //}


                        //Pdf.limparListDeCapas();

                        //instânciando a variável time para inserir a data no arquivo gerado
                        time = new DateTime();
                        time = DateTime.Now;

                        //chamando método de mescla
                        //mPdf.MesclarArquivos(nomeArqMesclado = String.Format("MERGE-{0}.pdf", String.Format("{0:dd-MM-yyyy_HH.mm.ss}", time)));


                        //Pdf.CriarPdfApenasTexto(nomeArqRelatorioArquivos += String.Format("{0}.pdf", nomeArqMesclado), addInformacoesRelatorioArquivosPdf(nomeArqMesclado));
                        //Pdf.CriarPdfApenasTexto(nomeArqRelatorioIntervaloPgs += String.Format("{0}.pdf", nomeArqMesclado), addInformacoesRelatorioIntervaloPgs(nomeArqMesclado));


                        toolProgressBar.Value = 100;
                        toolProgressBar.ToolTipText = "Concluído";

                        toolStart.Image = Properties.Resources._1480398503_start;
                        MessageBox.Show("Todos os arquivos foram mesclados", "Operação realizada com sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
        private string addInformacoesRelatorioArquivosPdf(string nomeArquivoMesclado)
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
        /// Adicionando informações necessárias para gerar Relatório de Arquivos 
        /// </summary>
        /// <param name="nomeArquivoMesclado"></param>
        /// <returns></returns>
        private string addInformacoesRelatorioArquivosTxt(List<Arquivo> ls)
        {
            string[] nomeArq;
            string InformacoesRelatorio = "";

            //cabeçalho do Relátorio de Arquivos 
            InformacoesRelatorio+=String.Format("---------------------------------Arquivos------------------------------------\n");

            //arquivos mesclados
            for (int i = 0; i<ls.Count; i++)
            {
                nomeArq=ls[i].Nome.Split('\\');
                InformacoesRelatorio += String.Format("Id: {0:00000}\n", ls[i].Id);
                InformacoesRelatorio += String.Format("Nome Arquivo: {0}\n", nomeArq[nomeArq.Length-1]);
                InformacoesRelatorio += String.Format("Qntd: {0}\n", ls[i].Pgs);
                InformacoesRelatorio += "-----------------------------------------------------------------------------\n";
            }

            InformacoesRelatorio += String.Format("\n\nTOTAL = {0:00000}\n\n\n", details.Total);
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
            int[] pgs = new int[opf.FileNames.Length];
            List<int> lsPgs = new List<int>(opf.FileNames.Length);

            if (config[0] == '2')
                pgs = Vnsdll.Pdf.ExtrairNumPgsArquivoPdf(opf.FileNames);
            else
            {
                string aux = config[2].ToString();
                int aux2 = int.Parse(aux)-1;
                lsPgs = ArqTexto.QntdArquivoTxt(opf.FileNames, aux2);
                for (int i = 0; i < lsPgs.Count; i++)
                {
                    pgs[i] = lsPgs[i];
                }
            }

            FileInfo[] nome = new FileInfo[opf.FileNames.Length];

            for(int i = 0; i < opf.FileNames.Length; i++)
                nome[i] = (new FileInfo(opf.FileNames[i]));
            

            for (int i = 0; i < opf.FileNames.Length; i++)
            {

                incrementarValorQntdArquivos();

                lsArq.Add(new Arquivo
                {
                    Id = qntArquivos,
                    Nome = nome[i].Name,
                    Pgs = pgs[i],
                });
            }
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

            int i = 0;
            
            //Percorre lista de Arquivos
            foreach (Arquivo cliente in lsArq)
            {
                ////Adiciona um item em branco no listView
                ListViewItem item = lstViewerArquivos.Items.Add("");

                foreach(PropertyInfo p in info)
                {

                    if((p.Name !="Total"))
                    {
                        item.SubItems.Add(p.GetValue(cliente, null).ToString());
                    }
                    else
                    if(p.Name == "Total" && i == 0)
                    {
                        item.SubItems.Add(p.GetValue(cliente, null).ToString());
                        i++;
                    }
                    else
                    {
                        item.SubItems.Add("");
                    }
                }
            }

            return;
        }

        /// <summary>
        /// Método para criar as colunas do listViewer com base nos campos da classe Arquivo
        /// </summary>
        private void criarColunasListView(ListView ls, string classeTipo)
        {

            //definindo a view do lisviewer com details, para mostrar o header
            ls.View = View.Details;

            //criando um array de propriedade da classe Arquivo
            Type t = Type.GetType(classeTipo);

            var info = t.GetProperties();
            ColumnHeader col1 = new ColumnHeader();
            col1.Text = "";
            col1.Width = 1;

            if(!(controle[1]))
            {
                col1.Text = "";
                controle[1] = true;
                ls.Columns.Add(col1);
            }

            foreach(var item in info)
            {
                //criando nova coluna
                ColumnHeader col = new ColumnHeader();

                col.Text = item.Name;

                if(col.Text.Equals("Id") || col.Text.Equals("Pgs"))
                {
                    col.TextAlign = HorizontalAlignment.Center;
                    col.Width = 35;
                }
                else if(col.Text.Equals("Nome"))
                {
                    col.Width = 600;
                    col.TextAlign = HorizontalAlignment.Left;
                }
                else if((col.Text.Equals("Total"))|| (col.Text.Equals("Count")))
                {
                    col.Width = 60;
                    col.TextAlign = HorizontalAlignment.Center;
                }
                else if(col.Text.Equals("Tipo"))
                {
                    col.Width = 80;
                    col.TextAlign = HorizontalAlignment.Left;
                }
                else if(col.Text.Equals("Logica"))
                {
                    col.Width = 150;
                    col.TextAlign = HorizontalAlignment.Left;
                }
                
                //adicionando a coluna no listviewer
                ls.Columns.Add(col);
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

        private void MenuConfig_Click(object sender, EventArgs e)
        {
            FrOpcoes frOpcoes = new FrOpcoes();
            frOpcoes.ShowDialog();
        }

        private void menuAbrirArq_Click(object sender, EventArgs e)
        {
            try
            {
                if (Configuracao.verificarArqConfig())
                {
                    definirConfigForm();

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
                                addDetalhes(lsArq, config);
                                lstViewerArquivos.Items.Clear();
                                setarListViewcomArquivos();
                            }
                            else
                            {
                                addItensList();
                                lstViewerArquivos.Items.Clear();
                                addDetalhes(lsArq, config);
                                setarListViewcomArquivos();
                                controle[4] = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void addDetalhes(List<Arquivo> lsArq, string config)
        {
            string auxTipo = "", auxLogica = "", auxGeracao = "";

            //usando uma variavel aux para pegar os dados que foram configurados pelo o usuario
            if(config[0] == '1')
            { 
                auxTipo = Configuracao.txtTipo[(int)char.GetNumericValue(config[0])];
                auxGeracao = Configuracao.txtGeracaoConfigTexto[(int)char.GetNumericValue(config[1])];
                auxLogica = Configuracao.txtLogicaArqTxt[(int)char.GetNumericValue(config[2])];
            }
            else
            {
                auxTipo = Configuracao.txtTipo[(int)char.GetNumericValue(config[0])];
                auxGeracao = Configuracao.txtGeracaoConfigPdf[(int)char.GetNumericValue(config[1])];
                auxLogica = Configuracao.txtLogicaArqPdf[(int)char.GetNumericValue(config[2])];
            }

            //instância um object que conterá os detalhes, onde ficara no lstViewerDetalhes
            details = new Detalhe()
            {
                Count = lsArq.Count,
                Tipo = auxTipo,
                Total = lsArq.Sum(x => x.Pgs),
                Logica = auxLogica,
                Geracao = auxGeracao
            };

            Debug.WriteLine("Count -- {0}\nTipo -- {1}\nTotal -- {2}\nLogica -- {3}\nGeração -- {4}",
                                details.Count,
                                details.Tipo,
                                details.Total,
                                details.Logica,
                                details.Geracao
                            );
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
