using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using paginas.Models;
using paginas.Data;

namespace paginas.Controllers
{
    [Route("api/personas")]
    [ApiController]
    public class PersonaClassesController : ControllerBase
    {
        public paginasContext _context;

        public PersonaClassesController(paginasContext context)
        {
            _context = context;
        }

        //// GET: api/PersonaClasses
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<PersonaClass>>> GetPersonaClass()
        //{
        //    return await _context.Tb_PersonasFisicas.ToListAsync();
        //}

        //regresar todas personas not async
        [HttpGet]
        public IEnumerable<PersonaClass> getPersonasAll()
        {
            var todasPersonas = _context.Tb_PersonasFisicas.ToList();
            return todasPersonas;
        }
        // GET: api/PersonaClasses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonaClass>> GetPersonaClass(int id)
        {
            var personaClass = await _context.Tb_PersonasFisicas.FindAsync(id);

            if (personaClass == null)
            {
                return NotFound();
            }

            return personaClass;
        }

        // PUT: api/PersonaClasses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonaClass(int id, PersonaClass personaClass)
        {
            if (id != personaClass.idPersonaFisica)
            {
                return BadRequest();
            }

            _context.Entry(personaClass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonaClassExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PersonaClasses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PersonaClass>> PostPersonaClass(PersonaClass personaClass)
        {
            _context.Tb_PersonasFisicas.Add(personaClass);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonaClass", new { id = personaClass.idPersonaFisica }, personaClass);
        }

        // DELETE: api/PersonaClasses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PersonaClass>> DeletePersonaClass(int id)
        {
            var personaClass = await _context.Tb_PersonasFisicas.FindAsync(id);
            if (personaClass == null)
            {
                return NotFound();
            }

            _context.Tb_PersonasFisicas.Remove(personaClass);
            await _context.SaveChangesAsync();

            return personaClass;
        }

        public bool PersonaClassExists(int id)
        {
            return _context.Tb_PersonasFisicas.Any(e => e.idPersonaFisica == id);
        }
    }
}
