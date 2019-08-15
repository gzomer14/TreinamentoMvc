using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using NW.CursoMvc.Domain.Entities;

namespace NW.CursoMvc.Domain.Interfaces.Services
{
    public interface IProdutoService : IDisposable
    {
        Produto Adicionar(Produto produto,Guid id);

        IEnumerable<Produto> TodosProdutos();
            
        Produto AdicionarProdForn(Produto produto, Guid id);

        Produto ObterPorId(Guid id);

        Produto Atualizar(Produto produto,Guid id);

        IEnumerable<Produto> ObterPorFornecedor(Guid id);

        void RemoverProduto(Guid id);

        void Remover(Guid id);
    }
}