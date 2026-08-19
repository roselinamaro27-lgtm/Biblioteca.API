using Biblioteca.Domain.Entities;
using Biblioteca.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AutoresController : ControllerBase
	{
		private readonly BibliotecaDbContext _context;

		public AutoresController(BibliotecaDbContext context)
		{
			_context = context;
		}

		// GET: api/Autores
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Autor>>> ObtenerAutores()
		{
			var autores = await _context.Autores.ToListAsync();

			return Ok(autores);
		}

		// GET: api/Autores/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Autor>> ObtenerAutor(int id)
		{
			var autor = await _context.Autores.FindAsync(id);

			if (autor == null)
			{
				return NotFound(new
				{
					mensaje = "El autor no fue encontrado."
				});
			}

			return Ok(autor);
		}

		// POST: api/Autores
		[HttpPost]
		public async Task<ActionResult<Autor>> CrearAutor(Autor autor)
		{
			_context.Autores.Add(autor);
			await _context.SaveChangesAsync();

			return CreatedAtAction(
				nameof(ObtenerAutor),
				new { id = autor.Id },
				autor
			);
		}

		// PUT: api/Autores/5
		[HttpPut("{id}")]
		public async Task<IActionResult> ActualizarAutor(int id, Autor autor)
		{
			if (id != autor.Id)
			{
				return BadRequest(new
				{
					mensaje = "El ID de la URL no coincide con el ID del autor."
				});
			}

			_context.Entry(autor).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!await _context.Autores.AnyAsync(a => a.Id == id))
				{
					return NotFound(new
					{
						mensaje = "El autor no fue encontrado."
					});
				}

				throw;
			}

			return NoContent();
		}

		// DELETE: api/Autores/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> EliminarAutor(int id)
		{
			var autor = await _context.Autores.FindAsync(id);

			if (autor == null)
			{
				return NotFound(new
				{
					mensaje = "El autor no fue encontrado."
				});
			}

			_context.Autores.Remove(autor);
			await _context.SaveChangesAsync();

			return NoContent();
		}
	}
}