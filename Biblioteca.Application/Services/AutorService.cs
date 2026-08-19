using Biblioteca.Application.Interfaces;
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;

namespace Biblioteca.Application.Services
{
	public class AutorService : IAutorService
	{
		private readonly IAutorRepository _repository;

		public AutorService(IAutorRepository repository)
		{
			_repository = repository;
		}

		public async Task<IEnumerable<Autor>> ObtenerTodosAsync()
		{
			return await _repository.ObtenerTodosAsync();
		}

		public async Task<Autor?> ObtenerPorIdAsync(int id)
		{
			return await _repository.ObtenerPorIdAsync(id);
		}

		public async Task CrearAsync(Autor autor)
		{
			await _repository.AgregarAsync(autor);
		}

		public void Actualizar(Autor autor)
		{
			_repository.Actualizar(autor);
		}

		public void Eliminar(Autor autor)
		{
			_repository.Eliminar(autor);
		}
	}
}