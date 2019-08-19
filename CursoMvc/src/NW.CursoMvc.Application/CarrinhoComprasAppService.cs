using System;
using System.Linq;
using System.Text;
using AutoMapper;
using NW.CursoMvc.Application.Interfaces;
using NW.CursoMvc.Application.ViewModels;
using NW.CursoMvc.Domain.Entities;
using NW.CursoMvc.Domain.Interfaces.Services;
using NW.CursoMvc.Infra.Data.UnitOfWork;

namespace NW.CursoMvc.Application
{
    public class CarrinhoComprasAppService : AppService, ICarrinhoComprasAppService
    {
        private readonly ICarrinhoComprasService _carrinhoComprasService;

        public int contador;

        public CarrinhoComprasAppService(ICarrinhoComprasService carrinhoComprasService, IUnitOfWork uow)
            : base(uow)
        {
            _carrinhoComprasService = carrinhoComprasService;
        }

        public CarrinhoComprasViewModel AbrirCarrinho(CarrinhoComprasViewModel carrinhoComprasViewModel, Guid id)
        {
            var carrinhoCompras = Mapper.Map<CarrinhoCompras>(carrinhoComprasViewModel);

            carrinhoCompras.ClienteId = id;

            contador = _carrinhoComprasService.Contador();

            contador++;

            carrinhoCompras.SequencialNumber = contador.ToString("000000");

            var carrinhoComprasReturn = _carrinhoComprasService.AbrirCarrinho(carrinhoCompras);

            Commit();

            return Mapper.Map<CarrinhoComprasViewModel>(carrinhoComprasReturn);
        }

        public void Dispose()
        {
            _carrinhoComprasService.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Remover(Guid id)
        {
            _carrinhoComprasService.Remover(id);

            Commit();
        }

        public CarrinhoComprasViewModel VerCarrinho(Guid idCliente)
        {
            var carrinhoCompras = new CarrinhoCompras();

            Guid? idCarrinho = _carrinhoComprasService.CarrinhoPorClienteId(idCliente);

            if (idCarrinho == null)
            {
                return null;
            }

            carrinhoCompras = _carrinhoComprasService.ObterPorId(idCarrinho.Value);

            carrinhoCompras.somaValores = carrinhoCompras.ItensCarrinho.Sum(a => a.ValorTotal);
            carrinhoCompras.ItensCarrinho = carrinhoCompras.ItensCarrinho.OrderBy(a => a.Id).ToList();

            /*  foreach (var item in carrinhoCompras.ItensCarrinho)
              {
                  carrinhoCompras.somaValores = carrinhoCompras.somaValores + item.ValorTotal;
              }
              */
            return Mapper.Map<CarrinhoComprasViewModel>(carrinhoCompras);
        }

        public bool VerificarExistencia(Guid id)
        {
            return _carrinhoComprasService.VerificarExistencia(id);
        }
    }
}