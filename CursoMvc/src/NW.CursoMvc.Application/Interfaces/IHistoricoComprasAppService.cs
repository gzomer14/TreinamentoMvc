using System;
using System.Collections.Generic;
using NW.CursoMvc.Application.ViewModels;
using NW.CursoMvc.Domain.Entities;

namespace NW.CursoMvc.Application.Interfaces
{
    public interface IHistoricoComprasAppService : IDisposable
    {
        HistoricoComprasViewModel ItensPeloCarrinhoId(Guid idCarrinho);

        ICollection<ItensCarrinhoHistorico> VerHistoricoPorCliente(Guid idCliente);
    }
}