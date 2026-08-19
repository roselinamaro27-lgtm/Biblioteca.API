using Biblioteca.Application.Interfaces;
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;

namespace Biblioteca.Application.Services
{
	public class LibroService : ILibroService
	{
		private readonly ILibroRepository _repository;

		public LibroService(ILibroRepository repository)
		{
			_repository = repository;
		}

		public async Task<IEnumerable<Libro>> ObtenerTodosAsync()
		{
			return await _repository.ObtenerTodosAsync();
		}

		public async Task<Libro?> ObtenerPorIdAsync(int id)
		{
			return await _repository.ObtenerPorIdAsync(id);
		}

		public async Task CrearAsync(Libro libro)
		{
			await _repository.AgregarAsync(libro);
		}

		public void Actualizar(Libro libro)
		{
			_repository.Actualizar(libro);
		}

		public void Eliminar(Libro libro)
		{
			_repository.Eliminar(libro);
		}
	}
}