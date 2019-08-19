using System;
using System.Collections.Generic;
using NW.CursoMvc.Domain.Entities;

namespace NW.CursoMvc.Domain.Interfaces.Services
{
    public interface IItensCarrinhoService : IDisposable
    {
        ItensCarrinho AdicionarProduto(ItensCarrinho itensCarrinho);

        Produto AcharProduto(Produto produto,Guid idProd);

        void RemoverItens(Guid id);

        void RemoverProduto(Guid id);

        int Contador();
    }
}