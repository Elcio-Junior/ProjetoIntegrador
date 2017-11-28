using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    [Table("TipoServico")]
    public class TipoServico : IModel<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("TipoServicoId")]
        public int Id { get; set; }

        [Required]
        [DisplayAttribute(Name = "Tipo")]
        public string Descricao { get; set; }
    }
}
