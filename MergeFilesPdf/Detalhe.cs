using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeFilesPdf
{
    public  class Detalhe
    {
        public string Tipo { get; set; }
        public string Geracao { get; set; }
        public string Logica { get; set; }
        public int Count { get; set; }
        public int Total { get; set; }

        /// <summary>
        /// Método que limpa todos os campos da classe Detalhe
        /// </summary>
        public void  ClearFields()
        {
            this.Tipo = string.Empty;
            this.Geracao = string.Empty;
            this.Logica = string.Empty;
            this.Count = 0;
            this.Total = 0;
            return;
        }
    }
}
