namespace Biblioteca.Domain.Entities;

public class Prestamo
{
	public int Id { get; set; }

	public int UsuarioId { get; set; }

	public DateTime FechaPrestamo { get; set; }

	public DateTime FechaVencimiento { get; set; }

	public DateTime? FechaDevolucion { get; set; }

	public string Estado { get; set; } = "Activo";

	public Usuario? Usuario { get; set; }

	// Constructor vacío
	public Prestamo()
	{
	}

	// Constructor con parámetros
	public Prestamo(
		int usuarioId,
		DateTime fechaPrestamo,
		DateTime fechaVencimiento)
	{
		UsuarioId = usuarioId;
		FechaPrestamo = fechaPrestamo;
		FechaVencimiento = fechaVencimiento;
		Estado = "Activo";
	}
}