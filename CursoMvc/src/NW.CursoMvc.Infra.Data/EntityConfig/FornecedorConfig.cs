using System.Data.Entity.ModelConfiguration;
using NW.CursoMvc.Domain.Entities;

namespace NW.CursoMvc.Infra.Data.EntityConfig
{
    public class FornecedorConfig : EntityTypeConfiguration<Fornecedor>
    {
        public FornecedorConfig()
        {
            HasKey(f => f.FornecedorId);

            Property(f => f.nome)
                .IsRequired()
                .HasColumnOrder(1)
                .HasMaxLength(150);

            Property(f => f.cpf)
                .IsRequired()
                .HasMaxLength(11)
                .IsFixedLength();

            Property(f => f.email)
                .IsRequired()
                .HasMaxLength(150);

            Property(f => f.dataNascimento)
                .IsRequired();

            Property(f => f.ativo)
                .IsRequired();

            ToTable("Fornecedor");
        }
    }
}