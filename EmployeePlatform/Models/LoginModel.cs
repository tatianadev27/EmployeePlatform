using System.ComponentModel.DataAnnotations;

namespace EmployeePlatform.Models
{

    /// <summary>
    /// User Model
    /// </summary>
    public class UserLogin
    {
        /// <summary>
        /// User Email
        /// </summary>
        [DataType(DataType.EmailAddress, ErrorMessage = "Formato de email invalido")]
        [StringLength(100, ErrorMessage = "El {0} no puede exceder {1} caracteres.")]
        [Required(ErrorMessage = "Ingresar email.")]
        public string Email { get; set; }

        /// <summary>
        /// User password
        /// </summary>
        [DataType(DataType.Password)]
        [StringLength(150, ErrorMessage = "El {0} no puede exceder {1} caracteres.")]
        [Required(ErrorMessage = "Ingresar Contraseña.")]
        public string Password { get; set; }
    }
}
