using Microsoft.EntityFrameworkCore;
using Programacion3Template.Models;

namespace Programacion3Template.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Token> Tokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de relaciones
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Token)
                .WithOne(t => t.Usuario)
                .HasForeignKey<Token>(t => t.UserId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
