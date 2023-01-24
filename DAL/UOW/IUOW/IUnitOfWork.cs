using DAL.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UOW.IUOW
{
    public interface IUnitOfWork
    {
        IEmployeeRepository Employees { get; }
        IQualificationRepository Qualifications { get; }
        IEmployeeQualificationRepository EmployeeQualifications { get; }


    }
}
