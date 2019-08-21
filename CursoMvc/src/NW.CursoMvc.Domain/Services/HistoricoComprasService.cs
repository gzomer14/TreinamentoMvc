using System;
using System.Collections.Generic;
using NW.CursoMvc.Domain.Entities;
using NW.CursoMvc.Domain.Interfaces.Repository;
using NW.CursoMvc.Domain.Interfaces.Services;

namespace NW.CursoMvc.Domain.Services
{
    public class HistoricoComprasService : IHistoricoComprasService
    {
        private readonly IHistoricoComprasRepository _historicoComprasRepository;

        public HistoricoComprasService(IHistoricoComprasRepository historicoComprasRepository)
        {
            _historicoComprasRepository = historicoComprasRepository;
        }

        public HistoricoCompras Adicionar(HistoricoCompras historicoCompras)
        {
            return _historicoComprasRepository.Adicionar(historicoCompras);
        }

        public void Dispose()
        {
            
        }

        public HistoricoCompras ItensPeloCarrinhoId(HistoricoCompras historicoCompras, Guid idCarrinho)
        {
            return _historicoComprasRepository.ItensPeloCarrinhoId(historicoCompras, idCarrinho);
        }

        public IEnumerable<dynamic> VerHistoricoPorCliente(Guid idCliente)
        {
            return _historicoComprasRepository.VerHistoricoPorCliente(idCliente);
        }

        public ICollection<ItensCarrinhoHistorico> ItensHistoricoPeloClienteId(Guid idCliente)
        {
            return _historicoComprasRepository.ItensHistoricoPeloClienteId(idCliente);
        }
    }
}