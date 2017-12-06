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
        [Column("OrdemId")]
        public int Id { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.DateTime)]
        public DateTime Abertura { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.DateTime)]
        public DateTime? Fechamento { get; set; }

        [DisplayAttribute(Name = "Descrição")]
        [Required]
        public string Descricao { get; set; }

        [NotMapped]
        public virtual Decimal Total { get; set; }

        #region Relacionamentos

        // Relacionamento Tabela Cliente
        public virtual int ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; set; }

        // Relacionamento Tabela Equipamento
        public int EquipamentoId { get; set; }

        [ForeignKey("EquipamentoId")]
        public virtual Equipamento Equipamento { get; set; }

        public virtual ICollection<OrdemItem> Itens { get; set; }

        #endregion
    }
}
