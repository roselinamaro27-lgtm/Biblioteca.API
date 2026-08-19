const API_URL = "https://localhost:7170/api";

export async function obtenerLibros() {
    const respuesta = await fetch(`${API_URL}/Libros`);

    if (!respuesta.ok) {
        throw new Error("No se pudieron obtener los libros.");
    }

    return await respuesta.json();
}