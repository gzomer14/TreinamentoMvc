using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace NW.CursoMvc.UI.Site.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //public System.Data.Entity.DbSet<NW.CursoMvc.Domain.Entities.ItensCarrinhoHistorico> ItensCarrinhoHistoricoes { get; set; }

        //public System.Data.Entity.DbSet<NW.CursoMvc.Domain.Entities.Produto> Produtoes { get; set; }

        //public System.Data.Entity.DbSet<NW.CursoMvc.Domain.Entities.HistoricoCompras> HistoricoCompras { get; set; }

        //public System.Data.Entity.DbSet<NW.CursoMvc.Domain.Entities.Cliente> Clientes { get; set; }

        //public System.Data.Entity.DbSet<NW.CursoMvc.Domain.Entities.Produto> Produtoes { get; set; }

        //public System.Data.Entity.DbSet<NW.CursoMvc.Domain.Entities.CarrinhoCompras> CarrinhoCompras { get; set; }

        //public System.Data.Entity.DbSet<NW.CursoMvc.Domain.Entities.Cliente> Clientes { get; set; }

        //public System.Data.Entity.DbSet<NW.CursoMvc.Domain.Entities.CarrinhoCompras> CarrinhoCompras { get; set; }

        //public System.Data.Entity.DbSet<NW.CursoMvc.Domain.Entities.Cliente> Clientes { get; set; }

        //public System.Data.Entity.DbSet<NW.CursoMvc.Domain.Entities.ItensCarrinho> ItensCarrinhoes { get; set; }

        //public System.Data.Entity.DbSet<NW.CursoMvc.Domain.Entities.Produto> Produtoes { get; set; }

        //public System.Data.Entity.DbSet<NW.CursoMvc.Domain.Entities.CarrinhoCompras> CarrinhoCompras { get; set; }

        //public System.Data.Entity.DbSet<NW.CursoMvc.Domain.Entities.Cliente> Clientes { get; set; }

        //public System.Data.Entity.DbSet<NW.CursoMvc.Domain.Entities.Produto> Produtoes { get; set; }

        //public System.Data.Entity.DbSet<NW.CursoMvc.Domain.Entities.Fornecedor> Fornecedors { get; set; }

        //public System.Data.Entity.DbSet<NW.CursoMvc.Domain.Entities.Produto> Produtos { get; set; }

        //public System.Data.Entity.DbSet<NW.CursoMvc.Domain.Entities.Fornecedor> Fornecedors { get; set; }

        //public System.Data.Entity.DbSet<NW.CursoMvc.Application.ViewModels.FornecedorViewModel> FornecedorViewModels { get; set; }
    }
}