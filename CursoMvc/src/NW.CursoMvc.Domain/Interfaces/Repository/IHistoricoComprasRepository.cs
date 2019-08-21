using System;
using System.Collections.Generic;
using NW.CursoMvc.Domain.Entities;

namespace NW.CursoMvc.Domain.Interfaces.Repository
{
    public interface IHistoricoComprasRepository : IRepository<HistoricoCompras>
    {
        HistoricoCompras ItensPeloCarrinhoId(HistoricoCompras historicoCompras, Guid idCarrinho);

        IEnumerable<dynamic> VerHistoricoPorCliente(Guid idCliente);

        ICollection<ItensCarrinhoHistorico> ItensHistoricoPeloClienteId(Guid idCliente);

        Guid? BuscarClienteId(Guid idCarrinho);
    }
}