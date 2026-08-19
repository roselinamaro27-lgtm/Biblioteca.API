namespace Biblioteca.Domain.Entities;

public class DetallePrestamo
{
	public int Id { get; set; }

	public int PrestamoId { get; set; }

	public int LibroId { get; set; }

	public int Cantidad { get; set; }

	public Prestamo? Prestamo { get; set; }

	public Libro? Libro { get; set; }

	// Constructor vacío
	public DetallePrestamo()
	{
	}

	// Constructor con parámetros
	public DetallePrestamo(
		int prestamoId,
		int libroId,
		int cantidad)
	{
		PrestamoId = prestamoId;
		LibroId = libroId;
		Cantidad = cantidad;
	}
}