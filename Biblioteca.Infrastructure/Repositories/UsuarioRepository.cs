using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infrastructure.Repositories
{
	public class UsuarioRepository : IUsuarioRepository
	{
		private readonly BibliotecaDbContext _context;

		public UsuarioRepository(BibliotecaDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Usuario>> ObtenerTodosAsync()
		{
			return await _context.Usuarios.ToListAsync();
		}

		public async Task<Usuario?> ObtenerPorIdAsync(int id)
		{
			return await _context.Usuarios.FindAsync(id);
		}

		public async Task AgregarAsync(Usuario usuario)
		{
			await _context.Usuarios.AddAsync(usuario);
			await _context.SaveChangesAsync();
		}

		public void Actualizar(Usuario usuario)
		{
			_context.Usuarios.Update(usuario);
			_context.SaveChanges();
		}

		public void Eliminar(Usuario usuario)
		{
			_context.Usuarios.Remove(usuario);
			_context.SaveChanges();
		}
	}
}