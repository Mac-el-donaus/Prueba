using AutoMapper;
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
        private readonly IMapper _mapper;
        public PruebaController(ILogger<PruebaController> logger, ApplicationDbcontext db, IMapper mapper)
        {
            _logger = logger;
            _db = db;
            _mapper = mapper;
        }

        private object pruebaDto;
        private Prueba modelo;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PruebaDto>>> GetPruebasAsync()
        {
            _logger.LogInformation("Obtener las Villas");

            IEnumerable<Prueba> pruebalist = await _db.Prueba.ToListAsync();

            return Ok(_mapper.Map<IEnumerable<PruebaDto >> (pruebalist));
        }



        [HttpGet("id:int", Name = "GetPrueba")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PruebaDto>> GetPrueba(int id)
        {
            if (id == 0)
            {
                _logger.LogError("Error al traer Villa con Ide" + id);
                return BadRequest();
            }
            //var prueba = PruebaStore.PruebaList.FirstOrDefault(v => v.Id == id);
            var prueba = await _db.Prueba.FirstOrDefaultAsync(v => v.Id == id);
            if (prueba == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<PruebaDto>(prueba));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PruebaDto>> CrearPrueba([FromBody] PruebaCreateDto createDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _db.Prueba.FirstOrDefaultAsync(v=>v.Nombre.ToLower() == createDto.Nombre.ToLower()) != null)
            {
                ModelState.AddModelError("NombreExiste", "La villa con ese nombre ya existe!");
                return BadRequest(ModelState);
            }

            if (createDto == null)
            {
                return BadRequest(createDto);
            }

            Prueba modelo = _mapper.Map<Prueba>(createDto);

            await _db.Prueba.AddAsync(modelo);
            await _db.SaveChangesAsync();

            return CreatedAtRoute("GetPrueba", new { id = modelo.Id }, modelo);
        }
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePrueba(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var prueba =await _db.Prueba.FirstOrDefaultAsync(v => v.Id == id);
            if (prueba == null)
            {
                return NotFound();
            }
            _db.Prueba.Remove(prueba);
            await _db.SaveChangesAsync();

            return NoContent();
        }
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePrueba(int id, [FromBody] PruebaUpdateDto  updateDto)
        {
            if (updateDto == null || id != updateDto.Id)
            {
                return BadRequest();
            }
            //var prueba = PruebaStore.PruebaList.FirstOrDefault(v => v.Id == id);

            Prueba modelo = _mapper.Map<Prueba>(updateDto);

            
            _db.Prueba.Update(modelo);
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> UpdatePartialPrueba(int id, JsonPatchDocument<PruebaUpdateDto> patchDto)
        {
            if (patchDto == null || id == 0)
            {
                return BadRequest();
            }
            var prueba =await _db.Prueba.AsNoTracking().FirstOrDefaultAsync(v => v.Id == id);

            PruebaUpdateDto pruebaDto = _mapper.Map<PruebaUpdateDto>(prueba);

           
            if (prueba == null) return BadRequest();
             
            patchDto.ApplyTo(pruebaDto, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Prueba modelo = _mapper.Map<Prueba>(pruebaDto);

          

            _db.Prueba.Update(modelo);
            await _db.SaveChangesAsync();
            return NoContent();
        }




    }
}