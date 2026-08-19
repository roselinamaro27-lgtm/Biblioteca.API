namespace Biblioteca.Domain.Entities;

public class Categoria
{
	public int Id { get; set; }

	public string Nombre { get; set; } = string.Empty;

	public string Descripcion { get; set; } = string.Empty;

	// Constructor vacío
	public Categoria()
	{
	}

	// Constructor con parámetros
	public Categoria(string nombre, string descripcion)
	{
		Nombre = nombre;
		Descripcion = descripcion;
	}
}