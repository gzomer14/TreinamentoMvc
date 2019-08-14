using System;
using System.Collections.Generic;
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

        public IEnumerable<Produto> ObterTodos()
        {
            var cn = Db.Database.Connection;
            var sql = @"SELECT * FROM Produto";

                        

            return cn.Query<Produto>(sql);
        }

    }
}