using System;
using System.Collections.Generic;
using NW.CursoMvc.Application.ViewModels;

namespace NW.CursoMvc.Application.Interfaces
{
    public interface IClienteAppService : IDisposable
    {
        ClienteEnderecoViewModel Adicionar(ClienteEnderecoViewModel clienteEnderecoViewModel);

        ClienteViewModel ObterPorId(Guid id);

        IEnumerable<ClienteViewModel> ObterTodos();

        ClienteViewModel ObterPorCpf(string cpf);

        ClienteViewModel ObterPorEmail(string email);

        ClienteViewModel Atualizar(ClienteViewModel clienteViewModel);

        void Remover(Guid id);
    }
}