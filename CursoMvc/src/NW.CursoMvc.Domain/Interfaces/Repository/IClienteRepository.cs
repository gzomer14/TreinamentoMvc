using System.Collections.Generic;
using NW.CursoMvc.Domain.Entities;

namespace NW.CursoMvc.Domain.Interfaces.Repository
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Cliente ObterPorCpf(string cpf);

        Cliente ObterPorEmail(string email);

        IEnumerable<Cliente> ObterAtivos();
    }
}