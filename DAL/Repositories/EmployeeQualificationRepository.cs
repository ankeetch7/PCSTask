using DAL.DataContext;
using DAL.Models;
using DAL.Repositories.IRepositories;
using DAL.ViewModels.EmpQualification;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class EmployeeQualificationRepository  : IEmployeeQualificationRepository
    {
        private readonly ApplicatiobDbContext _context;
        public EmployeeQualificationRepository(ApplicatiobDbContext context) 
        { 
            _context = context;
        }

        public async Task<IEnumerable<EmployeeQualificationVM>> GetAllEmployeeQualification()
        {
            var empQualification = await _context.EMP_Qualification
                                                                        .Select(x => new EmployeeQualificationVM
                                                                        {
                                                                            Employee_Id= x.Employee_Id,
                                                                            Q_Id= x.Q_Id,
                                                                            Marks= x.Marks,
                                                                        }).ToListAsync();
            return empQualification;
        }

        public async Task<int> CreateEmployeeQualification(CreateEmployeeQualificationCommand command)
        {
            var employeeQualification = new EMP_Qualification
            {
                Employee_Id = command.Employee_Id,
                Q_Id = command.Q_Id,
                Marks = command.Marks
            };

            _context.EMP_Qualification.Add(employeeQualification);
            var value = await _context.SaveChangesAsync();
            return value;
        }

        public async Task<int> UpdateEmployeeQualification(UpdateEmployeeQualificationCommand command)
        {
            var empQualification = _context.EMP_Qualification
                                                .Where(x => x.Employee_Id == command.Employee_Id &&
                                                        x.Q_Id == command.Q_Id).FirstOrDefault();
            if (empQualification is null)
            {
                return 0;
            }

            empQualification.Employee_Id = command.Employee_Id;
            empQualification.Q_Id = command.Q_Id;
            empQualification.Marks = command.Marks;

            var value = await _context.SaveChangesAsync();
            return value;
        }

        public async Task<int> DeleteEmployeeQualification(Guid Employee_Id, Guid Q_Id)
        {
            var empQualification = _context.EMP_Qualification
                                        .Where(x => x.Employee_Id == Employee_Id &&
                                                x.Q_Id == Q_Id).FirstOrDefault();
            if (empQualification is null)
                return 0;

            _context.EMP_Qualification.Remove(empQualification);
            var value = await _context.SaveChangesAsync();
            return value;
        }

        public async Task<IEnumerable<EmployeeQualificationVM>> GetEmployeeQualification(Guid Employee_Id)
        {
            var empQualification = await _context.EMP_Qualification
                                            .Where(x => x.Employee_Id == Employee_Id)
                                            .Select(x => new EmployeeQualificationVM
                                            {
                                                Q_Id= x.Q_Id,
                                                Q_Name = x.QualificationList.Q_Name,
                                                Marks = x.Marks,
                                                Employee_Id = x.Employee_Id,
                                            }).ToListAsync();
            return empQualification;
        }
    }
}
