namespace Biblioteca.Domain.Entities;

public class Usuario : Persona
{
	public string Correo { get; set; } = string.Empty;

	public string PasswordHash { get; set; } = string.Empty;

	public string Rol { get; set; } = "Usuario";

	public bool Estado { get; set; } = true;

	public DateTime FechaRegistro { get; set; } = DateTime.Now;

	// Constructor vacío
	public Usuario()
	{
	}

	// Constructor con parámetros
	public Usuario(
		string nombre,
		string apellido,
		string correo,
		string passwordHash,
		string rol = "Usuario")
		: base(nombre, apellido)
	{
		Correo = correo;
		PasswordHash = passwordHash;
		Rol = rol;
		Estado = true;
		FechaRegistro = DateTime.Now;
	}

	public override string ObtenerTipo()
	{
		return Rol;
	}
}