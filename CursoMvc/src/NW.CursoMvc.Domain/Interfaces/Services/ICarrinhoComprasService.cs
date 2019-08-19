using System;
using NW.CursoMvc.Domain.Entities;

namespace NW.CursoMvc.Domain.Interfaces.Services
{
    public interface ICarrinhoComprasService : IDisposable
    {
        CarrinhoCompras AbrirCarrinho(CarrinhoCompras carrinhoCompras);

        Guid? CarrinhoPorClienteId(Guid idCliente);

        bool VerificarExistencia(Guid id);

        void Remover(Guid id);

        CarrinhoCompras ObterPorId(Guid id);

        int Contador();
    }
}