using Biblioteca.Domain.Entities;
using Biblioteca.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class LibrosController : ControllerBase
	{
		private readonly BibliotecaDbContext _context;

		public LibrosController(BibliotecaDbContext context)
		{
			_context = context;
		}

		// GET: api/Libros
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Libro>>> ObtenerLibros()
		{
			var libros = await _context.Libros
				.Include(l => l.Autor)
				.Include(l => l.Categoria)
				.ToListAsync();

			return Ok(libros);
		}

		// GET: api/Libros/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Libro>> ObtenerLibro(int id)
		{
			var libro = await _context.Libros
				.Include(l => l.Autor)
				.Include(l => l.Categoria)
				.FirstOrDefaultAsync(l => l.Id == id);

			if (libro == null)
			{
				return NotFound(new
				{
					mensaje = "El libro no fue encontrado."
				});
			}

			return Ok(libro);
		}

		// POST: api/Libros
		[HttpPost]
		public async Task<ActionResult<Libro>> CrearLibro(Libro libro)
		{
			_context.Libros.Add(libro);
			await _context.SaveChangesAsync();

			return CreatedAtAction(
				nameof(ObtenerLibro),
				new { id = libro.Id },
				libro
			);
		}

		// PUT: api/Libros/5
		[HttpPut("{id}")]
		public async Task<IActionResult> ActualizarLibro(int id, Libro libro)
		{
			if (id != libro.Id)
			{
				return BadRequest(new
				{
					mensaje = "El ID de la URL no coincide con el ID del libro."
				});
			}

			_context.Entry(libro).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!await _context.Libros.AnyAsync(l => l.Id == id))
				{
					return NotFound(new
					{
						mensaje = "El libro no fue encontrado."
					});
				}

				throw;
			}

			return NoContent();
		}

		// DELETE: api/Libros/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> EliminarLibro(int id)
		{
			var libro = await _context.Libros.FindAsync(id);

			if (libro == null)
			{
				return NotFound(new
				{
					mensaje = "El libro no fue encontrado."
				});
			}

			_context.Libros.Remove(libro);
			await _context.SaveChangesAsync();

			return NoContent();
		}
	}
}