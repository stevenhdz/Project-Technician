using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project_Technician.Models;
using Project_Technician.ViewModels;


namespace Project_Technician.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project_Technician.ViewModels.ContactViewModel> ContactViewModel { get; set; }
        public DbSet<Employee> EmployeeViewModel { get; set; }

    }
}
