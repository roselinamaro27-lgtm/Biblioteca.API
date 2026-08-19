using Biblioteca.Domain.Entities;

namespace Biblioteca.Application.Interfaces
{
	public interface ILibroService
	{
		Task<IEnumerable<Libro>> ObtenerTodosAsync();
		Task<Libro?> ObtenerPorIdAsync(int id);
		Task CrearAsync(Libro libro);
		void Actualizar(Libro libro);
		void Eliminar(Libro libro);
	}
}