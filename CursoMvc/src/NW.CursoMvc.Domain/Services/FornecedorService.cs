using System;
using System.Collections.Generic;
using NW.CursoMvc.Domain.Entities;
using NW.CursoMvc.Domain.Interfaces.Repository;
using NW.CursoMvc.Domain.Interfaces.Services;

namespace NW.CursoMvc.Domain.Services
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorService(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        public Fornecedor Adicionar(Fornecedor fornecedor)
        {
            return _fornecedorRepository.Adicionar(fornecedor);
        }

        public Fornecedor Atualizar(Fornecedor fornecedor)
        {
            return _fornecedorRepository.Atualizar(fornecedor);
        }

        public void Dispose()
        {
            _fornecedorRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Fornecedor> ObterAtivos()
        {
            return _fornecedorRepository.ObterAtivos();
        }

        public Fornecedor ObterPorCpf(string cpf)
        {
            return _fornecedorRepository.ObterPorCpf(cpf);
        }

        public Fornecedor ObterPorEmail(string email)
        {
            return _fornecedorRepository.ObterPorEmail(email);
        }

        public Fornecedor ObterPorId(Guid id)
        {
            return _fornecedorRepository.ObterPorId(id);
        }

        public IEnumerable<Fornecedor> ObterTodos()
        {
            return _fornecedorRepository.ObterTodos();
        }

        public void RemoverFornecedor(Guid id)
        {
            _fornecedorRepository.RemoverFornecedor(id);
        }

        public void Remover(Guid id)
        {
            _fornecedorRepository.Remover(id);
        }
    }
}