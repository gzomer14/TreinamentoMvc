using System;
using System.Collections.Generic;
using NW.CursoMvc.Domain.Entities;

namespace NW.CursoMvc.Domain.Interfaces.Services
{
    public interface IFornecedorService : IDisposable
    {
        Fornecedor Adicionar(Fornecedor fornecedor);

        Fornecedor ObterPorId(Guid id);

        IEnumerable<Fornecedor> ObterTodos();

        Fornecedor ObterPorCpf(string cpf);

        Fornecedor ObterPorEmail(string email);

        IEnumerable<Fornecedor> ObterAtivos();

        Fornecedor Atualizar(Fornecedor fornecedor);

        void RemoverFornecedor(Guid id);

        void Remover(Guid id);
    }
}