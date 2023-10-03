using System;
using System.Linq;
using PruebaIngresoBibliotecario.Models.Enums;

namespace PruebaIngresoBibliotecario.Api.Utilities
{
    /// <summary>
    /// Clase de utilidad para calcular la fecha de entrega de un préstamo en función del tipo de usuario.
    /// </summary>
    public static class PrestamoUtility
    {
        /// <summary>
        /// Calcula la fecha de entrega para un préstamo basado en el tipo de usuario.
        /// </summary>
        /// <param name="tipoUsuario">El tipo de usuario del préstamo.</param>
        /// <returns>La fecha de entrega calculada.</returns>
        public static DateTime CalcularFechaEntrega(TipoUsuarioPrestamo tipoUsuario)
        {
            var weekend = new[] { DayOfWeek.Saturday, DayOfWeek.Sunday };
            var fechaDevolucion = DateTime.Now;

            int diasPrestamo = tipoUsuario switch
            {
                TipoUsuarioPrestamo.Afiliado => 10,
                TipoUsuarioPrestamo.Empleado => 8,
                TipoUsuarioPrestamo.Invitado => 7,
                _ => -1,
            };

            while (diasPrestamo > 0)
            {
                fechaDevolucion = fechaDevolucion.AddDays(1);
                if (!weekend.Contains(fechaDevolucion.DayOfWeek))
                {
                    diasPrestamo--;
                }
            }

            return fechaDevolucion;
        }
    }
}
