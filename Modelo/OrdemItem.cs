using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo
{
    [Table("OrdemItem")]
    public class OrdemItem : IModel<int>
    {
        [Column("OrdemItemId")]
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:N}", ApplyFormatInEditMode = true)]
        public decimal Valor { get; set; }

        public int Quantidade { get; set; }

        [NotMapped]
        public virtual Decimal Total { get; set; }


        #region Relacionamentos
        // Relacionamento Tabela Ordem
        public int OrdemId { get; set; }

        [ForeignKey("OrdemId")]
        public virtual Ordem Ordem { get; set; }

        // Relacionamento Tabela Servico
        public int ServicoId { get; set; }

        //[DisplayAttribute(Name = "Descrição")]
        [ForeignKey("ServicoId")]
        public virtual ServicoP ServicoP { get; set; }
        
        #endregion
    }
}
