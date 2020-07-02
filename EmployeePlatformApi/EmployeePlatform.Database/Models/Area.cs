using System.ComponentModel.DataAnnotations;

namespace EmployeePlatform.Database.Models
{
    /// <summary>
    /// Area Model
    /// </summary>
    public class Area : BaseEntity
    {
        /// <summary>
        /// Area Name
        /// </summary>
        [Required]
        [StringLength(150, ErrorMessage = "El {0} no puede exceder {1} caracteres.")]
        public string Name { get; set; }
    }
}
