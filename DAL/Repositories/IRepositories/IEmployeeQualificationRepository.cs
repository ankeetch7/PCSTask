using DAL.ViewModels.EmpQualification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.IRepositories
{
    public interface IEmployeeQualificationRepository
    {
        Task<int> CreateEmployeeQualification(CreateEmployeeQualificationCommand command);
        Task<int> UpdateEmployeeQualification(UpdateEmployeeQualificationCommand command);
        Task<int> DeleteEmployeeQualification(Guid Employee_Id, Guid Q_Id);
        Task<IEnumerable<EmployeeQualificationVM>> GetEmployeeQualification(Guid Employee_Id);
        Task<IEnumerable<EmployeeQualificationVM>> GetAllEmployeeQualification();
    }
}
