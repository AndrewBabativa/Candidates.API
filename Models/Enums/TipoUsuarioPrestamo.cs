namespace PruebaIngresoBibliotecario.Models.Enums
{
    /// <summary>
    /// Enumeración que representa los tipos de usuario para un préstamo en la biblioteca.
    /// </summary>
    public enum TipoUsuarioPrestamo
    {
        /// <summary>
        /// Afiliado a la biblioteca.
        /// </summary>
        Afiliado = 1,

        /// <summary>
        /// Empleado de la biblioteca.
        /// </summary>
        Empleado = 2,

        /// <summary>
        /// Invitado sin membresía.
        /// </summary>
        Invitado = 3
    }
}
