using System;
using System.Collections.Generic;
using NW.CursoMvc.Domain.Entities;

namespace NW.CursoMvc.Domain.Interfaces.Repository
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        IEnumerable<Produto> ObterPorFornecedor(Guid id);

        Produto AdicionarProdForn(Produto produto, Guid id);
    }
}