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
using System.Media;
using System.Threading;


namespace MergeFilesPdf
{
    public partial class FRPrincipal : Form
    {
        #region Objetos da Classe
        //object privado de controle
        private IndexadorInteiros controle;

        private List<FileInfo> infoArquivos;
        private DateTime time;
        //controle[0] == controle do button start
        //controle[1] == controle do método colunas ListViewer
        //controle[2] == controle do event click do button btnSelectFiles()
        //controle[3] == controle do método definir definirNomesdeExclusao()
        //controle[4] == controle  para chamar método verificarDuplicidadeEndArq()
        //controle[5] == controle  do form de Configurações

        private string config;
        MesclarPdf mPdf = null;
        string[] capas = null;

        //List que carregará os arquivos
        private List<Arquivo> lsArq, lsExclusao;
 
        private Detalhe details;

        private int qntArquivos;
        #endregion

        #region ------------ Construtor FRPrincipal --------------
        public FRPrincipal()
        {
            InitializeComponent();

        

            getInfoAssembly();//carregando informações do Assembly da aplicação
            Configuracao.DeletarArqConfig();//limpando arquivo de configuração
            infoArquivos = new List<FileInfo>();
            controle = new IndexadorInteiros(0);//instânciando os controles

            //Criando os ListViewes que serão utilizados, com base nos arquivos Arquivo e Detalhes
            criarColunasListView(lstViewerArquivos, "MergeFilesPdf.Arquivo");
            criarColunasListView(lstViewerDetalhes, "MergeFilesPdf.Detalhe");
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
        /// Método para criar as colunas do listViewer com base nos campos da classe Arquivo ou Detalhes
        /// </summary>
        /// <param name="ls"></param>
        /// <param name="classeTipo"></param>
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
                else if(col.Text.Equals("Name"))
                {
                    col.Width = 800;
                    col.TextAlign = HorizontalAlignment.Left;
                }
                else if((col.Text.Equals("Total")))
                {
                    col.Width = 90;
                    col.TextAlign = HorizontalAlignment.Center;
                }
                else if(col.Text.Equals("Tipo"))
                {
                    col.Width = 150;
                    col.TextAlign = HorizontalAlignment.Left;
                }
                else if(col.Text.Equals("Logica") || (col.Text.Equals("Geracao")))
                {
                    col.Width = 270;
                    col.TextAlign = HorizontalAlignment.Left;

                }
                else if(col.Text.Equals("Count"))
                {
                    col.Width = 60;
                    col.TextAlign = HorizontalAlignment.Center;
                }

                //adicionando a coluna no listviewer
                ls.Columns.Add(col);
            }

            return;
        }
        #endregion

        #region Definição Open File Dialog
        /// <summary>
        /// Método para definir o filtro do objeto OpenFileDialog, entre arquivos .Pdf ou .tx
        /// </summary>
        private void definirFiltroOpf()
        {
           
            if (config[0] == '1')
                opf.Filter = "Arquivos de Texto|*.txt";
            else
                opf.Filter = "Arquivos Pdf|*.pdf";
        }

        #endregion

        #region ------------------- Métodos de Eventos --------------------


        /// <summary>
        /// Evento keydown da ListViewer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lsArquivos_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {
                if(MessageBox.Show("Deseja excluir a seleção ?", "Atencão!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    definirNomesdeExclusao();
                    removerItensdaList();
                    
                    //atualizando dados Detalhe
                    addItensDetalhes(config);

                    //limpando os 2 ListViewers
                    lstViewerArquivos.Items.Clear();
                    lstViewerDetalhes.Items.Clear();

                    //setando os arquivos novamente
                    setarListViewComArquivos(1,lsArq,null);
                    setarListViewComArquivos(2, null, details);
                    
                    //atualizando listviewer
                    lstViewerArquivos.Refresh();
                    lstViewerDetalhes.Refresh();
                }
            }
        }

        #region Inicio do Processamento
        /// <summary>
        /// Evento click do button start
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStart_Click(object sender, EventArgs e)
        {

            try
            {
                ProgressBar.Value = 0;
                string nomeArqRelatorioArquivos = string.Empty;

                if(!(controle[0]))
                {
                    if(verificaQntdListView())
                    {
                        #region Escolhas de Processamento

                        switch(config[0])
                        {
                            #region case1
                            //************** Entrada para Funções de txt *******************
                            case '1':

                                switch(config[1])
                                {
                                    //Opção - Apenas Capas .txt
                                    case '1':
                                        for(int i = 0; i < lsArq.Count; i++)
                                            CapasPdf.CriaCapasdeLoteArqTxt(lsArq[i].Name, lsArq[i].Pgs);
                                        break;

                                    //Opção - Capas e Relatorios dos Arquivos .txt
                                    case '2':
                                        ////instânciando classe MesclarPdf
                                        mPdf = new MesclarPdf();
                                        nomeArqRelatorioArquivos = $"Relatorio_Total_{details.Total}";

                                        //Gerar Capas e relatório qntd
                                        for(int i = 0; i < lsArq.Count; i++)
                                            CapasPdf.CriaCapasdeLoteArqTxt(lsArq[i].Name, lsArq[i].Pgs);

                                        CapasPdf.CriarPdfApenasTexto(nomeArqRelatorioArquivos, addInformacoesRelatorioArquivosTxt(lsArq));

                                        //chamando método de mescla
                                        mPdf.addArquivo(CapasPdf.getNomeCapas());
                                        mPdf.MesclarArquivos($"Mescla_Arquivos_{details.Total}");

                                        break;

                                    case '3':
                                        nomeArqRelatorioArquivos = $"Relatorio_Total_{details.Total}";
                                        CapasPdf.CriarPdfApenasTexto(nomeArqRelatorioArquivos, addInformacoesRelatorioArquivosTxt(lsArq));

                                        // ************************* Fim *****************************
                                        break;
                                }
                                break;
                            #endregion
                            #region case2
                            //***************************** Entrada para Funções de pdf ******************************
                            case '2':

                                //switch na lógica 
                                switch(config[2])
                                {
                                    #region simplex
                                    //entrada de folhas simplex
                                    case '1':
                                        switch(config[1])
                                        {
                                            //Opção - Apenas Capas .pdf  
                                            case '1':
                                                for(int i = 0; i < lsArq.Count; i++)
                                                    CapasPdf.CriaCapasdeLoteArqPdf(lsArq[i].Name, lsArq[i].Pgs, "simplex");
                                                break;

                                            //Opção - Apenas Mesclar Arquivos .pdf
                                            case '2':

                                                //instânciando classe MesclarPdf
                                                mPdf = new MesclarPdf();

                                                //adicionando os arquivos para mescla
                                                for(int i = 0; i < lsArq.Count; i++)
                                                    mPdf.addArquivo(lsArq[i].Name);

                                                //Mesclando..
                                                mPdf.MesclarArquivos($"Mescla_{details.Total}");

                                                break;

                                            //Opção - Capas e Mesclar
                                            case '3':
                                                //instânciando classe MesclarPdf
                                                mPdf = new MesclarPdf();

                                                for(int i = 0; i < lsArq.Count; i++)
                                                    CapasPdf.CriaCapasdeLoteArqPdf(lsArq[i].Name, lsArq[i].Pgs, "simplex");

                                                capas = CapasPdf.getNomeCapas();

                                                for(int i = 0; i < lsArq.Count; i++)
                                                {
                                                    mPdf.addArquivo(lsArq[i].Name);
                                                    mPdf.addArquivo(capas[i]);
                                                }

                                                //Mesclando...
                                                mPdf.MesclarArquivos($"Mescla_{details.Total}");

                                                break;

                                            //Opção - Capas, Mesclar e Relatório de Intervalo de pgs
                                            case '4':

                                                nomeArqRelatorioArquivos = $"Relatorio_Intervalo_Pgs_{details.Total}";

                                                //instânciando classe MesclarPdf
                                                mPdf = new MesclarPdf();


                                                for(int i = 0; i < lsArq.Count; i++)
                                                    CapasPdf.CriaCapasdeLoteArqPdf(lsArq[i].Name, lsArq[i].Pgs, "simplex");

                                                capas = CapasPdf.getNomeCapas();

                                                for(int i = 0; i < lsArq.Count; i++)
                                                {
                                                    mPdf.addArquivo(lsArq[i].Name);
                                                    mPdf.addArquivo(capas[i]);
                                                }

                                                //Mesclando...
                                                mPdf.MesclarArquivos($"Mescla_{details.Total}");

                                                CapasPdf.CriarPdfApenasTexto(nomeArqRelatorioArquivos, addInformacoesRelatorioIntervaloPgs(0));

                                                break;

                                            //Opção - Capas, Mesclar e Relatório com qntd dos Arquivos
                                            case '5':

                                                nomeArqRelatorioArquivos = $"Relatorio_Total_{details.Total}";

                                                //instânciando classe MesclarPdf
                                                mPdf = new MesclarPdf();


                                                for(int i = 0; i < lsArq.Count; i++)
                                                    CapasPdf.CriaCapasdeLoteArqPdf(lsArq[i].Name, lsArq[i].Pgs, "simplex");

                                                capas = CapasPdf.getNomeCapas();

                                                for(int i = 0; i < lsArq.Count; i++)
                                                {
                                                    mPdf.addArquivo(lsArq[i].Name);
                                                    mPdf.addArquivo(capas[i]);
                                                }

                                                //Mesclando...
                                                mPdf.MesclarArquivos($"Mescla_{details.Total}");

                                                CapasPdf.CriarPdfApenasTexto(nomeArqRelatorioArquivos, addInformacoesRelatorioArquivosTxt(lsArq));
                                                break;

                                            //Opção - Capas, Mesclar e Todos os Relatórios
                                            case '6':

                                                nomeArqRelatorioArquivos = $"Relatorio_Intervalo_Pgs_{details.Total}";

                                                //instânciando classe MesclarPdf
                                                mPdf = new MesclarPdf();


                                                for(int i = 0; i < lsArq.Count; i++)
                                                    CapasPdf.CriaCapasdeLoteArqPdf(lsArq[i].Name, lsArq[i].Pgs, "simplex");

                                                capas = CapasPdf.getNomeCapas();

                                                for(int i = 0; i < lsArq.Count; i++)
                                                {
                                                    mPdf.addArquivo(lsArq[i].Name);
                                                    mPdf.addArquivo(capas[i]);
                                                }

                                                //Mesclando...
                                                mPdf.MesclarArquivos($"Mescla_{details.Total}");

                                                CapasPdf.CriarPdfApenasTexto(nomeArqRelatorioArquivos, addInformacoesRelatorioIntervaloPgs(0));
                                                CapasPdf.CriarPdfApenasTexto($"Relatorio_Qntd_Arquivos_Total_{details.Total}", addInformacoesRelatorioArquivosTxt(lsArq));
                                                break;

                                            //Opção - Mesclar e Relatório de Intervalo de pgs
                                            case '7':

                                                //instânciando classe MesclarPdf
                                                mPdf = new MesclarPdf();

                                                //adicionando os arquivos para mescla
                                                for(int i = 0; i < lsArq.Count; i++)
                                                    mPdf.addArquivo(lsArq[i].Name);

                                                //Mesclando..
                                                mPdf.MesclarArquivos($"Mescla_{details.Total}");
                                                CapasPdf.CriarPdfApenasTexto($"Relatorio_Intervalo_Pgs_Total_{details.Total}", addInformacoesRelatorioIntervaloPgs(0));

                                                break;

                                            //Opção - Mesclar e Relatório com Qntd dos Arquivos
                                            case '8':
                                                //instânciando classe MesclarPdf
                                                mPdf = new MesclarPdf();

                                                //adicionando os arquivos para mescla
                                                for(int i = 0; i < lsArq.Count; i++)
                                                    mPdf.addArquivo(lsArq[i].Name);

                                                //Mesclando..
                                                mPdf.MesclarArquivos($"Mescla_{details.Total}");
                                                CapasPdf.CriarPdfApenasTexto($"Relatorio_Qntd_Arquivos_Total_{details.Total}", addInformacoesRelatorioArquivosTxt(lsArq));
                                                break;

                                            case '9':
                                                //instânciando classe MesclarPdf
                                                mPdf = new MesclarPdf();

                                                //adicionando os arquivos para mescla
                                                for(int i = 0; i < lsArq.Count; i++)
                                                    mPdf.addArquivo(lsArq[i].Name);

                                                //Mesclando..
                                                mPdf.MesclarArquivos($"Mescla_{details.Total}");
                                                CapasPdf.CriarPdfApenasTexto($"Relatorio_Intervalo_Pgs_Total_{details.Total}", addInformacoesRelatorioIntervaloPgs(2));
                                                CapasPdf.CriarPdfApenasTexto($"Relatorio_Qntd_Arquivos_Total_{details.Total}", addInformacoesRelatorioArquivosTxt(lsArq));
                                                break;
                                        }

                                        break;
                                    #endregion
                                    #region duplex

                                    case '2':
                                        switch(config[1])
                                        {
                                            case '1':
                                                //criando capas de lote
                                                for (int i = 0; i < lsArq.Count; i++)
                                                    CapasPdf.CriaCapasdeLoteArqPdf(lsArq[i].Name, lsArq[i].Pgs, "simplex");
                                                break;
                                            case '2':
                                                break;
                                            case '3':
                                                break;
                                            case '4':
                                                break;
                                            case '5':
                                                break;
                                            case '6':

                                                nomeArqRelatorioArquivos = $"Relatorio_Intervalo_Pgs_{details.Total}";

                                                //instânciando classe MesclarPdf
                                                mPdf = new MesclarPdf();

                                                //criando capas de lote
                                                for(int i = 0; i < lsArq.Count; i++)
                                                    CapasPdf.CriaCapasdeLoteArqPdf(lsArq[i].Name, lsArq[i].Pgs, "duplex");

                                                capas = CapasPdf.getNomeCapas();

                                                for(int i = 0; i < lsArq.Count; i++)
                                                {
                                                    mPdf.addArquivo(lsArq[i].Name);
                                                    mPdf.addArquivo(capas[i]);
                                                }

                                                //Mesclando...
                                                mPdf.MesclarArquivos($"Mescla_{details.Total}");

                                                CapasPdf.CriarPdfApenasTexto(nomeArqRelatorioArquivos, addInformacoesRelatorioIntervaloPgs(1));
                                                CapasPdf.CriarPdfApenasTexto($"Relatorio_Qntd_Arquivos_Total_{details.Total}", addInformacoesRelatorioArquivosTxt(lsArq));

                                                break;
                                            case '7':
                                                break;
                                            case '8':
                                                break;
                                            case '9':
                                                break;
                                        }
                                        break;
                                }
                                break;
                            #endregion
                            #endregion
                            #region case3
                            case '3':

                                string[] camposConfig = config.Split(';');
                                
                                //Split
                                for (int i = 0; i < lsArq.Count; i++)
                                    Vnsdll.SplitPdf.QuebrarArquivos(lsArq[i].Name, lsArq[i].Pgs, int.Parse(camposConfig[2]),
                                        int.Parse(camposConfig[3]), int.Parse(camposConfig[4]), int.Parse(camposConfig[5]));

                                //Gerar Relatorio csv
                                if(camposConfig[1] == "1")
                                {
                                    Vnsdll.RelatorioCSV relatorio = new RelatorioCSV($"{Vnsdll.SplitPdf.Directory}\\Relatorio_{details.Total}.txt");
                                    relatorio.addDados($"ID;NOME;QNT");

                                    for (int i = 0; i < lsArq.Count; i++)
                                        relatorio.addDados($"{lsArq[i].Id};{lsArq[i].Name};{lsArq[i].Pgs}");

                                    relatorio.criaArquivo();
                                }                               
                                break;
                                #endregion
                        }
                        #endregion                     

                        toolStart.Image = Properties.Resources._1480398520_PauseNormalRed;
                        controle[0] = true;

                        //chamando método para carregar a classe com as informações dos arquivos
                        setarInfoFile();

                        //instânciando a variável time para inserir a data no arquivo gerado
                        time = new DateTime();
                        time = DateTime.Now;

                        ProgressBar.Value = 100;
                        ProgressBar.ToolTipText = "Concluído";

                        toolStart.Image = Properties.Resources._1480398503_start;
                        MessageBox.Show("Todos os arquivos foram mesclados", "Operação realizada com sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        toolStart.Image = Properties.Resources._1480398520_PauseNormalRed;
                    }

                }
                else
                {
                    toolStart.Image = Properties.Resources._1480398503_start;
                    controle[0] = false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        #endregion

        #region Configurações
        /// <summary>
        /// Método para iniciar o form de Opções de Configurações
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuConfig_Click(object sender, EventArgs e)
        { 

            //instânciando form e iniciando
            if(controle[5] == false || (!File.Exists(Configuracao.txtConfig)))
            {
                new FrOpcoes().ShowDialog();          
                controle[5] = true;
            }
            else
            {
                if(Configuracao.MsgmAlertConfig(config = Configuracao.LerArqConfig()))
                {

                    if(lstViewerArquivos.Items.Count > 0)
                    {
                        int temp = lsArq.Count;

                        //limpando
                        clear();

                        //enviando msgm de sucesso no processo
                        MessageBox.Show($"{temp} - arquivos excluídos", "Processo efetuado com sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    //instânciando objct e exibindo form de opções
                    new FrOpcoes().ShowDialog();
                }
            }
        }

        /// <summary>
        /// Método paralimpar os objetos dados que são utilizados nos ListViewers
        /// </summary>
        private void clear()
        {
            //limpando os objetos com os dados
            if(lsArq != null || details != null)
            {
                details.ClearFields();
                lsArq.Clear();
            }
            
            //limpando campo de qntdArquivos
            qntArquivos = 0;

            //Limpar capas utilizadas
            CapasPdf.limparListDeCapas();

            //Limpar List de arquivos que foram adicionados para o merge
            if(mPdf != null)
                mPdf.LimparListaArquivos();
            

            //limpeza e atualização dos listviewers 
            lstViewerArquivos.Items.Clear();
            lstViewerDetalhes.Items.Clear();
            lstViewerDetalhes.Refresh();
            lstViewerArquivos.Refresh();
        }


        #endregion

        #region OpenFileDialog -- para selecionar os arquivos
        /// <summary>
        /// Método onde será selecionado os arquivos para setar os mesmo nos ListViewes e posterior processamento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuAbrirArq_Click(object sender, EventArgs e)
        {
            try
            {
                if(Configuracao.VerificarArqConfig()) //só executa caso o usuario tenha configurado o processo no form Opcoes
                {
                    config = Configuracao.LerArqConfig(); //capturando dados do arquivo de configuração config.txt

                    //definindo o filtro do OpfFileDialog, conforme a seleção das opções no form Opcoes
                    definirFiltroOpf();

                    if(opf.ShowDialog() == DialogResult.OK)
                    {
                        if(opf.FileNames.Length > 0)
                        {
                            FileInfo fi = new FileInfo(opf.FileName);
                            CapasPdf.Directory = fi.Directory.ToString();
                            Vnsdll.MesclarPdf.Directory = fi.Directory.ToString();
                            Vnsdll.SplitPdf.Directory = fi.Directory.ToString();

                           
                            //só executará uma vez
                            if(controle[2] == false)
                            {
                                lsArq = new List<Arquivo>(); //instânciando o List que conterá os arquivos selecionados
                                controle[2] = true;
                            }

                            //segunda passagem 
                            if(controle[4] == true && verificarDuplicidadeEndArq() == false)
                            {
                                //adicionando os arquivos do opf.Filenames, nos list
                                addItensNoListArq();
                                addItensDetalhes(config);

                                //limpando itens dos Listviewes
                                lstViewerArquivos.Items.Clear();
                                lstViewerDetalhes.Items.Clear();

                                //Sentando os Valores dos List nos ListViewes
                                setarListViewComArquivos(1, lsArq);
                                setarListViewComArquivos(2, null, details);
                            }
                            else //primeira passagem
                            {
                                //adicionando os arquivos do opf.Filenames, nos list
                                addItensNoListArq();
                                addItensDetalhes(config);

                                //limpando itens dos ListViewes
                                lstViewerArquivos.Items.Clear();
                                lstViewerDetalhes.Items.Clear();

                                //Sentando os Valores dos List nos ListViewes
                                setarListViewComArquivos(1, lsArq);
                                setarListViewComArquivos(2, null, details);

                                controle[4] = true;
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #endregion

        #region ------------------- Métodos de UI -------------------------
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
                nomeArq = lsArq[i].Name.Split('\\');
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
                nomeArq=ls[i].Name.Split('\\');
                InformacoesRelatorio += String.Format("Id: {0:00000}\n", ls[i].Id);
                InformacoesRelatorio += String.Format("Nome Arquivo: {0}\n", nomeArq[nomeArq.Length-1]);
                InformacoesRelatorio += String.Format("Qntd: {0}\n", ls[i].Pgs);
                InformacoesRelatorio += "-----------------------------------------------------------------------------\n";
            }

            InformacoesRelatorio += String.Format("\n\nTOTAL = {0:00000}\n\n\n", details.Total);
            return InformacoesRelatorio;
        }

        /// <summary>
        /// Método para gerar informações sobre intervalo de Pgs
        /// </summary>
        /// <param name="capas"> capas == 0 -> simplex; capas == 1 -> duplex; capas == 2 -> sem capas</param>
        /// <returns></returns>
        private string addInformacoesRelatorioIntervaloPgs(int capas)
        {
            string infoRelatorioPgs = "";
            int contPgs = 1;

            //cabeçalho do Relátorio de Intervalo de Pgs
            infoRelatorioPgs += String.Format("-------------------------------Intervalo de Pgs - Lotes----------------------\n");

            //adicionando as informações de intervalo de pgs
            for (int i = 0; i < lsArq.Count; i++)
            {

                if(capas == 0) //gerar informãções com base em capas simplex
                {
                    infoRelatorioPgs += $"                              Id:{lsArq[i].Id:00000} -- {contPgs} até {contPgs += lsArq[i].Pgs}\n";
                    contPgs++;
                }
                else if(capas == 1) //gerar informações com base em capas duplex
                {
                    infoRelatorioPgs += $"                              Id:{lsArq[i].Id:00000} -- {contPgs} até {contPgs += lsArq[i].Pgs*2 + 1 }\n";
                    contPgs++;
                }
                else //gerar informações desconsiderando a existência de capas
                {
                    if(i == 0)
                    {
                        infoRelatorioPgs += $"                              Id:{lsArq[i].Id:00000} -- {contPgs} até {lsArq[i].Pgs*2}\n";
                    }
                    else
                    {
                        contPgs += lsArq[i].Pgs*2;
                        infoRelatorioPgs += $"                              Id:{lsArq[i].Id:00000} -- {contPgs} até {lsArq[i].Pgs*2 + contPgs}\n";
                    }
                }
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
               
                infoArquivos.Add(new FileInfo(lsArq[i].Name));
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
                    if (lsArq[i].Name.Equals(opf.FileNames[j]))
                        throw new Exception(String.Format("Arquivo já existente : {0} ", opf.FileNames[j]));
                }
            }

            return true;
        }

        /// <summary>
        /// Método para Adicionar itens no List
        /// </summary>
        private void addItensNoListArq()
        {
            int[] pgs = new int[opf.FileNames.Length];
            List<int> lsPgs = new List<int>(opf.FileNames.Length);

            if ((config[0] == '2') && (config[2] == '1'))//entra aqui, caso a opção de processo escolhida for arquivos .pdf
                pgs = Vnsdll.Pdf.ExtrairNumPgsArquivoPdf(opf.FileNames);
            else
            if ((config[0] == '2') && (config[2] == '2') || (config[0] == '3'))
            {
                pgs = Vnsdll.Pdf.ExtrairNumPgsArquivoPdf(opf.FileNames);
                for (int i = 0; i < pgs.Length; i++)
                {
                    pgs[i] = pgs[i] / 2;
                }
            }
            else //senão entrará aqui... Correspondente ao Arquivo .Txt
            {
                //variaveis para saber a lógica que será adotada
                string aux = config[2].ToString();
                int aux2 = int.Parse(aux) - 1;

                //capturando a qntd de registros para cada arquivo .txt selecionado
                lsPgs = ArqTexto.QntdArquivoTxt(opf.FileNames, aux2);
                for (int i = 0; i < lsPgs.Count; i++)
                {
                    pgs[i] = lsPgs[i];
                }
            }

            //Objeto[] que pegará o nome de cada arquivo, e será usado para setar apenas o nome do arquivo no List, e não FullName
            FileInfo[] nome = new FileInfo[opf.FileNames.Length];

            //criando o array com o arquivos
            for(int i = 0; i < opf.FileNames.Length; i++)
                nome[i] = (new FileInfo(opf.FileNames[i]));
            
            //Instânciando os arquivos no ListArq
            for (int i = 0; i < opf.FileNames.Length; i++)
            {
                incrementarValorQntdArquivos();

                lsArq.Add(new Arquivo
                {
                    Id = qntArquivos,
                    Name = nome[i].Name,
                    Pgs = pgs[i],
                });
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
        private void criarListExclusao()
        {
            lsExclusao = new List<Arquivo>();
            return;
        }

        /// <summary>
        /// Método para setar valores dos arquivos nos Listview - Arquivos e Detalhes (um de cada vez) do projeto
        /// </summary>
        /// <param name="tipoList"></param>
        /// <param name="lstArq"></param>
        /// <param name="lstDetalhe"></param>
        private void setarListViewComArquivos(int tipoList,List<Arquivo> lstArq = null, Detalhe lstDetalhe = null)
        {
            PropertyInfo[] infoList;

            // Caso 1 - será executa o de Arquivo. Senão executa o de Detalhe

            if(tipoList == 1)
            {
                infoList = typeof(Arquivo).GetProperties();   //criando um array de propriedade da classe Arquivo
                int i = 0;

                //Percorre lista de Arquivos
                foreach(Arquivo itens in lsArq)
                {
                    ////Adiciona um item em branco no listView
                    ListViewItem item = lstViewerArquivos.Items.Add("");

                    foreach(PropertyInfo p in infoList)
                    {

                        if((p.Name != "Total"))
                        {
                            item.SubItems.Add(p.GetValue(itens, null).ToString());
                        }
                        else // ----------- classe - Detalhe
                        if(p.Name == "Total" && i == 0)
                        {
                            item.SubItems.Add(p.GetValue(itens, null).ToString());
                            i++;
                        }
                        else
                        {
                            item.SubItems.Add("");
                        }
                    }
                }
            }
            else
            {
                infoList = typeof(Detalhe).GetProperties();
                
                    ////Adiciona um item em branco no listView
                    ListViewItem item = lstViewerDetalhes.Items.Add(lstDetalhe.Tipo);

                foreach(PropertyInfo p in infoList)
                {
                    if(p.Name == "Geracao")
                        item.SubItems.Add(lstDetalhe.Geracao);
                    else if(p.Name == "Logica")
                        item.SubItems.Add(lstDetalhe.Logica);
                    else if(p.Name == "Count")
                        item.SubItems.Add(lstDetalhe.Count.ToString());
                    else if(p.Name == "Total")
                        item.SubItems.Add(lstDetalhe.Total.ToString());
                }
            }

            return;
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
                    Name = arquivosdeExclusao[2],
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
        /// 
        /// </summary>
        /// <param name="lsArq"></param>
        /// <param name="config"></param>
        private void addItensDetalhes(string config)
        {
            //variaveis de auxilio
            string auxTipo = "", auxLogica = "", auxGeracao = "";

            //config[0] == 1 -- .txt
            //config[0] == 2 -- .pdf
            //config[0] == 3 -- split
            if (config[0] == '1')
            {
                auxTipo = Configuracao.txtTipo[(int)char.GetNumericValue(config[0])];
                auxGeracao = Configuracao.txtGeracaoConfigTexto[(int)char.GetNumericValue(config[1])];
                auxLogica = Configuracao.txtLogicaArqTxt[(int)char.GetNumericValue(config[2])];
            }
            else
            if (config[0] == '2')
            {
                auxTipo = Configuracao.txtTipo[(int)char.GetNumericValue(config[0])];
                auxGeracao = Configuracao.txtGeracaoConfigPdf[(int)char.GetNumericValue(config[1])];
                auxLogica = Configuracao.txtLogicaArqPdf[(int)char.GetNumericValue(config[2])];
            }
            else
            if (config[0] == '3')
            {
                auxTipo = Configuracao.txtTipo[3];
                auxGeracao = "Duplex";
                auxLogica = "Arquivo PDF - Modo Split";
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
            return;
        }


        /// <summary>
        /// Método para verificar se tem algum item no listviewer
        /// </summary>
        /// <returns></returns>
        private bool verificaQntdListView()
        {
            if (config[0] == '3' || lstViewerArquivos.Items.Count > 1)
                return true;
            else
                throw new Exception("Lista não contém itens necessários para mescla!");
        }
    }
    #endregion
}

