using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace DBase
{
    class Program
    {
        static void Main()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Database.EnsureDeleted();  
                db.Database.EnsureCreated();  

                Company company1 = new Company { Name = "Suenos" };
                Company company2 = new Company { Name = "Libertad" };

                Employee employee1 = new Employee { Name = "Jane", Company = company1 };
                Employee employee2 = new Employee { Name = "Marta", Company = company2 };
                Employee employee3 = new Employee { Name = "Fina", Company = company2 };

                Project project1 = new Project { ProjectName = "Project A" };
                Project project2 = new Project { ProjectName = "Project B" };
           
                employee1.Projects = new List<Project> { project1, project2 };
                employee2.Projects = new List<Project> { project1 };
                employee3.Projects = new List<Project> { project2 };

                db.Companies.AddRange(company1, company2);
                db.Employees.AddRange(employee1, employee2, employee3);
                db.Projects.AddRange(project1, project2);

                db.SaveChanges();
            }


            using (ApplicationContext db = new ApplicationContext())
            {
                var companyId = 1;
                var projects = db.Projects
                    .Where(p => p.Employees.Any(e => e.CompanyId == companyId))
                    .ToList();

                foreach (var project in projects)
                {
                    Console.WriteLine($"Project: {project.ProjectName}");
                }
            }

        }

    }
}
