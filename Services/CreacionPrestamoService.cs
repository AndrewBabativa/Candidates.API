using PruebaIngresoBibliotecario.Api.Interfaces;
using PruebaIngresoBibliotecario.Api.Utilities;
using PruebaIngresoBibliotecario.Infrastructure;
using PruebaIngresoBibliotecario.Models;
using PruebaIngresoBibliotecario.Models.Enums;
using System;
using PruebaIngresoBibliotecario.Api.Utilities;

namespace PruebaIngresoBibliotecario.Services
{
    /// <summary>
    /// Servicio para crear préstamos y verificar si un usuario tiene un préstamo activo.
    /// </summary>
    public class CreacionPrestamoService : ICreacionPrestamoService
    {
        private readonly PersistenceContext _context;

        /// <summary>
        /// Inicializa una nueva instancia de la clase CreacionPrestamoService.
        /// </summary>
        /// <param name="context">El contexto de persistencia.</param>
        public CreacionPrestamoService(PersistenceContext context)
        {
            _context = context;
        }

        public Prestamo CrearPrestamo(Prestamo request)
        {
            if (!Enum.IsDefined(typeof(TipoUsuarioPrestamo), request.TipoUsuario))
            {
                throw new InvalidOperationException("El campo tipoUsuario debe ser un valor válido (1, 2 o 3)");
            }

            var nuevoPrestamo = new Prestamo
            {
                Isbn = request.Isbn,
                IdentificacionUsuario = request.IdentificacionUsuario,
                TipoUsuario = request.TipoUsuario,
                FechaMaximaDevolucion = PrestamoUtility.CalcularFechaEntrega(request.TipoUsuario)
            };

            _context.Prestamos.Add(nuevoPrestamo);
            _context.SaveChanges();

            return nuevoPrestamo;
        }

    }
}
