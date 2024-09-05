using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DBase
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required]
        public string? Name { get; set; }
        public int CompanyId { get; set; }

        public Company Company { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}
