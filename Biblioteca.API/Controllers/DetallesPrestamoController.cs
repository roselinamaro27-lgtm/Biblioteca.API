using Biblioteca.Domain.Entities;
using Biblioteca.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class DetallesPrestamoController : ControllerBase
	{
		private readonly BibliotecaDbContext _context;

		public DetallesPrestamoController(BibliotecaDbContext context)
		{
			_context = context;
		}

		// GET: api/DetallesPrestamo
		[HttpGet]
		public async Task<ActionResult<IEnumerable<DetallePrestamo>>> ObtenerDetalles()
		{
			var detalles = await _context.DetallesPrestamo.ToListAsync();

			return Ok(detalles);
		}

		// GET: api/DetallesPrestamo/5
		[HttpGet("{id}")]
		public async Task<ActionResult<DetallePrestamo>> ObtenerDetalle(int id)
		{
			var detalle = await _context.DetallesPrestamo
				.FirstOrDefaultAsync(d => d.Id == id);

			if (detalle == null)
			{
				return NotFound(new
				{
					mensaje = "El detalle del préstamo no fue encontrado."
				});
			}

			return Ok(detalle);
		}

		// POST: api/DetallesPrestamo
		[HttpPost]
		public async Task<ActionResult<DetallePrestamo>> CrearDetalle(
			DetallePrestamo detalle)
		{
			_context.DetallesPrestamo.Add(detalle);
			await _context.SaveChangesAsync();

			return CreatedAtAction(
				nameof(ObtenerDetalle),
				new { id = detalle.Id },
				detalle
			);
		}

		// PUT: api/DetallesPrestamo/5
		[HttpPut("{id}")]
		public async Task<IActionResult> ActualizarDetalle(
			int id,
			DetallePrestamo detalle)
		{
			if (id != detalle.Id)
			{
				return BadRequest(new
				{
					mensaje = "El ID de la URL no coincide con el ID del detalle."
				});
			}

			_context.Entry(detalle).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!await _context.DetallesPrestamo.AnyAsync(d => d.Id == id))
				{
					return NotFound(new
					{
						mensaje = "El detalle del préstamo no fue encontrado."
					});
				}

				throw;
			}

			return NoContent();
		}

		// DELETE: api/DetallesPrestamo/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> EliminarDetalle(int id)
		{
			var detalle = await _context.DetallesPrestamo.FindAsync(id);

			if (detalle == null)
			{
				return NotFound(new
				{
					mensaje = "El detalle del préstamo no fue encontrado."
				});
			}

			_context.DetallesPrestamo.Remove(detalle);
			await _context.SaveChangesAsync();

			return NoContent();
		}
	}
}