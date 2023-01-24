using DAL.ViewModels.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.IRepositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeVM>> GetAllEmployees();
        Task<EmployeeVM> GetEmployeeById(Guid Employee_id);
        Task<int> CreateEmployee(CreateEmployeeCommand command);
        Task<int> UpdateEmployee(UpdateEmployeeCommand command);
        Task<int> DeleteEmployee(Guid Employee_id);
    }
}
