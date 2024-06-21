using Microsoft.EntityFrameworkCore;
using System;
using WebApplication_server.models;

namespace WebApplication_server.Repository
{
    public class AppdbContextcs: DbContext
    {
        public AppdbContextcs(DbContextOptions<AppdbContextcs> options)
             : base(options)
        {
        }
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("EmployeeDBConnection");
            }
        }*/
        public DbSet<Employee> Employees1 { get; set; }
    }
}
