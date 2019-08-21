using System;
using System.ComponentModel.DataAnnotations;

namespace NW.CursoMvc.Application.ViewModels
{
    public class ItensCarrinhoHistoricoViewModel
    {
        public ItensCarrinhoHistoricoViewModel()
        {
            ItensCarrinhoHistoricoId = Guid.NewGuid();
        }

        [Key]
        public Guid ItensCarrinhoHistoricoId { get; set; }

        public int Id { get; set; }

        public string NomeProduto { get; set; }

        public int Quantidade { get; set; }

        public double ValorTotal { get; set; }

        [ScaffoldColumn(false)]
        public Guid ProdutoId { get; set; }

        [ScaffoldColumn(false)]
        public Guid HistoricoId { get; set; }
    }
}