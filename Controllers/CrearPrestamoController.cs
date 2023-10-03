using Microsoft.AspNetCore.Mvc;
using PruebaIngresoBibliotecario.Api.Interfaces;
using PruebaIngresoBibliotecario.Models;
using System;

namespace PruebaIngresoBibliotecario.Api.Controllers
{
    /// <summary>
    /// Controlador para crear préstamos de libros.
    /// </summary>
    [Route("api/prestamo")]
    [ApiController]
    public class CrearPrestamoController : ControllerBase
    {
        private readonly ICreacionPrestamoService _creacionPrestamoService;
        private readonly IConsultarPrestamoService _consultaPrestamoService;

        /// <summary>
        /// Constructor del controlador.
        /// </summary>
        /// <param name="creacionPrestamoService">Servicio de creación de préstamos.</param>
        /// <param name="consultaPrestamoService">Servicio de consulta de préstamos.</param>
        public CrearPrestamoController(ICreacionPrestamoService creacionPrestamoService, IConsultarPrestamoService consultaPrestamoService)
        {
            _creacionPrestamoService = creacionPrestamoService;
            _consultaPrestamoService = consultaPrestamoService;
        }

        /// <summary>
        /// Crea un nuevo préstamo de libro.
        /// </summary>
        /// <param name="request">Datos del préstamo a crear.</param>
        /// <returns>Resultado de la operación.</returns>
        [HttpPost]
        public IActionResult CrearPrestamo([FromBody] Prestamo request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return CrearNuevoPrestamo(request);
        }

        private IActionResult CrearNuevoPrestamo(Prestamo request)
        {
            try
            {
                if (_consultaPrestamoService.TienePrestamoActivo(request.IdentificacionUsuario))
                {
                    return BadRequest(new
                    {
                        mensaje = $"El usuario con identificacion {request.IdentificacionUsuario} ya tiene un libro prestado por lo cual no se le puede realizar otro prestamo"
                    });
                }

                var nuevoPrestamo = _creacionPrestamoService.CrearPrestamo(request);

                return Ok(new
                {
                    id = nuevoPrestamo.Id.ToString(),
                    fechaMaximaDevolucion = nuevoPrestamo.FechaMaximaDevolucion.ToShortDateString()
                });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new
                {
                    mensaje = ex.Message
                });
            }
        }
    }
}
