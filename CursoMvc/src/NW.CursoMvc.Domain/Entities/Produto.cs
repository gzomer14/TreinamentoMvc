using System;

namespace NW.CursoMvc.Domain.Entities
{
    public class Produto
    {
        public Produto()
        {
            ProdutoId = Guid.NewGuid();
        }

        public Guid ProdutoId { get; set; }

        public string nome { get; set; }
        public string descricao { get; set; }
        public double valor { get; set; }
        public double peso { get; set; }
        public Guid FornecedorId { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
    }
}