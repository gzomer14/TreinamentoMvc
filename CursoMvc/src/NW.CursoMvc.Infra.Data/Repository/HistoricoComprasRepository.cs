using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using NW.CursoMvc.Domain.Entities;
using NW.CursoMvc.Domain.Interfaces.Repository;
using NW.CursoMvc.Infra.Data.Context;

namespace NW.CursoMvc.Infra.Data.Repository
{
    public class HistoricoComprasRepository : Repository<HistoricoCompras>, IHistoricoComprasRepository
    {
        public HistoricoComprasRepository(CursoMvcContext context)
            : base(context)
        {

        }

        public HistoricoCompras ItensPeloCarrinhoId(HistoricoCompras historicoCompras, Guid idCarrinho)
        {
            var cn = Db.Database.Connection;
            var sql = @"SELECT * FROM ItensCarrinho WHERE CarrinhoComprasId = @id";
            
            var buscar = cn.Query<ItensCarrinhoHistorico>(sql, new {id = idCarrinho});

            var buscarList = buscar.ToList();

            historicoCompras.ItensCarrinhoHistorico = buscarList;
            Guid ClienteId = BuscarClienteId(idCarrinho).Value;

            historicoCompras.ClienteId = ClienteId;

            return historicoCompras;
        }

        public Guid? BuscarClienteId(Guid idCarrinho)
        {
            var cn = Db.Database.Connection;
            var sql = @"SELECT ClienteId FROM CarrinhoCompras WHERE CarrinhoCompraId = @id";

            var buscar = cn.Query(sql, new {id = idCarrinho});

            foreach (var rows in buscar)
            {
                var campos = rows as IDictionary<string, object>;
                var clienteId = campos["ClienteId"];

                var clienteIdString = clienteId.ToString();
                var clienteIdGuid = Guid.Parse(clienteIdString);

                return clienteIdGuid;
            }

            return null;
        }

        public IEnumerable<dynamic> VerHistoricoPorCliente(Guid idCliente)
        {
            var cn = Db.Database.Connection;
            var sql = @"SELECT HistoricoComprasId FROM HistoricoCompras WHERE ClienteId = @id";

            var busca = cn.Query(sql, new {id = idCliente});

            return busca;
        }

        public ICollection<ItensCarrinhoHistorico> ItensHistoricoPeloClienteId(Guid idCliente)
        {
            var cn = Db.Database.Connection;
            var sql = @"SELECT ItensCarrinhoHistorico.NomeProduto ,SUM(ItensCarrinhoHistorico.Quantidade) AS Quantidade, SUM(ItensCarrinhoHistorico.ValorTotal) AS ValorTotal " +
                      "FROM ItensCarrinhoHistorico INNER JOIN HistoricoCompras ON ItensCarrinhoHistorico.HistoricoId = HistoricoCompras.HistoricoComprasId " +
                      "WHERE HistoricoCompras.ClienteId = @id GROUP BY ItensCarrinhoHistorico.NomeProduto"; 

            var busca = cn.Query<ItensCarrinhoHistorico>(sql, new {id = idCliente});

            var buscaList = busca.ToList();

            return buscaList;
        }
    }
}