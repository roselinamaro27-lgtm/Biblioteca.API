using Biblioteca.Domain.Entities;

namespace Biblioteca.Application.Interfaces
{
	public interface IAutorService
	{
		Task<IEnumerable<Autor>> ObtenerTodosAsync();
		Task<Autor?> ObtenerPorIdAsync(int id);
		Task CrearAsync(Autor autor);
		void Actualizar(Autor autor);
		void Eliminar(Autor autor);
	}
}