using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using NW.CursoMvc.Domain.Entities;

namespace NW.CursoMvc.Domain.Interfaces.Services
{
    public interface IProdutoService : IDisposable
    {
        Produto Adicionar(Produto produto);

        Produto ObterPorId(Guid id);

        Produto Atualizar(Produto produto);

        IEnumerable<Produto> ObterTodos();

        void Remover(Guid id);
    }
}