using System;
using System.Collections.Generic;
using NW.CursoMvc.Domain.Entities;

namespace NW.CursoMvc.Domain.Interfaces.Services
{
    public interface IHistoricoComprasService : IDisposable
    {
        HistoricoCompras ItensPeloCarrinhoId(HistoricoCompras historicoCompras, Guid idCarrinho);

        IEnumerable<dynamic> VerHistoricoPorCliente(Guid idCliente);

        ICollection<ItensCarrinhoHistorico> ItensHistoricoPeloClienteId(Guid historicoId);

        HistoricoCompras Adicionar(HistoricoCompras historicoCompras);
    }
}