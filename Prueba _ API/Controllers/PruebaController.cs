using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prueba___API.Datos;
using Prueba___API.Modelos;
using Prueba___API.Modelos.Dto;

namespace Prueba___API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PruebaController : ControllerBase
    {
        private readonly ILogger<PruebaController> _logger;
        private readonly ApplicationDbcontext _db;
        public PruebaController(ILogger<PruebaController> logger, ApplicationDbcontext db)
        {
            _logger = logger;
            _db = db;
        }

        private object pruebaDto;
        private Prueba modelo;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<PruebaDto>> GetPruebas()
        {
            _logger.LogInformation("Obtener las Villas");
            return Ok(_db.Prueba.ToList());
        }



        [HttpGet("id:int", Name = "GetPrueba")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PruebaDto> GetPrueba(int id)
        {
            if (id == 0)
            {
                _logger.LogError("Error al traer Villa con Ide" + id);
                return BadRequest();
            }
            //var prueba = PruebaStore.PruebaList.FirstOrDefault(v => v.Id == id);
            var prueba = _db.Prueba.FirstOrDefault(v => v.Id == id);
            if (prueba == null)
            {
                return NotFound();
            }
            return Ok(prueba);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<PruebaDto> CrearPrueba([FromBody] PruebaDto pruebaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_db.Prueba.FirstOrDefault(v => v.Nombre.ToLower() == pruebaDto.Nombre.ToLower()) != null)
            {
                ModelState.AddModelError("NombreExiste", "La villa con ese nombre ya existe!");
                return BadRequest(ModelState);
            }

            if (pruebaDto == null)
            {
                return BadRequest(pruebaDto);
            }
            if (pruebaDto.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            Prueba modelo = new()
            {
                Nombre = pruebaDto.Nombre,
                Detalle = pruebaDto.Detalle,
                ImagenUrl = pruebaDto.ImagenUrl,
                Ocupantes = pruebaDto.Ocupantes,
                Tarifa = pruebaDto.Tarifa,
                MetrosCuadrados = pruebaDto.MetrosCuadrados,
                Amenidad = pruebaDto.Amenidad,
            };

            _db.Prueba.Add(modelo);
            _db.SaveChanges();

            return CreatedAtRoute("GetPrueba", new { id = pruebaDto.Id }, pruebaDto);
        }
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeletePrueba(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var prueba = _db.Prueba.FirstOrDefault(v => v.Id == id);
            if (prueba == null)
            {
                return NotFound();
            }
            _db.Prueba.Remove(prueba);
            _db.SaveChanges();

            return NoContent();
        }
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePrueba(int id, [FromBody] PruebaDto  pruebaDto)
        {
            if (pruebaDto == null || id != pruebaDto.Id)
            {
                return BadRequest();
            }
            //var prueba = PruebaStore.PruebaList.FirstOrDefault(v => v.Id == id);

            Prueba prueba = new()
            {
                Id = pruebaDto.Id,
                Nombre = pruebaDto.Nombre,
                Detalle = pruebaDto.Detalle,
                ImagenUrl = pruebaDto.ImagenUrl,
                Ocupantes = pruebaDto.Ocupantes,
                Tarifa = pruebaDto.Tarifa,
                MetrosCuadrados = pruebaDto.MetrosCuadrados,
                Amenidad = pruebaDto.Amenidad
            };
            _db.Prueba.Update(prueba);
            _db.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult UpdatePartialPrueba(int id, JsonPatchDocument<PruebaDto> patchDto)
        {
            if (patchDto == null || id == 0)
            {
                return BadRequest();
            }
            var prueba = _db.Prueba.AsNoTracking().FirstOrDefault(v => v.Id == id);

            PruebaDto pruebaDto = new()
            {
                Id = prueba.Id,
                Nombre = prueba.Nombre,
                Detalle = prueba.Detalle,
                ImagenUrl = prueba.ImagenUrl,
                Ocupantes = prueba.Ocupantes,
                Tarifa = prueba.Tarifa,
                MetrosCuadrados = prueba.MetrosCuadrados,
                Amenidad = prueba.Amenidad
            };

            if (prueba == null) return BadRequest();
             
            patchDto.ApplyTo(pruebaDto, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Prueba modelo = new()
            {
                Id = pruebaDto.Id,
                Nombre = pruebaDto.Nombre,
                Detalle = pruebaDto.Detalle,
                ImagenUrl = pruebaDto.ImagenUrl,
                Ocupantes = pruebaDto.Ocupantes,
                Tarifa = pruebaDto.Tarifa,
                MetrosCuadrados = pruebaDto.MetrosCuadrados,
                Amenidad = pruebaDto.Amenidad
            };

            _db.Prueba.Update(modelo);
            _db.SaveChanges();
            return NoContent();
        }




    }
}