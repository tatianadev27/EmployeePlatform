using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeePlatform.Database.Models
{
    /// <summary>
    /// Employer Model
    /// </summary>
    public class Employee: BaseEntity
    {
        /// <summary>
        /// User IdentificationNumber
        /// </summary>
        [Required]
        [StringLength(50, ErrorMessage = "El {0} no puede exceder {1} caracteres.")]
        public string IdentificationNumber { get; set; }


        /// <summary>
        /// Identification Type Entity Identificator
        /// </summary>
        [ForeignKey("IdentificationType")]
        [Required]
        public int IdentificationTypeId { get; set; }

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
        /// Subarea Entity Identificator
        /// </summary>
        [ForeignKey("Subarea")]
        [Required]
        public int SubareaId { get; set; }
    }
}
