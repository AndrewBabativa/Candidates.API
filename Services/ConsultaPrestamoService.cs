using PruebaIngresoBibliotecario.Api.Interfaces;
using PruebaIngresoBibliotecario.Infrastructure;
using PruebaIngresoBibliotecario.Models;
using System;
using System.Linq;

namespace PruebaIngresoBibliotecario.Services
{
    /// <summary>
    /// Servicio de consulta de préstamos.
    /// </summary>
    public class ConsultarPrestamoService : IConsultarPrestamoService
    {
        private readonly PersistenceContext _context;

        /// <summary>
        /// Inicializa una nueva instancia del servicio de consulta de préstamos.
        /// </summary>
        /// <param name="context">El contexto de persistencia.</param>
        public ConsultarPrestamoService(PersistenceContext context)
        {
            _context = context;
        }

        public Prestamo ObtenerPrestamoPorId(int prestamoId)
        {
            return _context.Prestamos.FirstOrDefault(p => p.Id == prestamoId);
        }

        public Prestamo ObtenerPrestamoPorIsbn(Guid isbn)
        {
            return _context.Prestamos.FirstOrDefault(p => p.Isbn == isbn);
        }

        public bool TienePrestamoActivo(string identificacionUsuario)
        {
            return _context.Prestamos.Any(p => p.IdentificacionUsuario == identificacionUsuario);
        }

    }
}
