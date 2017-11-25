using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo
{
    [Table("Servico")]
    public class ServicoP : IModel<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ServicoId")]
        public int Id { get; set; }

        [Required]
        [DisplayAttribute(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required]
        public double Valor { get; set; }

        #region Relacionamentos

        // Realacionamento Tabela TipoServico
        [Required]
        public int TipoServicoId { get; set; }

        [ForeignKey("TipoServicoId")]
        public virtual TipoServico TipoServico { get; set; }

        #endregion
    }
}