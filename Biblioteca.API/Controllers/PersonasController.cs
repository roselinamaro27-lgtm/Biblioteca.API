using Biblioteca.Domain.Entities;
using Biblioteca.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class PersonasController : ControllerBase
	{
		private readonly BibliotecaDbContext _context;

		public PersonasController(BibliotecaDbContext context)
		{
			_context = context;
		}

		// GET: api/Personas
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Persona>>> ObtenerPersonas()
		{
			var personas = await _context.Personas.ToListAsync();

			return Ok(personas);
		}

		// GET: api/Personas/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Persona>> ObtenerPersona(int id)
		{
			var persona = await _context.Personas
				.FirstOrDefaultAsync(p => p.Id == id);

			if (persona == null)
			{
				return NotFound(new
				{
					mensaje = "La persona no fue encontrada."
				});
			}

			return Ok(persona);
		}

		// POST: api/Personas
		[HttpPost]
		public async Task<ActionResult<Persona>> CrearPersona(Persona persona)
		{
			_context.Personas.Add(persona);
			await _context.SaveChangesAsync();

			return CreatedAtAction(
				nameof(ObtenerPersona),
				new { id = persona.Id },
				persona
			);
		}

		// PUT: api/Personas/5
		[HttpPut("{id}")]
		public async Task<IActionResult> ActualizarPersona(
			int id,
			Persona persona)
		{
			if (id != persona.Id)
			{
				return BadRequest(new
				{
					mensaje = "El ID de la URL no coincide con el ID de la persona."
				});
			}

			_context.Entry(persona).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!await _context.Personas.AnyAsync(p => p.Id == id))
				{
					return NotFound(new
					{
						mensaje = "La persona no fue encontrada."
					});
				}

				throw;
			}

			return NoContent();
		}

		// DELETE: api/Personas/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> EliminarPersona(int id)
		{
			var persona = await _context.Personas.FindAsync(id);

			if (persona == null)
			{
				return NotFound(new
				{
					mensaje = "La persona no fue encontrada."
				});
			}

			_context.Personas.Remove(persona);
			await _context.SaveChangesAsync();

			return NoContent();
		}
	}
}