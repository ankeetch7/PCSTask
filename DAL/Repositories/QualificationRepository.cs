using DAL.DataContext;
using DAL.Models;
using DAL.Repositories.IRepositories;
using DAL.ViewModels.Qualification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DAL.Repositories
{
    public class QualificationRepository : IQualificationRepository
    {
        private readonly ApplicatiobDbContext _context;
        public QualificationRepository(ApplicatiobDbContext context)
        {
            _context= context;
        }
        public async Task<int> CreateQualification(CreateQualificationCommand command)
        {
            var qualificaiton = new QualificationList
            {
                Q_Name = command.Q_Name
            };
            _context.QualificationLists.Add(qualificaiton);
           var value =  await _context.SaveChangesAsync();
            return value;
        }

        public async Task<int> DeleteQualification(Guid Q_Id)
        {
            var qualification = await _context.QualificationLists.FindAsync(Q_Id);
            if (qualification is null)
            {
                return 0;
            }

            _context.Remove(qualification);
            var value = await _context.SaveChangesAsync();
            return value;
        }

        public async Task<IEnumerable<QualificationVM>> GetAllQualifications()
        {
            return await _context.QualificationLists
                .Select(x => new QualificationVM
                {
                    Q_Id = x.Q_Id,
                    Q_Name= x.Q_Name,
                }).ToListAsync();
        }

        public async Task<int> UpdateQualification(UdateQualificationCommand command)
        {
            var qualification = await _context.QualificationLists.FindAsync(command.Q_Id);
            if(qualification is null)
            {
                return 0;
            }

            qualification.Q_Name = command.Q_Name;
            var value = await _context.SaveChangesAsync();
            return value;
        }
    }
}
