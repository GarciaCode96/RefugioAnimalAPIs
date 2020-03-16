using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIFake.Data;
using APIFake.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIFake.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly RefugioDbContext _context;

        public AnimalController(RefugioDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<AnimalModel>>> Get()
        {
            return await _context.Animal.Select(animal => new AnimalModel
            {
                Id = animal.Id,
                Nombre = animal.Nombre,
                Fecha_Nacimiento = animal.Fecha_Nacimiento
            }).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AnimalModel>> Get(int id)
        {
            AnimalEntity Animal = await _context.Animal.FindAsync(id);

            if(Animal == null)
            {
                return NotFound("No se encontró el animal");
            }

            return new AnimalModel {
                Id = Animal.Id,
                Nombre = Animal.Nombre,
                Fecha_Nacimiento = Animal.Fecha_Nacimiento
            };
        }

        [HttpPost]
        public async Task<ActionResult> Post(AnimalCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("El model no es válido");
            }

            _context.Add(new AnimalEntity
            {
                Nombre = model.Nombre,
                Fecha_Nacimiento = model.Fecha_Nacimiento
            });
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            AnimalEntity Animal = await _context.Animal.FindAsync(id);
            
            if(Animal == null) 
            {
                return NotFound("El animal no existe");
            }

            _context.Animal.Remove(Animal);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
