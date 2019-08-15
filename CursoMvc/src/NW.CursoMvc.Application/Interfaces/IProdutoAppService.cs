using System;
using System.Collections.Generic;
using NW.CursoMvc.Application.ViewModels;

namespace NW.CursoMvc.Application.Interfaces
{
    public interface IProdutoAppService : IDisposable
    {
        ProdutoViewModel Adicionar(ProdutoViewModel produtoViewModel, Guid id);

        IEnumerable<ProdutoViewModel> TodosProdutos();

        ProdutoViewModel ObterPorId(Guid id);

        ProdutoViewModel AdicionarProdForn(ProdutoViewModel produtoViewModel, Guid id);

        IEnumerable<ProdutoViewModel> ObterPorFornecedor(Guid id); 
            
        ProdutoViewModel Atualizar(ProdutoViewModel produtoViewModel,Guid id);

        void RemoverProduto(Guid id);

        void Remover(Guid id);
    }
}