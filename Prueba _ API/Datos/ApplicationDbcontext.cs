using Microsoft.EntityFrameworkCore;
using Prueba___API.Modelos;
using Prueba___API.Modelos.Dto;

namespace Prueba___API.Datos
{
    public class ApplicationDbcontext : DbContext
    {

        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options) : base(options)
        {

        }
        public DbSet<Prueba> Prueba { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prueba>().HasData(
                new Prueba()
                {
                    Id = 1,
                    Nombre = "Villa Real",
                    Detalle = "Detalle de la Villa...",
                    ImagenUrl = "",
                    Ocupantes = 5,
                    MetrosCuadrados = 50,
                    Tarifa = 200,
                    Amenidad = "",
                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = DateTime.Now
                },

                 new Prueba()
                 {
                     Id = 2,
                     Nombre = "Premium Vista a la piscina",
                     Detalle = "Detalle de la Villa...",
                     ImagenUrl = "",
                     Ocupantes = 4,
                     MetrosCuadrados = 40,
                     Tarifa = 150,
                     Amenidad = "",
                     FechaCreacion = DateTime.Now,
                     FechaActualizacion = DateTime.Now
                 });
        }
    }
}
