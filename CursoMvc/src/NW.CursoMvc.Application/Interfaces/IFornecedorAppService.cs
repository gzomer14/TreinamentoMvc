using System;
using System.Collections.Generic;
using NW.CursoMvc.Application.ViewModels;

namespace NW.CursoMvc.Application.Interfaces
{
    public interface IFornecedorAppService : IDisposable
    {
        FornecedorProdutoViewModel Adicionar(FornecedorProdutoViewModel fornecedorProdutoViewModel);

        FornecedorProdutoViewModel ObterProdutos(FornecedorProdutoViewModel fornecedorProdutoViewModel);

        FornecedorViewModel ObterPorId(Guid id);

        IEnumerable<FornecedorViewModel> ObterTodos();

        FornecedorViewModel ObterPorCpf(string cpf);

        FornecedorViewModel ObterPorEmail(string email);

        FornecedorViewModel Atualizar(FornecedorViewModel fornecedorViewModel);

        void Remover(Guid id);
    }
}