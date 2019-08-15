using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using NW.CursoMvc.Domain.Entities;
using NW.CursoMvc.Domain.Interfaces.Repository;
using NW.CursoMvc.Infra.Data.Context;

namespace NW.CursoMvc.Infra.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(CursoMvcContext context)
            : base(context)
        {

        }

        public IEnumerable<Produto> ObterPorFornecedor(Guid id)
        {
            var cn = Db.Database.Connection;
            var sql = @"SELECT * FROM Produto p " +
                        "INNER JOIN Fornecedor f " +
                        "ON p.FornecedorId = f.FornecedorId " +
                        "WHERE p.FornecedorId = @sid";

            

            var produto = cn.Query<Produto>(sql, new {sid = id});

            return produto;
        }

        public void RemoverProduto(Guid id)
        {
            var cn = Db.Database.Connection;
            var sql = "delete from Produto where ProdutoId = @idprod";

            cn.Query<Fornecedor>(sql, new { idprod = id });
        }

        public Produto AdicionarProdForn(Produto produto, Guid id)
        {
            var cn = Db.Database.Connection;
            var sql = @"INSERT INTO Produto values (@ProdutoId,@nomeProd,@descricao,@valor,@peso,@FornecedorId)";
            var prod = produto;

            var prodreturn = cn.Query<Produto>(sql,
                new
                {
                    ProdutoId = prod.ProdutoId,
                    nomeProd = prod.nomeProd,
                    descricao = prod.descricao,
                    valor = prod.valor,
                    peso = prod.peso,
                    FornecedorId = id
                });

            return prodreturn.FirstOrDefault();
        }

        public IEnumerable<Produto> TodosProdutos()
        {
            var cn = Db.Database.Connection;
            var sql = @"SELECT * FROM Produto";

            return cn.Query<Produto>(sql);
        }
    }
}