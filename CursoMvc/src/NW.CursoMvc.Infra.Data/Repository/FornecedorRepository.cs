using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using NW.CursoMvc.Domain.Entities;
using NW.CursoMvc.Domain.Interfaces.Repository;
using NW.CursoMvc.Infra.Data.Context;

namespace NW.CursoMvc.Infra.Data.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(CursoMvcContext context)
            :base(context)
        {

        }

        public IEnumerable<Fornecedor> ObterAtivos()
        {
            return Buscar(f => f.ativo);
        }

        public Fornecedor ObterPorCpf(string cpf)
        {
            return Buscar(f => f.cpf == cpf).FirstOrDefault();
        }

        public Fornecedor ObterPorEmail(string email)
        {
            return Buscar(f => f.email == email).FirstOrDefault();
        }

        public override void Remover(Guid id)
        {
            var fornecedor = ObterPorId(id);
            fornecedor.ativo = false;
            Atualizar(fornecedor);
        }

        public override IEnumerable<Fornecedor> ObterTodos()
        {
            var cn = Db.Database.Connection;
            var sql = @"SELECT * FROM FORNECEDORES";

            return cn.Query<Fornecedor>(sql);
        }

        public override Fornecedor ObterPorId(Guid id)
        {
            var cn = Db.Database.Connection;
            var sql = @"SELECT * FROM Fornecedores f " +
                      "LEFT JOIN Produtos p " +
                      "ON f.FornecedorId = p.FornecedorId " +
                      "WHERE f.FornecedorId = @sid";

            var fornecedor = cn.Query<Fornecedor, Produto, Fornecedor>(sql,
                (f, p) =>
                {
                    f.Produtos.Add(p);
                    return f;
                }, new {sid = id}, splitOn: "FornecedorId, ProdutoId");
            return fornecedor.FirstOrDefault();
        }
    }
}