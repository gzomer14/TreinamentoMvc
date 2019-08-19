using System;
using System.Collections.Generic;
using NW.CursoMvc.Application.ViewModels;
using NW.CursoMvc.Domain.Entities;

namespace NW.CursoMvc.Application.Interfaces
{
    public interface IItensCarrinhoAppService : IDisposable
    {
        ItensCarrinhoViewModel AdicionarProduto(ItensCarrinhoViewModel itensCarrinhoViewModel, Guid idCarrinho, Guid idProd);

        Produto AcharProduto(Produto produto, Guid idProd);

        void RemoverItens(Guid id);

        void RemoverProduto(Guid id);
    }
}