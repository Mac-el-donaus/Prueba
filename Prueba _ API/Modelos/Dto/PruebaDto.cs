using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prueba___API.Modelos.Dto
{
    public class PruebaDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Nombre { get; set; }

        public string Detalle { get; set; }

        [Required]
        public double Tarifa { get; set; }

        public int Ocupantes { get; set; }
        public int MetrosCuadrados { get; set; }

       

        public string Amenidad { get; set; }
        public string ImagenUrl { get;  set; }

      
    }
}
