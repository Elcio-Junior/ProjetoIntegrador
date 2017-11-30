using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClienteWeb.Reports.OS
{
    public class OrdemItemModelReport
    {
        public int OrdemItemId { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
        
        public int ServicoId { get; set; }
        public string Descricao { get; set; }
        public decimal ValorUnitario { get; set; }
    }
}