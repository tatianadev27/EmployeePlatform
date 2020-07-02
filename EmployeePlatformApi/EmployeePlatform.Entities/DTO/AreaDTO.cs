using System.ComponentModel.DataAnnotations;

namespace EmployeePlatform.Entities
{
    /// <summary>
    /// Area Model
    /// </summary>
    public class AreaDTO : BaseEntityDTO
    {
        /// <summary>
        /// Area Name
        /// </summary>
        [StringLength(150, ErrorMessage = "El {0} no puede exceder {1} caracteres.")]
        public string Name { get; set; }
    }
}
