using Biblioteca.Domain.Entities;
using Biblioteca.Infrastructure.Data;
using Biblioteca.Domain.Entities;
using Biblioteca.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UsuariosController : ControllerBase
	{
		private readonly BibliotecaDbContext _context;

		public UsuariosController(BibliotecaDbContext context)
		{
			_context = context;
		}

		// GET: api/Usuarios
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Usuario>>> ObtenerUsuarios()
		{
			var usuarios = await _context.Usuarios.ToListAsync();

			return Ok(usuarios);
		}

		// GET: api/Usuarios/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Usuario>> ObtenerUsuario(int id)
		{
			var usuario = await _context.Usuarios
				.FirstOrDefaultAsync(u => u.Id == id);

			if (usuario == null)
			{
				return NotFound(new
				{
					mensaje = "El usuario no fue encontrado."
				});
			}

			return Ok(usuario);
		}

		// POST: api/Usuarios
		[HttpPost]
		public async Task<ActionResult<Usuario>> CrearUsuario(Usuario usuario)
		{
			_context.Usuarios.Add(usuario);
			await _context.SaveChangesAsync();

			return CreatedAtAction(
				nameof(ObtenerUsuario),
				new { id = usuario.Id },
				usuario
			);
		}

		// PUT: api/Usuarios/5
		[HttpPut("{id}")]
		public async Task<IActionResult> ActualizarUsuario(
			int id,
			Usuario usuario)
		{
			if (id != usuario.Id)
			{
				return BadRequest(new
				{
					mensaje = "El ID de la URL no coincide con el ID del usuario."
				});
			}

			_context.Entry(usuario).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!await _context.Usuarios.AnyAsync(u => u.Id == id))
				{
					return NotFound(new
					{
						mensaje = "El usuario no fue encontrado."
					});
				}

				throw;
			}

			return NoContent();
		}

		// DELETE: api/Usuarios/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> EliminarUsuario(int id)
		{
			var usuario = await _context.Usuarios.FindAsync(id);

			if (usuario == null)
			{
				return NotFound(new
				{
					mensaje = "El usuario no fue encontrado."
				});
			}

			_context.Usuarios.Remove(usuario);
			await _context.SaveChangesAsync();

			return NoContent();
		}
	}
}