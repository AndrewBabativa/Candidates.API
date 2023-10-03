using PruebaIngresoBibliotecario.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace PruebaIngresoBibliotecario.Models
{
    /// <summary>
    /// Representa un préstamo de libro en la biblioteca.
    /// </summary>
    public class Prestamo
    {
        /// <summary>
        /// Obtiene o establece el identificador único del préstamo.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el número ISBN del libro prestado.
        /// </summary>
        public Guid Isbn { get; set; }

        /// <summary>
        /// Obtiene o establece la identificación del usuario que realizó el préstamo.
        /// </summary>
        public string IdentificacionUsuario { get; set; }

        /// <summary>
        /// Obtiene o establece el tipo de usuario que realizó el préstamo.
        /// </summary>
        public TipoUsuarioPrestamo TipoUsuario { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha máxima de devolución del libro prestado.
        /// </summary>
        public DateTime FechaMaximaDevolucion { get; set; }
    }
}
