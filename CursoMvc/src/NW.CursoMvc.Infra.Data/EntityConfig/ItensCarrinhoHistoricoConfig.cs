using System.Data.Entity.ModelConfiguration;
using NW.CursoMvc.Domain.Entities;

namespace NW.CursoMvc.Infra.Data.EntityConfig
{
    public class ItensCarrinhoHistoricoConfig : EntityTypeConfiguration<ItensCarrinhoHistorico>
    {
        public ItensCarrinhoHistoricoConfig()
        {
            HasKey(i => i.ItensCarrinhoHistoricoId);

            HasRequired(i => i.HistoricoCompras)
                .WithMany(h => h.ItensCarrinhoHistorico)
                .HasForeignKey(i => i.HistoricoId);

            ToTable("ItensCarrinhoHistorico");
        }
    }
}