using System;
using System.Collections;
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
    public class HistoricoComprasAppService : AppService, IHistoricoComprasAppService
    {
        private readonly IHistoricoComprasService _historicoComprasService;

        public HistoricoComprasAppService(IHistoricoComprasService historicoComprasService, IUnitOfWork uow)
            :base(uow)
        {
            _historicoComprasService = historicoComprasService;
        }

        public void Dispose()
        {
            
        }

        public HistoricoComprasViewModel ItensPeloCarrinhoId(Guid idCarrinho)
        {
            var historicoCompras = new HistoricoCompras();
            historicoCompras = _historicoComprasService.ItensPeloCarrinhoId(historicoCompras,idCarrinho);

            _historicoComprasService.Adicionar(historicoCompras);

            Commit();

            return Mapper.Map<HistoricoComprasViewModel>(historicoCompras);
        }

        public ICollection<ItensCarrinhoHistorico> VerHistoricoPorCliente(Guid idCliente)
        {
            var itensCarrinho = _historicoComprasService.ItensHistoricoPeloClienteId(idCliente);

            return itensCarrinho;
        }
    }
}