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
        [Column("ClienteId")]
        public int Id { get; set; }

        [Required(ErrorMessage ="O campo precisa ser preechido")]
        public string Nome { get; set; }

        [Required]
        [DisplayAttribute(Name = "Endereço")]
        public string Endereco { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:(##) #####-####}")]
        [DisplayAttribute(Name = "Telefone")]
        public string Telefone { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:###.###.###/####-##}")]
        public string CNPJ{ get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:###.###.###-##}")]
        public string CPF { get; set; }

        // Cliente pode ter Coleção de Equipamentos 
        public virtual ICollection<Equipamento> Equipamentos { get; set; }
    }
}
