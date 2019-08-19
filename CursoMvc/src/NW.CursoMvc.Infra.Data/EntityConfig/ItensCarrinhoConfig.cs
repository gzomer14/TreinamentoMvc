using System.Data.Entity.ModelConfiguration;
using NW.CursoMvc.Domain.Entities;

namespace NW.CursoMvc.Infra.Data.EntityConfig
{
    public class ItensCarrinhoConfig : EntityTypeConfiguration<ItensCarrinho>
    {
        public ItensCarrinhoConfig()
        {
            HasKey(i => i.ItensCarrinhoId);

            HasRequired(i => i.CarrinhoCompras)
                .WithMany(c => c.ItensCarrinho)
                .HasForeignKey(i => i.CarrinhoComprasId);

            ToTable("ItensCarrinho");
        }
    }
}