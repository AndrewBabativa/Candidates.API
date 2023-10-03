using PruebaIngresoBibliotecario.Models;
using System;

namespace PruebaIngresoBibliotecario.Api.Interfaces
{
    /// <summary>
    /// Interfaz para servicios de consulta de préstamos de libros.
    /// </summary>
    public interface IConsultarPrestamoService
    {
        /// <summary>
        /// Obtiene información detallada sobre un préstamo de libro por su ID.
        /// </summary>
        /// <param name="prestamoId">ID del préstamo a consultar.</param>
        /// <returns>Información del préstamo o null si no se encuentra.</returns>
        Prestamo ObtenerPrestamoPorId(int prestamoId);

        /// <summary>
        /// Obtiene información detallada sobre un préstamo de libro por su ISBN.
        /// </summary>
        /// <param name="isbn">ISBN del préstamo a consultar.</param>
        /// <returns>Información del préstamo o null si no se encuentra.</returns>
        Prestamo ObtenerPrestamoPorIsbn(Guid isbn);

        /// <summary>
        /// Verifica si un usuario tiene un préstamo activo.
        /// </summary>
        /// <param name="identificacionUsuario">La identificación del usuario.</param>
        /// <returns>True si el usuario tiene un préstamo activo, de lo contrario, false.</returns>
        bool TienePrestamoActivo(string identificacionUsuario);


    }
}
