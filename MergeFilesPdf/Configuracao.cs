using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MergeFilesPdf
{
    public static class Configuracao
    {
        public static string txtConfig = string.Format("{0}\\config.txt", Directory.GetCurrentDirectory());



        public static bool verificarArqConfig()
        {
            FileInfo fi = new FileInfo(Configuracao.txtConfig);

            if(fi.Length > 0)
                return true;
            else
                throw new Exception("Configurações não definidas.");
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

        public static string[] txtLogicaArqPdf = new string[] {
            "Selecione uma opção:",
            "Simplex",
            "Duplex"
        };

    }
}
