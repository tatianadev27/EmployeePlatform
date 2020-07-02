using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeePlatform.Entities
{
    /// <summary>
    /// Area Model
    /// </summary>
    public class SubareaDTO: BaseEntityDTO
    {
        /// <summary>
        /// Area Name
        /// </summary>
        [StringLength(150, ErrorMessage = "El {0} no puede exceder {1} caracteres.")]
        public string Name { get; set; }

        /// <summary>
        /// Area Entity Identificator
        /// </summary>
        [ForeignKey("Area")]
        public int AreaId { get; set; }

        public AreaDTO Area { get; set; }
    }
}
