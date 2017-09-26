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
        [DisplayAttribute(Name = "Cod Equipamento")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }
        
        [Required]
        [DisplayAttribute(Name = "Modelo Equipamento")]
        [StringLength(50)]
        public string Modelo { get; set; }

        [Required]
        [DisplayAttribute(Name = "ID Cliente")]
        [Column("IdCliente")]
        public int ClienteId { get; set; }

        [Required]
        [DisplayAttribute(Name = "Nome Cliente")]
        [ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; }

        [Required]
        [DisplayAttribute(Name = "Marca Equipamento")]
        [StringLength(50)]
        public string Marca { get; set; }

        [Required]
        [DisplayAttribute(Name = "Série Equipamento")]
        [StringLength(50)]
        [Column("NumeroSerie")]
        public string Serie { get; set; }

        [Required]
        [DisplayAttribute(Name = "Ano Equipamento")]
        [DataType(DataType.DateTime)]
        [Column("Ano")]
        public DateTime? Ano { get; set; }

        [NotMapped]
        public string AnoString
        {
            get
            {
                return Ano.HasValue ? $"{Ano.Value.Day.ToString("00")}/{Ano.Value.ToString("MMM", CultureInfo.CreateSpecificCulture("pt-BR")).ToUpper()}" : string.Empty;
            }
        }

        //[DisplayAttribute(Name = "Data de Cadastro")]
        //[DataType(DataType.DateTime)]
        //[Column("Ano")]
        //public DateTime DtCadastro { get; set; }
    }
}
