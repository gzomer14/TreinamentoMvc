﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using NW.CursoMvc.Domain.Entities;

namespace NW.CursoMvc.Domain.Interfaces.Services
{
    public interface IProdutoService : IDisposable
    {
        Produto Adicionar(Produto produto);

        Produto AdicionarProdForn(Produto produto, Guid id);

        Produto ObterPorId(Guid id);

        Produto Atualizar(Produto produto);

        IEnumerable<Produto> ObterPorFornecedor(Guid id);

        void RemoverProduto(Guid id);

        void Remover(Guid id);
    }
}