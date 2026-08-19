using Biblioteca.Domain.Entities;

namespace Biblioteca.Application.Interfaces
{
	public interface IPrestamoService
	{
		Task<IEnumerable<Prestamo>> ObtenerTodosAsync();
		Task<Prestamo?> ObtenerPorIdAsync(int id);
		Task CrearAsync(Prestamo prestamo);
		void Actualizar(Prestamo prestamo);
		void Eliminar(Prestamo prestamo);
	}
}