using System;
using System.Collections.Generic;
using NW.CursoMvc.Application.ViewModels;

namespace NW.CursoMvc.Application.Interfaces
{
    public interface IFornecedorAppService : IDisposable
    {
        FornecedorViewModel Adicionar(FornecedorViewModel fornecedorViewModel);

        FornecedorViewModel ObterPorId(Guid id);

        IEnumerable<FornecedorViewModel> ObterTodos();

        FornecedorViewModel ObterPorCpf(string cpf);

        FornecedorViewModel ObterPorEmail(string email);

        FornecedorViewModel Atualizar(FornecedorViewModel fornecedorViewModel);

        void RemoverFornecedor(Guid id);

        void Remover(Guid id);
    }
}