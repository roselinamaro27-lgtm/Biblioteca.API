import "./App.css";
import { useEffect, useState } from "react";
import { obtenerLibros } from "./api";

interface Autor {
    id: number;
    nombre: string;
    apellido: string;
    biografia?: string;
}

interface Categoria {
    id: number;
    nombre: string;
    descripcion?: string;
}

interface Libro {
    id: number;
    isbn: string;
    titulo: string;
    descripcion: string;
    anioPublicacion: number;
    cantidadTotal: number;
    cantidadDisponible: number;
    autorId: number;
    categoriaId: number;
    autor?: Autor;
    categoria?: Categoria;
}

function App() {
    const [libros, setLibros] = useState<Libro[]>([]);
    const [librosFiltrados, setLibrosFiltrados] = useState<Libro[]>([]);
    const [libroSeleccionado, setLibroSeleccionado] = useState<Libro | null>(null);

    useEffect(() => {
        obtenerLibros()
            .then((datos) => {
                setLibros(datos);
                setLibrosFiltrados(datos);
            })
            .catch((error) => {
                console.error("Error al obtener los libros:", error);
            });
    }, []);

    const irA = (id: string) => {
        document.getElementById(id)?.scrollIntoView({
            behavior: "smooth",
        });
    };

    const mostrarTodosLosLibros = () => {
        setLibrosFiltrados(libros);
        irA("libros");
    };

    const filtrarPorCategoria = (categoria: string) => {
        const resultados = libros.filter(
            (libro) =>
                libro.categoria?.nombre?.toLowerCase() ===
                categoria.toLowerCase()
        );

        setLibrosFiltrados(resultados);
        irA("libros");
    };

    const iniciarSesion = () => {
        alert(
            "Inicio de sesión\n\nEsta función estará disponible próximamente."
        );
    };

    return (
        <div className="app">

            {/* ENCABEZADO */}
            <header className="header">

                <div className="logo">
                    📚 Biblioteca Digital
                </div>

                <nav className="nav">
                    <a href="#inicio">Inicio</a>
                    <a href="#libros">Libros</a>
                    <a href="#categorias">Categorías</a>
                    <a href="#contacto">Contacto</a>
                </nav>

                <button
                    type="button"
                    className="login-button"
                    onClick={iniciarSesion}
                >
                    Iniciar sesión
                </button>

            </header>

            <main>

                {/* INICIO */}
                <section id="inicio" className="hero">

                    <div className="hero-content">

                        <span className="hero-tag">
                            📖 BIBLIOTECA DIGITAL
                        </span>

                        <h1>
                            Descubre un mundo de
                            <span> conocimiento</span>
                        </h1>

                        <p>
                            Explora nuestra colección de libros, descubre nuevos
                            autores y encuentra el conocimiento que necesitas.
                        </p>

                        <div className="hero-buttons">

                            <button
                                type="button"
                                className="primary-button"
                                onClick={mostrarTodosLosLibros}
                            >
                                Explorar libros
                            </button>

                            <button
                                type="button"
                                className="secondary-button"
                                onClick={() => irA("categorias")}
                            >
                                Conocer más
                            </button>

                        </div>

                    </div>

                    <div className="hero-book">
                        <div className="book-icon">
                            📚
                        </div>
                    </div>

                </section>

                {/* CATEGORÍAS */}
                <section id="categorias" className="categories">

                    <div className="section-title">

                        <span>EXPLORA</span>

                        <h2>
                            Encuentra tu próxima lectura
                        </h2>

                        <p>
                            Explora nuestras principales categorías.
                        </p>

                    </div>

                    <div className="category-grid">

                        <div className="category-card">

                            <div className="category-icon">
                                📖
                            </div>

                            <h3>
                                Novelas
                            </h3>

                            <p>
                                Historias y aventuras para disfrutar.
                            </p>

                            <button
                                type="button"
                                onClick={() => filtrarPorCategoria("Novela")}
                            >
                                Ver libros →
                            </button>

                        </div>

                        <div className="category-card">

                            <div className="category-icon">
                                📚
                            </div>

                            <h3>
                                Historia
                            </h3>

                            <p>
                                Conoce acontecimientos que marcaron el mundo.
                            </p>

                            <button
                                type="button"
                                onClick={() => filtrarPorCategoria("Historia")}
                            >
                                Ver libros →
                            </button>

                        </div>

                        <div className="category-card">

                            <div className="category-icon">
                                🔬
                            </div>

                            <h3>
                                Ciencia
                            </h3>

                            <p>
                                Descubre los avances y conocimientos científicos.
                            </p>

                            <button
                                type="button"
                                onClick={() => filtrarPorCategoria("Ciencia")}
                            >
                                Ver libros →
                            </button>

                        </div>

                        <div className="category-card">

                            <div className="category-icon">
                                💻
                            </div>

                            <h3>
                                Tecnología
                            </h3>

                            <p>
                                Aprende sobre programación e innovación.
                            </p>

                            <button
                                type="button"
                                onClick={() => filtrarPorCategoria("Tecnología")}
                            >
                                Ver libros →
                            </button>

                        </div>

                        <div className="category-card">

                            <div className="category-icon">
                                🧒
                            </div>

                            <h3>
                                Infantil
                            </h3>

                            <p>
                                Lecturas divertidas para los más pequeños.
                            </p>

                            <button
                                type="button"
                                onClick={() => filtrarPorCategoria("Infantil")}
                            >
                                Ver libros →
                            </button>

                        </div>

                    </div>

                </section>

                {/* LIBROS */}
                <section id="libros" className="featured">

                    <div className="section-title">

                        <span>
                            DESTACADOS
                        </span>

                        <h2>
                            Libros recomendados
                        </h2>

                        <p>
                            Descubre algunos de los libros disponibles
                            en nuestra biblioteca.
                        </p>

                    </div>

                    <div className="books-grid">

                        {librosFiltrados.length > 0 ? (

                            librosFiltrados.map((libro) => (

                                <div
                                    className="book-card"
                                    key={libro.id}
                                >

                                    <div className="book-cover">
                                        📚
                                    </div>

                                    <div className="book-info">

                                        <span>
                                            {libro.categoria?.nombre ||
                                                "Biblioteca"}
                                        </span>

                                        <h3>
                                            {libro.titulo}
                                        </h3>

                                        <p>
                                            {libro.autor
                                                ? `${libro.autor.nombre} ${libro.autor.apellido}`
                                                : "Autor desconocido"}
                                        </p>

                                        <button
                                            type="button"
                                            onClick={() =>
                                                setLibroSeleccionado(libro)
                                            }
                                        >
                                            Ver detalles
                                        </button>

                                    </div>

                                </div>

                            ))

                        ) : (

                            <div>

                                <p>
                                    No hay libros disponibles en esta categoría.
                                </p>

                                <button
                                    type="button"
                                    onClick={mostrarTodosLosLibros}
                                >
                                    Ver todos los libros
                                </button>

                            </div>

                        )}

                    </div>

                </section>

                {/* AYUDA */}
                <section className="help">

                    <div>

                        <span>
                            ¿NECESITAS AYUDA?
                        </span>

                        <h2>
                            Estamos aquí para ayudarte
                        </h2>

                        <p>
                            Si tienes alguna pregunta sobre nuestros libros
                            o servicios, puedes comunicarte con nosotros.
                        </p>

                    </div>

                    <button
                        type="button"
                        onClick={() => irA("contacto")}
                    >
                        Contactar
                    </button>

                </section>

            </main>

            {/* FOOTER */}
            <footer id="contacto" className="footer">

                <div>

                    <h3>
                        📚 Biblioteca Digital
                    </h3>

                    <p>
                        Un espacio para aprender, descubrir y compartir conocimiento.
                    </p>

                </div>

                <div>

                    <h4>
                        Contacto
                    </h4>

                    <p>
                        📧 biblioteca@email.com
                    </p>

                    <p>
                        📞 +1 809-000-0000
                    </p>

                </div>

                <div>

                    <h4>
                        Enlaces
                    </h4>

                    <p
                        onClick={() => irA("inicio")}
                        style={{ cursor: "pointer" }}
                    >
                        Inicio
                    </p>

                    <p
                        onClick={mostrarTodosLosLibros}
                        style={{ cursor: "pointer" }}
                    >
                        Libros
                    </p>

                    <p
                        onClick={() => irA("categorias")}
                        style={{ cursor: "pointer" }}
                    >
                        Categorías
                    </p>

                </div>

                <div className="footer-bottom">
                    © 2026 Biblioteca Digital. Todos los derechos reservados.
                </div>

            </footer>

            {/* DETALLES DEL LIBRO */}
            {libroSeleccionado && (

                <div className="modal-overlay">

                    <div className="modal">

                        <button
                            type="button"
                            className="modal-close"
                            onClick={() => setLibroSeleccionado(null)}
                        >
                            ✕
                        </button>

                        <div className="book-cover">
                            📚
                        </div>

                        <h2>
                            {libroSeleccionado.titulo}
                        </h2>

                        <p>
                            <strong>Autor:</strong>{" "}
                            {libroSeleccionado.autor
                                ? `${libroSeleccionado.autor.nombre} ${libroSeleccionado.autor.apellido}`
                                : "Autor desconocido"}
                        </p>

                        <p>
                            <strong>Categoría:</strong>{" "}
                            {libroSeleccionado.categoria?.nombre ||
                                "Sin categoría"}
                        </p>

                        <p>
                            <strong>Año:</strong>{" "}
                            {libroSeleccionado.anioPublicacion}
                        </p>

                        <p>
                            <strong>ISBN:</strong>{" "}
                            {libroSeleccionado.isbn}
                        </p>

                        <p>
                            <strong>Descripción:</strong>{" "}
                            {libroSeleccionado.descripcion}
                        </p>

                        <p>
                            <strong>Disponibles:</strong>{" "}
                            {libroSeleccionado.cantidadDisponible}
                        </p>

                        <button
                            type="button"
                            className="primary-button"
                            onClick={() => setLibroSeleccionado(null)}
                        >
                            Cerrar
                        </button>

                    </div>

                </div>

            )}

        </div>
    );
}

export default App;