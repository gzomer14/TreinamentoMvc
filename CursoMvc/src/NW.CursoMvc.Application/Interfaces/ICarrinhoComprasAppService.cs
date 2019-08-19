using System;
using NW.CursoMvc.Application.ViewModels;

namespace NW.CursoMvc.Application.Interfaces
{
    public interface ICarrinhoComprasAppService : IDisposable
    {
        CarrinhoComprasViewModel AbrirCarrinho(CarrinhoComprasViewModel carrinhoComprasViewModel, Guid id);

        bool VerificarExistencia(Guid id);

        void Remover(Guid id);

        CarrinhoComprasViewModel VerCarrinho(Guid idCliente);

    }
}