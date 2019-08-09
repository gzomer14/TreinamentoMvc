using DomainValidation.Interfaces.Specification;
using NW.CursoMvc.Domain.Entities;
using NW.CursoMvc.Domain.Validation.Documentos;

namespace NW.CursoMvc.Domain.Specifications.Clientes
{
    public class ClienteDeveTerCpfValidoSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return CpfValidation.Validar(cliente.CPF);
        }
    }
}