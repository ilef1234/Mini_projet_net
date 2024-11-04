using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Mini_projet_net.Models
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Article> articles { get; set; }
        public DbSet<Categorie> categories { get; set; }
        public DbSet<Commande> Commandes { get; set; }
        public DbSet<Panier> PanierArts { get; set; }



    }
}
