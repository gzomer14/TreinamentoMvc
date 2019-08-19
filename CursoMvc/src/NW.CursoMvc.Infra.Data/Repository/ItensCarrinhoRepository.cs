using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using NW.CursoMvc.Domain.Entities;
using NW.CursoMvc.Domain.Interfaces.Repository;
using NW.CursoMvc.Infra.Data.Context;

namespace NW.CursoMvc.Infra.Data.Repository
{
    public class ItensCarrinhoRepository : Repository<ItensCarrinho>, IItensCarrinhoRepository
    {
        public ItensCarrinhoRepository(CursoMvcContext context)
            :base(context)
        {
            
        }

        public Produto AcharProduto(Produto produto, Guid idProd)
        {
            var cn = Db.Database.Connection;
            var sql = @"SELECT * FROM Produto WHERE ProdutoId = @id";

            return cn.QueryFirst<Produto>(sql, new {id = idProd});
        }

        public int Contador()
        {
            var cn = Db.Database.Connection;
            var sql = @"SELECT COUNT(Id) AS 'Count'  FROM ItensCarrinho";

            var busca = cn.Query(sql);

            foreach (var rows in busca)
            {
                var fields = rows as IDictionary<string, object>;
                var count = fields["Count"];

                var countString = count.ToString();

                var countInt = int.Parse(countString);

                countInt++;

                return countInt;
            }

            return 1;
        }

        public void RemoverItens(Guid id)
        {
            var cn = Db.Database.Connection;
            var sql = @"SELECT ItensCarrinhoId FROM ItensCarrinho WHERE CarrinhoComprasId = @id";

            var busca = cn.Query(sql, new { id = id });

            foreach (var rows in busca)
            {
                var campos = rows as IDictionary<string, object>;
                var itensId = campos["ItensCarrinhoId"];

                var itensIdString = itensId.ToString();
                var itensIdGuid = Guid.Parse(itensIdString);

                Remover(itensIdGuid);
            }
        }

        //public ItensCarrinho AdicionarProduto(ItensCarrinho itensCarrinho)
        //{
        //    var i = 1;
        //    var cn = Db.Database.Connection;
        //    var sql =
        //        @"INSERT INTO ItensCarrinho VALUES (@ItensCarrinhoId,@Id,@Quantidade,@ProdutoId,@CarrinhoComprasId);";

        //    var itensCarrinhoReturn = cn.Query<ItensCarrinho>(sql, new
        //    {
        //        ItensCarrinhoId = itensCarrinho.ItensCarrinhoId,
        //        Id = i,
        //        Quantidade = itensCarrinho.Quantidade,
        //        ProdutoId = itensCarrinho.ProdutoId,
        //        CarrinhoComprasId = itensCarrinho.CarrinhoComprasId

        //    });

        //    return itensCarrinhoReturn;
        //}
    }
}