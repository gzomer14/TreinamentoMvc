using System;
using System.Collections.Generic;
using NW.CursoMvc.Domain.Entities;
using NW.CursoMvc.Domain.Interfaces.Repository;
using NW.CursoMvc.Domain.Interfaces.Services;

namespace NW.CursoMvc.Domain.Services
{
    public class ItensCarrinhoService : IItensCarrinhoService
    {
        private readonly IItensCarrinhoRepository _itensCarrinhoRepository;

        public ItensCarrinhoService(IItensCarrinhoRepository itensCarrinhoRepository)
        {
            _itensCarrinhoRepository = itensCarrinhoRepository;
        }

        public Produto AcharProduto(Produto produto,Guid idProd)
        {
            return _itensCarrinhoRepository.AcharProduto(produto, idProd);
        }

        public ItensCarrinho AdicionarProduto(ItensCarrinho itensCarrinho)
        {
            return _itensCarrinhoRepository.Adicionar(itensCarrinho);
        }

        public int Contador()
        {
            return _itensCarrinhoRepository.Contador();
        }

        public void Dispose()
        {
            _itensCarrinhoRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public void RemoverItens(Guid id)
        {
            _itensCarrinhoRepository.RemoverItens(id);
        }

        public void RemoverProduto(Guid id)
        {
            _itensCarrinhoRepository.Remover(id);
        }
    }
}