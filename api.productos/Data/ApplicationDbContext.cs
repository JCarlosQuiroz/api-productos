using Microsoft.EntityFrameworkCore;
using Api.Productos.Models;

namespace Api.Productos.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Producto> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Data Seeding
            modelBuilder.Entity<Producto>().HasData(
                new Producto { Id = 1, Nombre = "Producto A", Precio = 10.5m, CantidadEnStock = 100, FechaDeCreacion = DateTime.Now },
                new Producto { Id = 2, Nombre = "Producto B", Precio = 15.75m, CantidadEnStock = 50, FechaDeCreacion = DateTime.Now }
            );
        }
    }
}