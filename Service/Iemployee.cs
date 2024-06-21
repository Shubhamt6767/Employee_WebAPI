using Microsoft.AspNetCore.Mvc;
using WebApplication_server.models;

namespace WebApplication_server.Service
{
    public interface Iemployee
    {
        Task<ActionResult<Employee>?> GetEmployee(int Id);
        Task<ActionResult<IEnumerable<Employee>>> GetAllEmployee();
       Task<ActionResult<Employee>> Add(Employee employee);
        Task<Employee> Update(int id, Employee employeeChanges);
        Task<Employee> Delete(int Id);
    }

}


