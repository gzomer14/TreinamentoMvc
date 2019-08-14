using System;
using System.Collections.Generic;
using NW.CursoMvc.Domain.Entities;

namespace NW.CursoMvc.Domain.Interfaces.Repository
{
    public interface IFornecedorRepository : IRepository<Fornecedor>
    {
        Fornecedor ObterPorCpf(string cpf);

        Fornecedor ObterPorEmail(string email);

        void RemoverFornecedor(Guid id);

        IEnumerable<Fornecedor> ObterAtivos();

    }
}