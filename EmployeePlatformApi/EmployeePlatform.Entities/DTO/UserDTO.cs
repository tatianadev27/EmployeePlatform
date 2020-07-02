using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeePlatform.Entities
{
    /// <summary>
    /// User Model
    /// </summary>
    public class UserDTO: BaseEntityDTO
    {
        /// <summary>
        /// User IdentificationNumber
        /// </summary>
        [Required]
        [StringLength(50, ErrorMessage = "El {0} no puede exceder {1} caracteres.")]
        public string IdentificationNumber { get; set; }

        /// <summary>
        /// User FullName
        /// </summary>
        [Required]
        [StringLength(150, ErrorMessage = "El {0} no puede exceder {1} caracteres.")]
        public string FirstName { get; set; }

        /// <summary>
        /// User LastName
        /// </summary>
        [Required]
        [StringLength(150, ErrorMessage = "El {0} no puede exceder {1} caracteres.")]
        public string LastName { get; set; }

        /// <summary>
        /// User Email
        /// </summary>
        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(100, ErrorMessage = "El {0} no puede exceder {1} caracteres.")]
        public string Email { get; set; }

        /// <summary>
        /// User password
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [StringLength(150, ErrorMessage = "El {0} no puede exceder {1} caracteres.")]
        public string Password { get; set; }

        /// <summary>
        /// User Role
        /// </summary>
        [Required]
        [StringLength(50, ErrorMessage = "El {0} no puede exceder {1} caracteres.")]
        public string Role { get; set; }
    }

    public class AuthenticateResponseDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public DateTime ExpiredToken { get; set; }
        public string Token { get; set; }
    }
}
