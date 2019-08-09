using System;
using System.Collections;
using System.Collections.Generic;
using NW.CursoMvc.Domain.Entities;

namespace NW.CursoMvc.Domain.Interfaces.Services
{
    public interface IClienteService : IDisposable
    {
        Cliente Adicionar(Cliente cliente);

        Cliente ObterPorId(Guid id);

        IEnumerable<Cliente> ObterTodos();

        Cliente ObterPorCpf(string cpf);

        Cliente ObterPorEmail(string email);

        IEnumerable<Cliente> ObterAtivos();

        Cliente Atualizar(Cliente cliente);

        void Remover(Guid id);
    }
}