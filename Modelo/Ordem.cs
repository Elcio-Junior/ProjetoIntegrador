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

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.DateTime)]
        [DisplayAttribute(Name = "Abertura OS")]
        public DateTime DtAberturaOs { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.DateTime)]
        [DisplayAttribute(Name = "Fechamento OS")]
        public DateTime DtFechamentoOS { get; set; }

        [DisplayAttribute(Name = "Status")]
        [StringLength(10)]
        public string Status { get; set; }

        [Required]

        [Column("IdCliente")]
        public virtual int ClienteId { get; set; }

        [DisplayAttribute(Name = "Nome Cliente")]
        [ForeignKey("ClienteId")]
        public Cliente cliente { get; set; }

    }
}
