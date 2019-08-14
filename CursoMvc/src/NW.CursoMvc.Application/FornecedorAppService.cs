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

        public FornecedorViewModel Adicionar(FornecedorViewModel fornecedorViewModel)
        {
            var fornecedor = Mapper.Map<Fornecedor>(fornecedorViewModel);

            fornecedor.ativo = true;

            var fornecedorReturn = _fornecedorService.Adicionar(fornecedor);

            Commit();

            return Mapper.Map<FornecedorViewModel>(fornecedorReturn);
        }

        public FornecedorProdutoViewModel ObterProdutos(FornecedorProdutoViewModel fornecedorProdutoViewModel)
        {
            var nada = new FornecedorProdutoViewModel();

            return nada;
        }

        public FornecedorViewModel Atualizar(FornecedorViewModel fornecedorViewModel)
        {
            var forn = _fornecedorService.ObterPorId(fornecedorViewModel.FornecedorId);
            forn.ativo = true;
            var fornecedor = Mapper.Map(fornecedorViewModel, forn);
            fornecedor.ativo = true;
            var fornreturn = _fornecedorService.Atualizar(fornecedor);
            Commit();


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
            var teste = _fornecedorService.ObterPorId(id);

            return Mapper.Map<FornecedorViewModel>(teste);
        }

        public IEnumerable<FornecedorViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<FornecedorViewModel>>(_fornecedorService.ObterAtivos().ToList());
        }

        public void RemoverFornecedor(Guid id)
        {
            _fornecedorService.RemoverFornecedor(id);
        }

        public void Remover(Guid id)
        {
            _fornecedorService.Remover(id);
        }
    }
}