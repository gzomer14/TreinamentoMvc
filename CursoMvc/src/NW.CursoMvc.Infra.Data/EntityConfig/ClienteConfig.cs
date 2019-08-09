using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using NW.CursoMvc.Domain.Entities;

namespace NW.CursoMvc.Infra.Data.EntityConfig
{
    // Fluent API

    public class ClienteConfig : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfig()
        {
            HasKey(c => c.ClienteId);
            /*HasKey(c => new {c.ClienteId, c.CPF}); 
            (Chave composta(Combinação de mais de uma chave)*/

            Property(c => c.Nome)
                .IsRequired()
                .HasColumnOrder(1)
                .HasMaxLength(150);

            Property(c => c.CPF)
                .IsRequired()
                .HasMaxLength(11)
                .IsFixedLength()
                .HasColumnAnnotation("Index", new IndexAnnotation(
                    new IndexAttribute() {IsUnique = true}));

            Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.DataNascimento)
                .IsRequired();

            Property(c => c.Ativo)
                .IsRequired();

            Ignore(c => c.ValidationResult);

            ToTable("Clientes");

        }
    }
}