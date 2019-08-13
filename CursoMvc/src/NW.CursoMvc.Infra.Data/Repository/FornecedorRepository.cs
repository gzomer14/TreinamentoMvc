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
            var sql = @"SELECT * FROM FORNECEDOR";

            return cn.Query<Fornecedor>(sql);
        }

        public override Fornecedor ObterPorId(Guid id)
        {
            var cn = Db.Database.Connection;
            var sql = @"SELECT * FROM Fornecedor f " +
                      "LEFT JOIN Produto p " +
                      "ON f.FornecedorId = p.FornecedorId " +
                      "WHERE f.FornecedorId = @sid";

            var fornecedor = cn.Query<Fornecedor, Produto, Fornecedor>(sql,
                (f, p) =>
                {
                    f.Produtos.Add(p);
                    return f;
                }, new {sid = id}, splitOn: "FornecedorId, ProdutoId");
            return fornecedor.FirstOrDefault();

            /*return DbSet.Include(a => a.Produtos)
                .FirstOrDefault(a =>
                    a.FornecedorId == id);
                (Outro metodo para acessar os dados, utilizando o proprio entity framework. É um metodo mais demorado 
                e pesado do que utilizando o Dapper, porem possui mais recursos).       
             */
        }
    }
}