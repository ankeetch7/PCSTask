using DAL.Common.Extensions;
using DAL.DataContext;
using DAL.Models;
using DAL.Repositories.IRepositories;
using DAL.ViewModels.Employee;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicatiobDbContext _context;
        public EmployeeRepository(ApplicatiobDbContext context)
        {
            _context= context;
        }

        public async Task<IEnumerable<EmployeeVM>> GetAllEmployees()
        {
            return await _context.Employees
                                    .Select(x => new EmployeeVM
                                    {
                                        Employee_Id = x.Employee_Id,
                                        Employee_Name = x.Employee_Name,
                                        Gender = x.Gender,
                                        Salary = x.Salary.ToString(),
                                        DOB = DateTime.Parse(x.DOB).ToString("yyyy-MM-dd"),
                                        DOBinString = x.DOB,
                                        EntryDateInString = x.Entry_Date.ToString("yyyy/MM/dd"),
                                        GenderName = x.Gender.GetEnumDisplayName(),
                                        Entry_By = x.Entry_By,
                                        Entry_Date = x.Entry_Date,
                                        EmpolyeeQualifications = x.EMP_Qualifications.Select(x => new EmpolyeeQualification
                                        {
                                            Q_Id = x.Q_Id,
                                            Q_Name = x.QualificationList.Q_Name,
                                            Marks = x.Marks
                                        }).ToList(),
                                    }).ToListAsync();
        }

        public async Task<EmployeeVM> GetEmployeeById(Guid Employee_id)
        {
            return await _context.Employees
                            .Select(x => new EmployeeVM
                            {
                                Employee_Id = x.Employee_Id,
                                Employee_Name = x.Employee_Name,
                                Gender = x.Gender,
                                Salary = x.Salary.ToString(),
                                DOB = x.DOB,
                                DOBinString = x.DOB,
                                Entry_By = x.Entry_By,
                                Entry_Date = x.Entry_Date,
                                EntryDateInString = x.Entry_Date.ToString("yyyy/MM/dd"),
                            }).FirstOrDefaultAsync();
        }

        public async Task<int> CreateEmployee(CreateEmployeeCommand command)
        {
            var sal = command.Salary is null ? 0 : double.Parse(command.Salary);
            var employee = new Employee
            {
                Employee_Name = command.Employee_Name,
                Gender = command.Gender,
                Salary = sal,
                DOB  =  DateTime.Parse(command.DOB).ToString("yyyy/MM/dd"),
                Entry_By = command.Entry_By,
                Entry_Date = DateTime.UtcNow.AddHours(5).AddMinutes(45) 
            };

            foreach(var empQ in command.EmpolyeeQualifications)
            {
                var empQualification = new EMP_Qualification
                {
                    Q_Id = empQ.Q_Id,
                    Marks= (double)empQ.Marks,
                };
                employee.AddEmployeeQualification(empQualification);
            }
           
            _context.Employees.Add(employee);
            var result = await _context.SaveChangesAsync();
            return result;
        }

        public async Task<int> UpdateEmployee(UpdateEmployeeCommand command)
        {
            var sal = command.Salary is "" ? 0 : double.Parse(command.Salary);
            var emp = await _context.Employees.FindAsync(command.Employee_Id);
            if (emp is null)
                return 0;

            emp.Employee_Name = command.Employee_Name;
            emp.Salary = sal;
            emp.DOB = DateTime.Parse(command.DOB).ToString("yyyy/MM/dd");
            emp.Gender = command.Gender;
            emp.Entry_By = command.Entry_By;
            emp.Entry_Date = emp.Entry_Date;

            if(command.UpdateQualifications.Count > 0)
            {
                foreach (var empQ in command.UpdateQualifications)
                {
                    var empQualification = new EMP_Qualification
                    {
                        Q_Id = empQ.Q_Id,
                        Marks = (double)empQ.Marks,
                    };
                    emp.AddEmployeeQualification(empQualification);
                }
            }

            var result = await _context.SaveChangesAsync();
            return result;
        }

        public async Task<int> DeleteEmployee(Guid Employee_id)
        {
            var emp = await _context.Employees.FindAsync(Employee_id);
            if (emp is null)
                return 0;

            var empQualifications = await _context.EMP_Qualification
                                            .Where(x => x.Employee_Id == Employee_id)
                                            .ToListAsync();
            foreach(var empQualification in empQualifications)
            {
                _context.EMP_Qualification.Remove(empQualification);    
            };

            _context.Employees.Remove(emp);
            var result = await _context.SaveChangesAsync();
            return result;
        }

    }
}
