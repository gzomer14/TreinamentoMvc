﻿using NW.CursoMvc.Application;
using NW.CursoMvc.Application.Interfaces;
using NW.CursoMvc.Domain.Interfaces.Repository;
using NW.CursoMvc.Domain.Interfaces.Services;
using NW.CursoMvc.Domain.Services;
using NW.CursoMvc.Infra.Data.Context;
using NW.CursoMvc.Infra.Data.Repository;
using NW.CursoMvc.Infra.Data.UnitOfWork;
using SimpleInjector;

namespace NW.CursoMvc.Infra.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            //Lifestyle.Transient => Uma instancia para cada solicitacao;
            //Lifestyle.Singleton => Uma instancia unica para a classe;
            //Lifestyle.Scoped => Uma instancia unica para o request;

            // App
            container.Register<IClienteAppService, ClienteAppService>(Lifestyle.Scoped);
            container.Register<IFornecedorAppService, FornecedorAppService>(Lifestyle.Scoped);
            container.Register<IProdutoAppService, ProdutoAppService>(Lifestyle.Scoped);
            container.Register<IItensCarrinhoAppService, ItensCarrinhoAppService>(Lifestyle.Scoped);
            container.Register<ICarrinhoComprasAppService, CarrinhoComprasAppService>(Lifestyle.Scoped);
            container.Register<IHistoricoComprasAppService, HistoricoComprasAppService>(Lifestyle.Scoped);

            // Domain
            container.Register<IClienteService, ClienteService>(Lifestyle.Scoped);
            container.Register<IFornecedorService, FornecedorService>(Lifestyle.Scoped);
            container.Register<IProdutoService, ProdutoService>(Lifestyle.Scoped);
            container.Register<IItensCarrinhoService, ItensCarrinhoService>(Lifestyle.Scoped);
            container.Register<ICarrinhoComprasService, CarrinhoComprasService>(Lifestyle.Scoped);
            container.Register<IHistoricoComprasService, HistoricoComprasService>(Lifestyle.Scoped);

            // Data
            container.Register<IClienteRepository, ClienteRepository>(Lifestyle.Scoped);
            container.Register<IFornecedorRepository, FornecedorRepository>(Lifestyle.Scoped);
            container.Register<IProdutoRepository, ProdutoRepository>(Lifestyle.Scoped);
            container.Register<IItensCarrinhoRepository, ItensCarrinhoRepository>(Lifestyle.Scoped);
            container.Register<ICarrinhoComprasRepository, CarrinhoComprasRepository>(Lifestyle.Scoped);
            container.Register<IHistoricoComprasRepository, HistoricoComprasRepository>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<CursoMvcContext>(Lifestyle.Scoped);
        }
    }
}