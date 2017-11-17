﻿using System;
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
        [Column("EquipamentoId")]
        public int Id { get; set; }
        
        [Required]
        [DisplayAttribute(Name = "Modelo Equipamento")]
        [StringLength(50)]
        public string Modelo { get; set; }

        [Required]
        [DisplayAttribute(Name = "Marca Equipamento")]
        [StringLength(50)]
        public string Marca { get; set; }

        [Required]
        [DisplayAttribute(Name = "Ano Equipamento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.DateTime)]
        [Column("Ano")]
        public DateTime? Ano { get; set; }

        [Required]
        [DisplayAttribute(Name = "Série Equipamento")]
        [StringLength(50)]
        [Column("NumeroSerie")]
        public string Serie { get; set; }

        [Required]
        [Column("ClienteId")]
        public int ClienteId { get; set; }

        [Required]
        [ForeignKey("ClienteId")]
        [DisplayAttribute(Name = "Nome Cliente")]
        public virtual Cliente Cliente { get; set; }


        //[DisplayAttribute(Name = "Data de Cadastro")]
        //[DataType(DataType.DateTime)]
        //[Column("Ano")]
        //public DateTime DtCadastro { get; set; }
    }
}
