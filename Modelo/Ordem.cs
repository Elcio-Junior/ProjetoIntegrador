using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo
{
    [Table("Ordem")]
    public class Ordem : IModel<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        [DisplayAttribute(Name = "Numero da OS")]
        [StringLength(50)]
        public string NumeroOS { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.DateTime)]
        [DisplayAttribute(Name = "Data Abertura OS")]
        public DateTime DtAberturaOs { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.DateTime)]
        [DisplayAttribute(Name = "Data Fechamento OS")]
        public DateTime DtFechamentoOS { get; set; }

        [DisplayAttribute(Name = "Status")]
        [StringLength(10)]
        public string Status { get; set; }

        [Required]
        [Column("IdCliente")]
        public virtual int ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public Cliente cliente { get; set; }

    }
}
