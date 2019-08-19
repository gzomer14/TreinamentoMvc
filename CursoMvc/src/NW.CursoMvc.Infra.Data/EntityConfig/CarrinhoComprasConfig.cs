using System.Data.Entity.ModelConfiguration;
using NW.CursoMvc.Domain.Entities;

namespace NW.CursoMvc.Infra.Data.EntityConfig
{
    public class CarrinhoComprasConfig : EntityTypeConfiguration<CarrinhoCompras>
    {
        public CarrinhoComprasConfig()
        {
            HasKey(c => c.CarrinhoCompraId);
                

            ToTable("CarrinhoCompras");
        }
    }
}