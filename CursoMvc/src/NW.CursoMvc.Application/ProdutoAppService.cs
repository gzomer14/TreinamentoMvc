using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using NW.CursoMvc.Application.Interfaces;
using NW.CursoMvc.Application.ViewModels;
using NW.CursoMvc.Domain.Entities;
using NW.CursoMvc.Domain.Interfaces.Services;
using NW.CursoMvc.Infra.Data.UnitOfWork;

namespace NW.CursoMvc.Application
{
    public class ProdutoAppService : AppService, IProdutoAppService

    {
        private readonly IProdutoService _produtoService;

        public ProdutoAppService(IProdutoService produtoService, IUnitOfWork uow)
            : base(uow)
        {
            _produtoService = produtoService;
        }

        public IEnumerable<ProdutoViewModel> TodosProdutos()
        {
            return Mapper.Map<IEnumerable<ProdutoViewModel>>(_produtoService.TodosProdutos());
        }

        public ProdutoViewModel Adicionar(ProdutoViewModel produtoViewModel, Guid id)
        {
            var produto = Mapper.Map<Produto>(produtoViewModel);

            var produtoReturn = _produtoService.Adicionar(produto,id);

            Commit();

            return Mapper.Map<ProdutoViewModel>(produtoReturn);
        }

        public ProdutoViewModel AdicionarProdForn(ProdutoViewModel produtoViewModel, Guid id)
        {
            var produto = Mapper.Map<Produto>(produtoViewModel);

            var prodReturn = _produtoService.AdicionarProdForn(produto, id);

            Commit();

            return Mapper.Map<ProdutoViewModel>(prodReturn);
        }

        public ProdutoViewModel Atualizar(ProdutoViewModel produtoViewModel, Guid id)
        {
            var prod = _produtoService.ObterPorId(produtoViewModel.ProdutoId);
            var produto = Mapper.Map(produtoViewModel, prod);
            var prodreturn = _produtoService.Atualizar(produto,id);
            Commit();

            return produtoViewModel;
        }

        public void Dispose()
        {
            _produtoService.Dispose();
            GC.SuppressFinalize(this);
        }

        public ProdutoViewModel ObterPorId(Guid id)
        {
            var prod = _produtoService.ObterPorId(id);

            return Mapper.Map<ProdutoViewModel>(prod);
        }

        public IEnumerable<ProdutoViewModel> ObterPorFornecedor(Guid id)
        {
            return Mapper.Map<IEnumerable<ProdutoViewModel>>(_produtoService.ObterPorFornecedor(id));
        }

        public void RemoverProduto(Guid id)
        {
            _produtoService.RemoverProduto(id);
        }

        public void Remover(Guid id)
        {
            _produtoService.Remover(id);
        }
    }
}