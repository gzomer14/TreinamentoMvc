using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace NW.CursoMvc.Application.ViewModels
{
    public class ItensCarrinhoViewModel
    {
        public ItensCarrinhoViewModel()
        {
            ItensCarrinhoId = Guid.NewGuid();
        }

        [Key]
        public Guid ItensCarrinhoId { get; set; }

        public int Id { get; set; }

        public string NomeProduto { get; set; }

        public int Quantidade { get; set; }

        public double ValorTotal { get; set; }

        [ScaffoldColumn(false)]
        public Guid CarrinhoComprasId { get; set; }

        [ScaffoldColumn(false)]
        public Guid ProdutoId { get; set; }
    }
}