using System;
using NW.CursoMvc.Domain.Entities;
using NW.CursoMvc.Domain.Interfaces.Repository;
using NW.CursoMvc.Domain.Interfaces.Services;

namespace NW.CursoMvc.Domain.Services
{
    public class CarrinhoComprasService : ICarrinhoComprasService
    {
        private readonly ICarrinhoComprasRepository _carrinhoComprasRepository;

        public CarrinhoComprasService(ICarrinhoComprasRepository carrinhoComprasRepository)
        {
            _carrinhoComprasRepository = carrinhoComprasRepository;
        }

        public CarrinhoCompras AbrirCarrinho(CarrinhoCompras carrinhoCompras)
        {
            return _carrinhoComprasRepository.Adicionar(carrinhoCompras);
        }

        public int Contador()
        {
           return _carrinhoComprasRepository.Contador();
        }

        public Guid? CarrinhoPorClienteId(Guid idCliente)
        {
            return _carrinhoComprasRepository.CarrinhoPorClienteId(idCliente);
        }

        public void Dispose()
        {
            _carrinhoComprasRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public CarrinhoCompras ObterPorId(Guid id)
        {
            return _carrinhoComprasRepository.ObterPorId(id);
        }

        public bool VerificarExistencia(Guid id)
        {
            return _carrinhoComprasRepository.VerificarExistencia(id);
        }

        public void Remover(Guid id)
        {
            _carrinhoComprasRepository.Remover(id);
        }

    }
}