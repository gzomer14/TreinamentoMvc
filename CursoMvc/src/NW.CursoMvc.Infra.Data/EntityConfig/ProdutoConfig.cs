using System.Data.Entity.ModelConfiguration;
using NW.CursoMvc.Domain.Entities;

namespace NW.CursoMvc.Infra.Data.EntityConfig
{
    public class ProdutoConfig : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfig()
        {
            HasKey(p => p.ProdutoId);

            Property(p => p.nome)
                .IsRequired()
                .HasColumnOrder(1)
                .HasMaxLength(150);

            Property(p => p.descricao)
                .IsRequired();

            Property(p => p.peso)
                .IsRequired();

            Property(p => p.valor)
                .IsRequired();

            HasRequired(p => p.Fornecedor)
                 .WithMany(f => f.Produtos)
                 .HasForeignKey(p => p.FornecedorId);

            ToTable("Produto");
        }
    }
}