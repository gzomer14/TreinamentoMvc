using System;
using System.ComponentModel.DataAnnotations;

namespace NW.CursoMvc.Domain.Entities
{
    public class ItensCarrinhoHistorico
    {
        public ItensCarrinhoHistorico()
        {
            ItensCarrinhoHistoricoId = Guid.NewGuid();
        }

        [Key]
        public Guid ItensCarrinhoHistoricoId { get; set; }

        public int Id { get; set; }

        public int Quantidade { get; set; }

        public string NomeProduto { get; set; }

        public double ValorTotal { get; set; }

        public Guid ProdutoId { get; set; }

        public virtual Produto Produto { get; set; }

        public Guid HistoricoId { get; set; }

        public virtual HistoricoCompras HistoricoCompras { get; set; }
    }
}