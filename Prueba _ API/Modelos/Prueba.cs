﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prueba___API.Modelos
{
    public class Prueba
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string Detalle { get; set; }

        [Required]
        public double Tarifa { get; set; }

        public int Ocupantes { get; set; }

        public int MetrosCuadrados { get; set; }

        public string ImagenUrl { get; set; }


        public string Amenidad { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaActualizacion { get; set; }
       

       
    }

}
