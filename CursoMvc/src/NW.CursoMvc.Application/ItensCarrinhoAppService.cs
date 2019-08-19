using System;
using System.Collections.Generic;
using AutoMapper;
using NW.CursoMvc.Application.Interfaces;
using NW.CursoMvc.Application.ViewModels;
using NW.CursoMvc.Domain.Entities;
using NW.CursoMvc.Domain.Interfaces.Services;
using NW.CursoMvc.Infra.Data.UnitOfWork;

namespace NW.CursoMvc.Application
{
    public class ItensCarrinhoAppService : AppService, IItensCarrinhoAppService
    {

        private readonly IItensCarrinhoService _itensCarrinhoService;

        public ItensCarrinhoAppService(IItensCarrinhoService itensCarrinhoService, IUnitOfWork uow)
            :base(uow)
        {
            _itensCarrinhoService = itensCarrinhoService;
        }

        public ItensCarrinhoViewModel AdicionarProduto(ItensCarrinhoViewModel itensCarrinhoViewModel, Guid idCarrinho,Guid idProd)
        {
            var itensCarrinho = Mapper.Map<ItensCarrinho>(itensCarrinhoViewModel);

            itensCarrinho.ProdutoId = idProd;
            itensCarrinho.CarrinhoComprasId = idCarrinho;

            var produto = new Produto();

            produto = AcharProduto(produto,idProd);

            itensCarrinho.ValorTotal = itensCarrinho.ValorTotal + (produto.valor*itensCarrinho.Quantidade);

            itensCarrinho.Id = _itensCarrinhoService.Contador();

            itensCarrinho.NomeProduto = produto.nomeProd;

            var itensCarrinhoReturn = _itensCarrinhoService.AdicionarProduto(itensCarrinho);

            Commit();

            return Mapper.Map<ItensCarrinhoViewModel>(itensCarrinhoReturn);
        }

        public Produto AcharProduto(Produto produto, Guid idProd)
        {
            return _itensCarrinhoService.AcharProduto(produto,idProd);
        }

        public void Dispose()
        {
            _itensCarrinhoService.Dispose();
            GC.SuppressFinalize(this);
        }

        public void RemoverProduto(Guid id)
        {
            _itensCarrinhoService.RemoverProduto(id);

            Commit();
        }

        public void RemoverItens(Guid id)
        {
            _itensCarrinhoService.RemoverItens(id);

            Commit();
        }
    }
}