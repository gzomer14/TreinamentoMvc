using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using Dapper;
using NW.CursoMvc.Domain.Entities;
using NW.CursoMvc.Domain.Interfaces.Repository;
using NW.CursoMvc.Infra.Data.Context;

namespace NW.CursoMvc.Infra.Data.Repository
{
    public class CarrinhoComprasRepository : Repository<CarrinhoCompras>, ICarrinhoComprasRepository
    {
        public CarrinhoComprasRepository(CursoMvcContext context)
            : base(context)
        {

        }

        public Guid? CarrinhoPorClienteId(Guid idCliente)
        {
            var cn = Db.Database.Connection;
            var sql = @"SELECT CarrinhoCompraId FROM CarrinhoCompras WHERE ClienteId = @id";

            var busca = cn.Query(sql, new
            {
                id = idCliente
            });

            var buscaList = busca.ToList();

            bool isEmpty = !buscaList.Any();

            if (isEmpty)
            {
                return null;
            }

            string carrinhoId = string.Join("", buscaList[0].CarrinhoCompraId);

            Guid idCarrinho = Guid.Parse(carrinhoId);

            return idCarrinho;

        }

        public int Contador()
        {
            var cn = Db.Database.Connection;
            var sql = @"SELECT COUNT(SequencialNumber) AS 'Count'  FROM CarrinhoCompras";

            var busca = cn.Query(sql);

            foreach (var rows in busca)
            {
                var fields = rows as IDictionary<string, object>;
                var count = fields["Count"];

                var countString = count.ToString();

                var countInt = int.Parse(countString);

                return countInt;
            }

            return 1;
        }

        public void RemoverItens(Guid id)
        {
            var cn = Db.Database.Connection;
            var sql = @"SELECT ItensCarrinhoId FROM ItensCarrinho WHERE CarrinhoComprasId = @id";

            var busca = cn.Query(sql, new{id = id});

            foreach (var rows in busca)
            {
                var campos = rows as IDictionary<string, object>;
                var itensId = campos["ItensCarrinhoId"];

                var itensIdString = itensId.ToString();
                var itensIdGuid = Guid.Parse(itensIdString);

                Remover(itensIdGuid);
            }
        }

        public bool VerificarExistencia(Guid id)
        {
            return Buscar(c => c.ClienteId == id).Any();
        }

    }
}