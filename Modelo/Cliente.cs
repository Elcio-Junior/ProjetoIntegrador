using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    [Table("Cliente")]
    public partial class Cliente : IModel<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayAttribute(Name = "Cod Cliente")]
        public int Id { get; set; }

        [Required]
        [DisplayAttribute(Name = "Nome")]
        public string Nome { get; set; }

        [Required]
        [DisplayAttribute(Name = "Numero CPF")]
        //[ValidationCPF]
        public string Documento { get; set; }

        [Required]
        [DisplayAttribute(Name = "Endereço")]
        public string Endereco { get; set; }

        [Required]
        [DisplayAttribute(Name = "Telefone")]
        public string Telefone { get; set; }
    }
}
