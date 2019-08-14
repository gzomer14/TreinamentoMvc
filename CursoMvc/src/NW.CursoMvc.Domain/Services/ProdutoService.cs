using System;
using System.Collections.Generic;
using NW.CursoMvc.Domain.Entities;
using NW.CursoMvc.Domain.Interfaces.Repository;
using NW.CursoMvc.Domain.Interfaces.Services;

namespace NW.CursoMvc.Domain.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public Produto Adicionar(Produto produto)
        {
            return _produtoRepository.Adicionar(produto);
        }

        public Produto AdicionarProdForn(Produto produto, Guid id)
        {
            return _produtoRepository.AdicionarProdForn(produto, id);
        }

        public Produto Atualizar(Produto produto)
        {
            return _produtoRepository.Atualizar(produto);
        }

        public void Dispose()
        {
            _produtoRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public Produto ObterPorId(Guid id)
        {
            return _produtoRepository.ObterPorId(id);
        }

        public IEnumerable<Produto> ObterPorFornecedor(Guid id)
        {
            return _produtoRepository.ObterPorFornecedor(id);
        }

        public void Remover(Guid id)
        {
            _produtoRepository.Remover(id);
        }
    }
}