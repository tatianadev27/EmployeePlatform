using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeePlatform.Entities
{
    /// <summary>
    /// Area Model
    /// </summary>
    public class BaseEntityDTO
    {
        /// <summary>
        /// Entity Identificator
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Creation Date 
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Modification Date
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime ModifiedAt { get; set; }

        /// <summary>
        /// Create by
        /// </summary>
        [StringLength(100, ErrorMessage = "El {0} no puede exceder {1} caracteres.")]
        public string CreatedBy { get; set; }

        /// <summary>
        /// Modificate by
        /// </summary>
        [StringLength(100, ErrorMessage = "El {0} no puede exceder {1} caracteres.")]
        public string ModifiedBy { get; set; }
    }
}
