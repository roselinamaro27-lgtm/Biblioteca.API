using Biblioteca.Application.Interfaces;
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;

namespace Biblioteca.Application.Services
{
	public class PrestamoService : IPrestamoService
	{
		private readonly IPrestamoRepository _repository;

		public PrestamoService(IPrestamoRepository repository)
		{
			_repository = repository;
		}

		public async Task<IEnumerable<Prestamo>> ObtenerTodosAsync()
		{
			return await _repository.ObtenerTodosAsync();
		}

		public async Task<Prestamo?> ObtenerPorIdAsync(int id)
		{
			return await _repository.ObtenerPorIdAsync(id);
		}

		public async Task CrearAsync(Prestamo prestamo)
		{
			await _repository.AgregarAsync(prestamo);
		}

		public void Actualizar(Prestamo prestamo)
		{
			_repository.Actualizar(prestamo);
		}

		public void Eliminar(Prestamo prestamo)
		{
			_repository.Eliminar(prestamo);
		}
	}
}