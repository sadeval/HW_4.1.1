using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DBase
{
    public class Company
    {
        public int CompanyId { get; set; }
        [Required]
        public string? Name { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
