using PruebaIngresoBibliotecario.Models;

namespace PruebaIngresoBibliotecario.Api.Interfaces
{
    /// <summary>
    /// Interfaz para servicios de creación de préstamos de libros.
    /// </summary>
    public interface ICreacionPrestamoService
    {
        /// <summary>
        /// Crea un nuevo préstamo de libro según la solicitud proporcionada.
        /// </summary>
        /// <param name="request">Solicitud de préstamo.</param>
        /// <returns>El nuevo préstamo creado.</returns>
        Prestamo CrearPrestamo(Prestamo request);

    }
}
