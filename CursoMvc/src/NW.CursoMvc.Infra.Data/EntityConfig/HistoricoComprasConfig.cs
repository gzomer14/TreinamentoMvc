using System.Data.Entity.ModelConfiguration;
using NW.CursoMvc.Domain.Entities;

namespace NW.CursoMvc.Infra.Data.EntityConfig
{
    public class HistoricoComprasConfig : EntityTypeConfiguration<HistoricoCompras>
    {
        public HistoricoComprasConfig()
        {
            HasKey(h => h.HistoricoComprasId);

            HasRequired(h => h.Cliente)
                .WithMany(c => c.HistoricoCompras)
                .HasForeignKey(h => h.ClienteId);

            ToTable("HistoricoCompras");
        }
    }
}