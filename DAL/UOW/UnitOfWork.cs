using DAL.DataContext;
using DAL.Repositories;
using DAL.Repositories.IRepositories;
using DAL.UOW.IUOW;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicatiobDbContext _context;
        public UnitOfWork(ApplicatiobDbContext context)
        {
            _context = context;
        }
        public IEmployeeRepository _employee;
        public IQualificationRepository _qualificaion;
        public IEmployeeQualificationRepository _empQualification;

        public IEmployeeRepository Employees
        {
            get
            {
                if (_employee is null)
                    return new EmployeeRepository(_context);
                return _employee;
            }
        }
        public IQualificationRepository Qualifications
        {
            get
            {
                if (_employee is null)
                    return new QualificationRepository(_context);
                return _qualificaion;
            }
        }

        public IEmployeeQualificationRepository EmployeeQualifications
        {
            get
            {
                if (_employee is null)
                    return new EmployeeQualificationRepository(_context);
                return _empQualification;
            }
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task DisposableAsync()
        {
            await _context.DisposeAsync();
        }


    }
}
