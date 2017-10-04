using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo
{
    [Table("Cliente")]
    public partial class Cliente : IModel<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayAttribute(Name = "Cod Cliente")]
        public int Id { get; set; }

        [Required(ErrorMessage ="O campo precisa ser preechido")]
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

        public virtual ICollection<Equipamento> IEquipamento { get; set; }
        public virtual ICollection<Ordem> IOrdem { get; set; }

    }
}
