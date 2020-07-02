using System.ComponentModel.DataAnnotations;

namespace EmployeePlatform.Entities
{
    /// <summary>
    /// Area Model
    /// </summary>
    public class IdentificationTypeDTO: BaseEntityDTO
    {
        /// <summary>
        /// Area Name
        /// </summary>
        [Required]
        [StringLength(150, ErrorMessage = "El {0} no puede exceder {1} caracteres.")]
        public string Name { get; set; }
    }
}
