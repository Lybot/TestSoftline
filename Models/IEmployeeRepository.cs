using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestTask.Models
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int employeeId);
        Task<(bool,string)> AddEmployee(Employee employee);
        Task<(bool, string)> UpdateEmployee(Employee employee);
        Task<(bool, string)> DeleteEmployee(int employeeId);
    }
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DatabaseContext dbContext;

        public EmployeeRepository(DatabaseContext appDbContext)
        {
            this.dbContext = appDbContext;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await dbContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployee(int employeeId)
        {
            return await dbContext.Employees.FirstOrDefaultAsync(e => e.Id == employeeId);
        }

        public async Task<(bool, string)> AddEmployee(Employee employee)
        {
            try
            {
                var result = await dbContext.Employees.AddAsync(employee);
                await dbContext.SaveChangesAsync();
                return (true, "");
            }
            catch(Exception e)
            {
                return (false, e.Message);
            }
        }

        public async Task<(bool, string)> UpdateEmployee(Employee employee)
        {
            try
            {
                var result = await dbContext.Employees.FirstOrDefaultAsync(e => e.Id == employee.Id);
                if (result != null)
                {
                    result.FirstName = employee.FirstName;
                    result.LastName = employee.LastName;
                    result.MiddleName = employee.MiddleName;
                    result.Birthday = employee.Birthday;
                    result.IsMaternity = employee.IsMaternity;
                    result.Text = employee.Text;
                    await dbContext.SaveChangesAsync();

                    return (true,"");
                }

                return (false,"Can't find");
            }
            catch (Exception e)
            {
                return (false, e.Message);
            }
        }

        public async Task<(bool, string)> DeleteEmployee(int employeeId)
        {
            try
            {
                var result = await dbContext.Employees.FirstOrDefaultAsync(e => e.Id == employeeId);
                if (result != null)
                {
                    dbContext.Employees.Remove(result);
                    await dbContext.SaveChangesAsync();
                    return (true, "");
                }
                return (false, "Can't find");
            }
            catch (Exception e)
            {
                return (false, e.Message);
            }
        }
    }
}
