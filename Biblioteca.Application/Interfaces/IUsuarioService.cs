using Biblioteca.Domain.Entities;

namespace Biblioteca.Application.Interfaces
{
	public interface IUsuarioService
	{
		Task<IEnumerable<Usuario>> ObtenerTodosAsync();
		Task<Usuario?> ObtenerPorIdAsync(int id);
		Task CrearAsync(Usuario usuario);
		void Actualizar(Usuario usuario);
		void Eliminar(Usuario usuario);
	}
}