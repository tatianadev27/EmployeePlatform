using System.Collections.Generic;

namespace EmployeePlatform.Entities
{
    /// <summary>
    /// Pagination Entity
    /// </summary>
    public class PaginationDTO
    {
        /// <summary>
        /// Total registers
        /// </summary>
        public int TotalRecords { get; set; }

        /// <summary>
        /// Total pages
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// Error
        /// </summary>
        public bool Error { get; set; }
    }
}
