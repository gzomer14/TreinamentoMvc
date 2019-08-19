using System;
using System.Collections.Generic;
using NW.CursoMvc.Domain.Entities;

namespace NW.CursoMvc.Domain.Interfaces.Repository
{
    public interface IItensCarrinhoRepository : IRepository<ItensCarrinho>
    {
        //ItensCarrinho AdicionarProduto(ItensCarrinho itensCarrinho);

        Produto AcharProduto(Produto produto, Guid idProdGuid);

        void RemoverItens(Guid id);

        int Contador();
    }
}