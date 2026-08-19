namespace Biblioteca.Domain.Entities;

public abstract class Persona
{
	public int Id { get; set; }

	public string Nombre { get; set; } = string.Empty;

	public string Apellido { get; set; } = string.Empty;

	// Constructor vacío
	protected Persona()
	{
	}

	// Constructor con parámetros
	protected Persona(string nombre, string apellido)
	{
		Nombre = nombre;
		Apellido = apellido;
	}

	public abstract string ObtenerTipo();
}