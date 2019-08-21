using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using NW.CursoMvc.Domain.Entities;

namespace NW.CursoMvc.Application.ViewModels
{
    public class HistoricoComprasViewModel
    {
        public HistoricoComprasViewModel()
        {
            HistoricoComprasId = Guid.NewGuid();
            ItensCarrinhoHistorico = new List<ItensCarrinhoHistorico>();
        }

        [Key]
        public Guid HistoricoComprasId { get; set; }

        [ScaffoldColumn(false)]
        public Guid ClienteId { get; set; }

        public virtual ICollection<ItensCarrinhoHistorico> ItensCarrinhoHistorico { get; set; }

    }
}