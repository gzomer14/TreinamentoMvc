using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NW.CursoMvc.Domain.Entities
{
    public class CarrinhoCompras
    {
        public CarrinhoCompras()
        {
            CarrinhoCompraId = Guid.NewGuid();
            ItensCarrinho = new List<ItensCarrinho>();
        }

        [Key]
        public Guid CarrinhoCompraId { get; set; }

        public Guid ClienteId { get; set; }

        public double somaValores { get; set; }

        [MaxLength(6)]
        [MinLength(6)]
        public string SequencialNumber { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual ICollection<ItensCarrinho> ItensCarrinho { get; set; }
    }
}