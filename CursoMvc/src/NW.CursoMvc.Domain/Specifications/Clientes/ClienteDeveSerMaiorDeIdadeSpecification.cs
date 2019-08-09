using System;
using DomainValidation.Interfaces.Specification;
using NW.CursoMvc.Domain.Entities;

namespace NW.CursoMvc.Domain.Specifications.Clientes
{
    public class ClienteDeveSerMaiorDeIdadeSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return DateTime.Now.Year - cliente.DataNascimento.Year >= 18;
        }
    }
}