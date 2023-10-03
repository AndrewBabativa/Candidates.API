using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PruebaIngresoBibliotecario.Infrastructure;
using PruebaIngresoBibliotecario.Models;
using System;
using PruebaIngresoBibliotecario.Api.Interfaces;

namespace PruebaIngresoBibliotecario.Api.Controllers
{
    /// <summary>
    /// Controlador para consultar préstamos de libros.
    /// </summary>
    [Route("api/prestamo")]
    [ApiController]
    public class ConsultarPrestamoController : ControllerBase
    {
        private readonly IConsultarPrestamoService _prestamoService;

        public ConsultarPrestamoController(IConsultarPrestamoService prestamoService)
        {
            _prestamoService = prestamoService;
        }

        /// <summary>
        /// Obtiene información detallada sobre un préstamo de libro por su ID o ISBN.
        /// </summary>
        /// <param name="id">ID o ISBN del préstamo.</param>
        /// <returns>Información del préstamo o mensaje de error.</returns>
        [HttpGet("{id}")]
        public IActionResult ObtenerPrestamo(string id)
        {
            if (int.TryParse(id, out int prestamoId))
            {
                var prestamo = _prestamoService.ObtenerPrestamoPorId(prestamoId);

                if (prestamo == null)
                {
                    return NotFound(new
                    {
                        mensaje = $"Prestamo con Id {id} no encontrado"
                    });
                }

                return Ok(new
                {
                    isbn = prestamo.Isbn,
                    identificacionUsuario = prestamo.IdentificacionUsuario,
                    tipoUsuario = prestamo.TipoUsuario,
                    fechaMaximaDevolucion = prestamo.FechaMaximaDevolucion
                });
            }
            else
            {
                var prestamo = _prestamoService.ObtenerPrestamoPorIsbn(Guid.Parse(id));

                if (prestamo == null)
                {
                    return NotFound(new
                    {
                        mensaje = $"Prestamo con Guid {id} no encontrado"
                    });
                }

                return Ok(new
                {
                    isbn = prestamo.Isbn,
                    identificacionUsuario = prestamo.IdentificacionUsuario,
                    tipoUsuario = prestamo.TipoUsuario,
                    fechaMaximaDevolucion = prestamo.FechaMaximaDevolucion
                });
            }
        }
    }
}