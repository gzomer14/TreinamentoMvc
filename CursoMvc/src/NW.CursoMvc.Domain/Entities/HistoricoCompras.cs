using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NW.CursoMvc.Domain.Entities
{
    public class HistoricoCompras
    {
        public HistoricoCompras()
        {
            HistoricoComprasId = Guid.NewGuid();
            ItensCarrinhoHistorico = new List<ItensCarrinhoHistorico>();
        }

        [Key]
        public Guid HistoricoComprasId { get; set; }

        public Guid ClienteId { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual ICollection<ItensCarrinhoHistorico> ItensCarrinhoHistorico { get; set; }
    }
}