using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace MergeFilesPdf
{
    public static class Configuracao
    {
        //string que contem o endereço do arquivo de configuração
        public static string txtConfig = $"{Directory.GetCurrentDirectory()}\\config.txt";

        /// <summary>
        /// Método para limpar o arquivo de configuração
        /// </summary>
        public static void DeletarArqConfig()
        {
            
            //limpando arquivo de configuração
            try
            {
                //using(StreamWriter stw = new StreamWriter(txtConfig, false, Encoding.Default)) { }
                File.Delete(txtConfig);
                Debug.WriteLine($"caminho das configurações {txtConfig}");
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para criar Arquivo de configuração
        /// </summary>
        public static void CriarArquivoConfig(int[] resultados)
        {
            try
            {
                using(StreamWriter stw = new StreamWriter(txtConfig, false, Encoding.Default))
                {
                    for(int i = 0; i < resultados.Length; i++)
                    {
                        stw.Write(resultados[i]);
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para ler Arquivo de configuaração
        /// </summary>
        /// <returns></returns>
        public static  string LerArqConfig()
        {
            string linha = "", aux = "";
            using(StreamReader str = new StreamReader(Configuracao.txtConfig))
                while((aux = str.ReadLine()) != null)
                    linha = aux;
            return linha;
        }


        /// <summary>
        /// Método para verificar verificar se o arquivo de configuração existe e está preenchido
        /// /// </summary>
        /// <returns></returns>
        public static bool VerificarArqConfig()
        {
            FileInfo fi = new FileInfo(Configuracao.txtConfig);

            if(fi.Exists)
            {
                if(fi.Length > 0)
                    return true;
                else
                    throw new Exception("Configurações não definidas.");
            }
            else
                throw new Exception("Arquivo de configuração \"config.txt\" não foi encontrado.\nVá em configurações e defina as opções para continuar.");
        }

        /// <summary>
        ///Método que irá mostrar as configurações anteriores e avisar que se haver algum arquivo selecionado serão apagados do List, return true caso o usuário aceite 
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public static  bool MsgmAlertConfig(string config)
        {
            //config[0]== "1" --- arquivo .txt
            //config[0]== "2" --- arquivo .pdf
            if(config[0] == '1')
            {
                if(
                    MessageBox.Show($"Configurações Anteriores:" +
                    $"\n-----------------------------------------------------------" +
                    $"\nLógica:\n{Configuracao.txtLogicaArqTxt[(int)char.GetNumericValue(config[2])]}" +
                    $"\n-----------------------------------------------------------" +
                    $"\nArquivos:\n{Configuracao.txtTipo[1]}" +
                    $"\n-----------------------------------------------------------" +
                    $"\nGeração:\n{Configuracao.txtGeracaoConfigTexto[(int)char.GetNumericValue(config[1])]}" +
                    $"\n-----------------------------------------------------------" +
                    "\n\n\nOs arquivos selecionados serão apagados - **caso existam**." +
                    "\nDeseja continuar?", "Atenção!",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                { return true; }

            }
            else
            if(config[0] == '2')
            {
                if(
                    MessageBox.Show($"Configurações Anteriores:" +
                    $"\n-----------------------------------------------------------" +
                    $"\nLógica:\n{Configuracao.txtLogicaArqPdf[(int)char.GetNumericValue(config[2])]}" +
                    $"\n-----------------------------------------------------------" +
                    $"\nArquivos:\n{Configuracao.txtTipo[2]}" +
                    $"\n-----------------------------------------------------------" +
                    $"\nGeração:\n{Configuracao.txtGeracaoConfigPdf[(int)char.GetNumericValue(config[1])]}" +
                    $"\n-----------------------------------------------------------" +
                    "\n\n\nOs arquivos selecioandos serão apagados - **caso existam**" +
                    "\nDeseja continuar?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                { return true; }
            }

            //if não retorne true em nenhum dos 2 if, significa que a respostas foi não, assim retornando false
            return false;
        }



        public  static string[] txtTipo = new string[] {
            "Selecione uma opção:",
            "1 - Arquivo de Texto (.txt)",
            "2 - Arquivo de Documento (.pdf)"
        };

        public static string[] txtGeracaoConfigTexto = new string[] {
            "Selecione uma opção:",
            "1 - Apenas Capas",
            "2 - Capas e Relatório com qntd dos Arquivos ",
            "3 - Apenas Relatório com Qntd dos Arquivos"
        };


        public static string[] txtLogicaArqTxt = new string[] {
            "Selecione uma opção:",
            "1 Registro - 1 linha",
            "1 Registro - 2 linhas",
            "1 Regsitro - 3 linhas",
            "1 Registro - 4 linhas",
            "1 Registro - 5 linhas",
            "Desconsiderar 1 linha",
            "Prefeitura de Brusque - contas de água"
        };

        public static string[] txtGeracaoConfigPdf = new string[] {
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



        public static string[] txtLogicaArqPdf = new string[] {
            "Selecione uma opção:",
            "Simplex",
            "Duplex"
        };

    }
}
