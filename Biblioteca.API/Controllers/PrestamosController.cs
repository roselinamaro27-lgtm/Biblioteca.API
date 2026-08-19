using Biblioteca.Domain.Entities;
using Biblioteca.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class PrestamosController : ControllerBase
	{
		private readonly BibliotecaDbContext _context;

		public PrestamosController(BibliotecaDbContext context)
		{
			_context = context;
		}

		// GET: api/Prestamos
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Prestamo>>> ObtenerPrestamos()
		{
			var prestamos = await _context.Prestamos
				.Include(p => p.Usuario)
				.ToListAsync();

			return Ok(prestamos);
		}

		// GET: api/Prestamos/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Prestamo>> ObtenerPrestamo(int id)
		{
			var prestamo = await _context.Prestamos
				.Include(p => p.Usuario)
				.FirstOrDefaultAsync(p => p.Id == id);

			if (prestamo == null)
			{
				return NotFound(new
				{
					mensaje = "El préstamo no fue encontrado."
				});
			}

			return Ok(prestamo);
		}

		// POST: api/Prestamos
		[HttpPost]
		public async Task<ActionResult<Prestamo>> CrearPrestamo(Prestamo prestamo)
		{
			_context.Prestamos.Add(prestamo);
			await _context.SaveChangesAsync();

			return CreatedAtAction(
				nameof(ObtenerPrestamo),
				new { id = prestamo.Id },
				prestamo
			);
		}

		// PUT: api/Prestamos/5
		[HttpPut("{id}")]
		public async Task<IActionResult> ActualizarPrestamo(
			int id,
			Prestamo prestamo)
		{
			if (id != prestamo.Id)
			{
				return BadRequest(new
				{
					mensaje = "El ID de la URL no coincide con el ID del préstamo."
				});
			}

			_context.Entry(prestamo).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!await _context.Prestamos.AnyAsync(p => p.Id == id))
				{
					return NotFound(new
					{
						mensaje = "El préstamo no fue encontrado."
					});
				}

				throw;
			}

			return NoContent();
		}

		// DELETE: api/Prestamos/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> EliminarPrestamo(int id)
		{
			var prestamo = await _context.Prestamos.FindAsync(id);

			if (prestamo == null)
			{
				return NotFound(new
				{
					mensaje = "El préstamo no fue encontrado."
				});
			}

			_context.Prestamos.Remove(prestamo);
			await _context.SaveChangesAsync();

			return NoContent();
		}
	}
}