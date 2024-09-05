using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DBase
{
    public class Project
    {
        public int ProjectId { get; set; }
        [Required]
        public string? ProjectName { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
