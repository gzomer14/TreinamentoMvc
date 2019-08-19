using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NW.CursoMvc.Application.ViewModels
{
    public class CarrinhoComprasViewModel
    {
        public CarrinhoComprasViewModel()
        {
            CarrinhoCompraId = Guid.NewGuid();
        }

        [Key]
        public Guid CarrinhoCompraId { get; set; }

        public double somaValores { get; set; }

        [MinLength(6)]
        [MaxLength(6)]
        public string SequencialNumber { get; set; }

        [ScaffoldColumn(false)]
        public Guid ClienteId { get; set; }

        public ICollection<ItensCarrinhoViewModel> ItensCarrinho { get; set; }
    }
}