namespace Biblioteca.Domain.Entities;

public class Libro
{
	public int Id { get; set; }

	public string ISBN { get; set; } = string.Empty;

	public string Titulo { get; set; } = string.Empty;

	public string Descripcion { get; set; } = string.Empty;

	public int AnioPublicacion { get; set; }

	public int CantidadTotal { get; set; }

	public int CantidadDisponible { get; set; }

	public int AutorId { get; set; }

	public int CategoriaId { get; set; }

	public Autor? Autor { get; set; }

	public Categoria? Categoria { get; set; }

	// Constructor vacío
	public Libro()
	{
	}

	// Constructor completo
	public Libro(
		string isbn,
		string titulo,
		string descripcion,
		int anioPublicacion,
		int cantidadTotal,
		int autorId,
		int categoriaId)
	{
		ISBN = isbn;
		Titulo = titulo;
		Descripcion = descripcion;
		AnioPublicacion = anioPublicacion;
		CantidadTotal = cantidadTotal;
		CantidadDisponible = cantidadTotal;
		AutorId = autorId;
		CategoriaId = categoriaId;
	}
}