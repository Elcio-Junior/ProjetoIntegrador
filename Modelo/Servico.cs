using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{   
    [Table("Servico")]
    public class Servico
    {
        public int ServicoId { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public string DtCriada { get; set; }
        public string DtAlterado { get; set; }
        public float Valor { get; set; }
    }
}
