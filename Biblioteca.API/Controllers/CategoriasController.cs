using Biblioteca.Domain.Entities;
using Biblioteca.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CategoriasController : ControllerBase
	{
		private readonly BibliotecaDbContext _context;

		public CategoriasController(BibliotecaDbContext context)
		{
			_context = context;
		}

		// GET: api/Categorias
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Categoria>>> ObtenerCategorias()
		{
			var categorias = await _context.Categorias.ToListAsync();

			return Ok(categorias);
		}

		// GET: api/Categorias/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Categoria>> ObtenerCategoria(int id)
		{
			var categoria = await _context.Categorias.FindAsync(id);

			if (categoria == null)
			{
				return NotFound(new
				{
					mensaje = "La categoría no fue encontrada."
				});
			}

			return Ok(categoria);
		}

		// POST: api/Categorias
		[HttpPost]
		public async Task<ActionResult<Categoria>> CrearCategoria(Categoria categoria)
		{
			_context.Categorias.Add(categoria);
			await _context.SaveChangesAsync();

			return CreatedAtAction(
				nameof(ObtenerCategoria),
				new { id = categoria.Id },
				categoria
			);
		}

		// PUT: api/Categorias/5
		[HttpPut("{id}")]
		public async Task<IActionResult> ActualizarCategoria(
			int id,
			Categoria categoria)
		{
			if (id != categoria.Id)
			{
				return BadRequest(new
				{
					mensaje = "El ID de la URL no coincide con el ID de la categoría."
				});
			}

			_context.Entry(categoria).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!await _context.Categorias.AnyAsync(c => c.Id == id))
				{
					return NotFound(new
					{
						mensaje = "La categoría no fue encontrada."
					});
				}

				throw;
			}

			return NoContent();
		}

		// DELETE: api/Categorias/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> EliminarCategoria(int id)
		{
			var categoria = await _context.Categorias.FindAsync(id);

			if (categoria == null)
			{
				return NotFound(new
				{
					mensaje = "La categoría no fue encontrada."
				});
			}

			_context.Categorias.Remove(categoria);
			await _context.SaveChangesAsync();

			return NoContent();
		}
	}
}