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
    
        public ProdutoViewModel Adicionar(ProdutoViewModel produtoViewModel)
        {
            var produto = Mapper.Map<Produto>(produtoViewModel);

            var produtoReturn = _produtoService.Adicionar(produto);

            Commit();

            return Mapper.Map<ProdutoViewModel>(produtoReturn);
        }

        public ProdutoViewModel Atualizar(ProdutoViewModel produtoViewModel)
        {
            var prod = _produtoService.ObterPorId(produtoViewModel.ProdutoId);
            var produto = Mapper.Map(produtoViewModel, prod);
            var prodreturn = _produtoService.Atualizar(produto);
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

        public IEnumerable<ProdutoViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<ProdutoViewModel>>(_produtoService.ObterTodos());
        }

        public void Remover(Guid id)
        {
            _produtoService.Remover(id);
        }
    }
}