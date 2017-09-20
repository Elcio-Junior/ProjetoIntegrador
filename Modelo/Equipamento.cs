using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    [Table("Equipamento")]
    public class Equipamento : IModel<int>
    {
        [Key]
        [DisplayAttribute(Name = "Cod Equipamento")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }

        [DisplayAttribute(Name = "Modelo Equipamento")]
        [StringLength(50)]
        public string Modelo { get; set; }

        [DisplayAttribute(Name = "Marca Equipamento")]
        [StringLength(50)]
        public string Marca { get; set; }

        [DisplayAttribute(Name = "Série Equipamento")]
        [StringLength(50)]
        [Column("NumeroSerie")]
        public string Serie { get; set; }

        [DisplayAttribute(Name = "Ano Equipamento")]
        [DataType(DataType.DateTime)]
        [Column("Ano")]
        public DateTime Ano { get; set; }

        //[DisplayAttribute(Name = "Data de Cadastro")]
        //[DataType(DataType.DateTime)]
        //[Column("Ano")]
        //public DateTime DtCadastro { get; set; }
    }
}
