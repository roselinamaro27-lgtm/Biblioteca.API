using Biblioteca.Domain.Entities;

namespace Biblioteca.Application.Interfaces
{
	public interface ICategoriaService
	{
		List<Categoria> ObtenerTodos();
		Categoria? ObtenerPorId(int id);
		void Crear(Categoria categoria);
		void Actualizar(Categoria categoria);
		void Eliminar(int id);
	}
}