using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NW.CursoMvc.Domain.Entities
{
    public class ItensCarrinho
    {
        public ItensCarrinho()
        {
            ItensCarrinhoId = Guid.NewGuid();
        }

        [Key]
        public Guid ItensCarrinhoId { get; set; }

        public int Id { get; set; }

        public int Quantidade { get; set; }

        public string NomeProduto { get; set; }

        public double ValorTotal { get; set; }

        public Guid ProdutoId { get; set; }

        public virtual Produto Produto { get; set; }

        public Guid CarrinhoComprasId { get; set; }

        public virtual CarrinhoCompras CarrinhoCompras { get; set; }

        //public virtual IEnumerable<Produto> Produto { get; set; }

    }
}