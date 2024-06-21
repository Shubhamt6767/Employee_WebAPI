using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using WebApplication_server.models;
using WebApplication_server.Repository;

namespace WebApplication_server.Service
{
    public class empservice : Iemployee
    {
        private readonly AppdbContextcs context;

    

        public empservice(AppdbContextcs context)
        {
            this.context = context;
        }

        public async Task<ActionResult<Employee>> Add(Employee employee)
        {
            context.Employees1.Add(employee);
            await context.SaveChangesAsync();
            return employee;

        }

        public async Task<Employee> Delete(int Id)
        {
            Employee employee = context.Employees1.Find(Id);
            if (employee != null)
            {
                context.Employees1.Remove(employee);
                await context.SaveChangesAsync();
            }
            return employee;

        }



        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployee()
        {
            if (context.Employees1 == null)
            {
                return null;
            }
            return await context.Employees1.ToListAsync();

        }

        public async Task<ActionResult<Employee>?> GetEmployee(int Id)
        {
            if (context.Employees1 == null)
            {
                return null;
            }
            var employee = await context.Employees1.FindAsync(Id);

            if (employee == null)
            {
                return null;
            }

            return employee;

        }

        public async Task<Employee?> Update(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return null;
            }

            context.Entry(employee).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return null;

        }
        private bool EmployeeExists(int id)
        {
            return (context.Employees1?.Any(e => e.Id == id)).GetValueOrDefault();
        }


    }
}


