using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeePlatform.Database.Models
{
    /// <summary>
    /// Area Model
    /// </summary>
    public class Subarea: BaseEntity
    {
        /// <summary>
        /// Area Name
        /// </summary>
        [Required]
        [StringLength(150, ErrorMessage = "El {0} no puede exceder {1} caracteres.")]
        public string Name { get; set; }

        /// <summary>
        /// Area Entity Identificator
        /// </summary>
        [ForeignKey("Area")]
        [Required]
        public int AreaId { get; set; }
    }
}
