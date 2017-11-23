using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Modelo
{
    [Table("Equipamento")]
    public class Equipamento : IModel<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("EquipamentoId")]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Modelo { get; set; }

        [Required]
        public string Tipo { get; set; }

        [Required]
        public string Marca { get; set; }

        [Required]
        public int Ano { get; set; }

        [Required]
        [DisplayAttribute(Name = " Nª Série")]
        public string NumeroSerie { get; set; }

        #region Relacionamentos
        // Relacionamento Tabela Cliente
        public int ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; set; }
        
        #endregion
    }
}
