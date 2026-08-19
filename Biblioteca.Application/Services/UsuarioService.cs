using Biblioteca.Application.Interfaces;
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;

namespace Biblioteca.Application.Services
{
	public class UsuarioService : IUsuarioService
	{
		private readonly IUsuarioRepository _repository;

		public UsuarioService(IUsuarioRepository repository)
		{
			_repository = repository;
		}

		public async Task<IEnumerable<Usuario>> ObtenerTodosAsync()
		{
			return await _repository.ObtenerTodosAsync();
		}

		public async Task<Usuario?> ObtenerPorIdAsync(int id)
		{
			return await _repository.ObtenerPorIdAsync(id);
		}

		public async Task CrearAsync(Usuario usuario)
		{
			await _repository.AgregarAsync(usuario);
		}

		public void Actualizar(Usuario usuario)
		{
			_repository.Actualizar(usuario);
		}

		public void Eliminar(Usuario usuario)
		{
			_repository.Eliminar(usuario);
		}
	}
}