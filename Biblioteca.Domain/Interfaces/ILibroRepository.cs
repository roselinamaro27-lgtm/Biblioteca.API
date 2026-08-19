using Biblioteca.Domain.Entities;

namespace Biblioteca.Domain.Interfaces;

public interface ILibroRepository : IRepository<Libro>
{
	Task<IEnumerable<Libro>> BuscarPorTituloAsync(string titulo);

	Task<IEnumerable<Libro>> BuscarPorAutorAsync(int autorId);

	Task<IEnumerable<Libro>> ObtenerDisponiblesAsync();
}