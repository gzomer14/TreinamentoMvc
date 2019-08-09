using DomainValidation.Interfaces.Specification;
using NW.CursoMvc.Domain.Entities;
using NW.CursoMvc.Domain.Interfaces.Repository;

namespace NW.CursoMvc.Domain.Specifications.Clientes
{
    public class ClienteDevePossuirCPFUnicoSpecification : ISpecification<Cliente>
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteDevePossuirCPFUnicoSpecification(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public bool IsSatisfiedBy(Cliente cliente)
        {
            return _clienteRepository.ObterPorCpf(cliente.CPF) == null;
        }
    }
}