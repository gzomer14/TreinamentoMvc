using System;
using System.Collections.Generic;
using NW.CursoMvc.Application.ViewModels;

namespace NW.CursoMvc.Application.Interfaces
{
    public interface IProdutoAppService : IDisposable
    {
        ProdutoViewModel Adicionar(ProdutoViewModel produtoViewModel);

        ProdutoViewModel ObterPorId(Guid id);

        IEnumerable<ProdutoViewModel> ObterTodos(); 
            
        ProdutoViewModel Atualizar(ProdutoViewModel produtoViewModel);

        void Remover(Guid id);
    }
}