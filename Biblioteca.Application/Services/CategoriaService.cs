using Biblioteca.Application.Interfaces;
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;

namespace Biblioteca.Application.Services
{
	public class CategoriaService : ICategoriaService
	{
		private readonly IRepository<Categoria> _repository;

		public CategoriaService(IRepository<Categoria> repository)
		{
			_repository = repository;
		}

		public List<Categoria> ObtenerTodos()
		{
			return _repository.ObtenerTodosAsync().Result.ToList();
		}

		public Categoria? ObtenerPorId(int id)
		{
			return _repository.ObtenerPorIdAsync(id).Result;
		}

		public void Crear(Categoria categoria)
		{
			_repository.AgregarAsync(categoria).Wait();
		}

		public void Actualizar(Categoria categoria)
		{
			_repository.Actualizar(categoria);
		}

		public void Eliminar(int id)
		{
			var categoria = ObtenerPorId(id);

			if (categoria != null)
			{
				_repository.Eliminar(categoria);
			}
		}
	}
}