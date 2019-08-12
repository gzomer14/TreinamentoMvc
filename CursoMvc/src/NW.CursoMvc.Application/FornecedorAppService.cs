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
    public class FornecedorAppService : AppService, IFornecedorAppService
    {
        private readonly IFornecedorService _fornecedorService;

        public FornecedorAppService(IFornecedorService fornecedorService, IUnitOfWork uow)
            :base(uow)
        {
            _fornecedorService = fornecedorService;
        }

        public FornecedorProdutoViewModel Adicionar(FornecedorProdutoViewModel fornecedorProdutoViewModel)
        {
            var fornecedor = Mapper.Map<Fornecedor>(fornecedorProdutoViewModel);
            var produto = Mapper.Map<Produto>(fornecedorProdutoViewModel);

            fornecedor.Produtos.Add(produto);

            var fornecedorReturn = _fornecedorService.Adicionar(fornecedor);

            Commit();

            return Mapper.Map<FornecedorProdutoViewModel>(fornecedorReturn);
        }

        public FornecedorViewModel Atualizar(FornecedorViewModel fornecedorViewModel)
        {
            var fornecedor = Mapper.Map<Fornecedor>(fornecedorViewModel);
            _fornecedorService.Atualizar(fornecedor);

            return fornecedorViewModel;
        }

        public void Dispose()
        {
            _fornecedorService.Dispose();
            GC.SuppressFinalize(this);
        }

        public FornecedorViewModel ObterPorCpf(string cpf)
        {
            return Mapper.Map<FornecedorViewModel>(_fornecedorService.ObterPorCpf(cpf));
        }

        public FornecedorViewModel ObterPorEmail(string email)
        {
            return Mapper.Map<FornecedorViewModel>(_fornecedorService.ObterPorEmail(email));
        }

        public FornecedorViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<FornecedorViewModel>(_fornecedorService.ObterPorId(id));
        }

        public IEnumerable<FornecedorViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<FornecedorViewModel>>(_fornecedorService.ObterAtivos().ToList());
        }

        public void Remover(Guid id)
        {
            _fornecedorService.Remover(id);
        }
    }
}