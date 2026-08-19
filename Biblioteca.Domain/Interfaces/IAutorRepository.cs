using Biblioteca.Domain.Entities;

namespace Biblioteca.Domain.Interfaces;

public interface IAutorRepository : IRepository<Autor>
{
	Task<IEnumerable<Autor>> BuscarPorNombreAsync(string nombre);
}