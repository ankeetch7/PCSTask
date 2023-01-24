using DAL.ViewModels.Qualification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.IRepositories
{
    public interface IQualificationRepository
    {
        Task<int> CreateQualification(CreateQualificationCommand command);
        Task<int> UpdateQualification(UdateQualificationCommand command);
        Task<int> DeleteQualification(Guid Q_Id);
        Task<IEnumerable<QualificationVM>> GetAllQualifications(); 
    }
}
