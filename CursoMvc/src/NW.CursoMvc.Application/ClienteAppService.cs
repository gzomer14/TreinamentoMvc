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
    public class ClienteAppService : AppService, IClienteAppService
    {
        private readonly IClienteService _clienteService;

        public ClienteAppService(IClienteService clienteService, IUnitOfWork uow)
            :base(uow)
        {
            _clienteService = clienteService;
        }

        public ClienteEnderecoViewModel Adicionar(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            var cliente = Mapper.Map<Cliente>(clienteEnderecoViewModel);
            var endereco = Mapper.Map<Endereco>(clienteEnderecoViewModel);

            cliente.Enderecos.Add(endereco);
            // Unit of Work
            var clienteReturn = _clienteService.Adicionar(cliente);

            // Verificar se o dominio não criticou nada
            if (clienteReturn.ValidationResult.IsValid)
                 Commit();

            return Mapper.Map<ClienteEnderecoViewModel>(clienteReturn);
        }

        public ClienteViewModel Atualizar(ClienteViewModel clienteViewModel)
        {
            var cliente = Mapper.Map<Cliente>(clienteViewModel);
            _clienteService.Atualizar(cliente);

            return clienteViewModel;
        }

        public void Dispose()
        {
            _clienteService.Dispose();
            GC.SuppressFinalize(this);
        }

        public ClienteViewModel ObterPorCpf(string cpf)
        {
            return Mapper.Map<ClienteViewModel>(_clienteService.ObterPorCpf(cpf));
        }

        public ClienteViewModel ObterPorEmail(string email)
        {
            return Mapper.Map<ClienteViewModel>(_clienteService.ObterPorEmail(email));
        }

        public ClienteViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<ClienteViewModel>(_clienteService.ObterPorId(id));
        }

        public IEnumerable<ClienteViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<ClienteViewModel>>(_clienteService.ObterAtivos().ToList());
        }

        public void Remover(Guid id)
        {
            _clienteService.Remover(id);
        }
    }
}