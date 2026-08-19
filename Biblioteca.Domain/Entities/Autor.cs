namespace Biblioteca.Domain.Entities;

public class Autor
{
	public int Id { get; set; }

	public string Nombre { get; set; } = string.Empty;

	public string Apellido { get; set; } = string.Empty;

	public string Biografia { get; set; } = string.Empty;

	// Constructor vacío
	public Autor()
	{
	}

	// Constructor con parámetros
	public Autor(string nombre, string apellido, string biografia)
	{
		Nombre = nombre;
		Apellido = apellido;
		Biografia = biografia;
	}
}