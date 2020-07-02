using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeePlatform.Entities
{
    /// <summary>
    /// Employer Model
    /// </summary>
    public class EmployeeDTO : BaseEntityDTO
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
        /// User IdentificationNumber
        /// </summary>
        public IdentificationTypeDTO IdentificationType { get; set; }

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

        /// <summary>
        /// Subarea
        /// </summary>
        public SubareaDTO Subarea { get; set; }

        /// <summary>
        /// Token
        /// </summary>
        public string Token { get; set; }
    }

    /// <summary>
    /// Pagination Entity
    /// </summary>
    public class EmployePaginationDTO : PaginationDTO
    {
        /// <summary>
        /// Employee list
        /// </summary>
        public List<EmployeeDTO> Results { get; set; }

        /// <summary>
        /// Token
        /// </summary>
        public string Token { get; set; }

    }
    /// <summary>
    /// Pagination Entity
    /// </summary>
    public class EmployeGeneralDTO
    {
        public EmployeGeneralDataDTO Data { get; set; }

    }
    /// <summary>
    /// Pagination Entity
    /// </summary>
    public class EmployeGeneralDataDTO
    {
        public List<AreaDTO> Areas { get; set; }
        public List<IdentificationTypeDTO> IdentificationTypes { get; set; }
        public EmployeeDTO Employee { get; set; }

    }
}