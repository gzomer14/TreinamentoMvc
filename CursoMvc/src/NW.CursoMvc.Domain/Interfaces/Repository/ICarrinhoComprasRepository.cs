using System;
using NW.CursoMvc.Domain.Entities;

namespace NW.CursoMvc.Domain.Interfaces.Repository
{
    public interface ICarrinhoComprasRepository : IRepository<CarrinhoCompras>
    {
        Guid? CarrinhoPorClienteId(Guid idCliente);

        bool VerificarExistencia(Guid id);

        int Contador();
    }
}