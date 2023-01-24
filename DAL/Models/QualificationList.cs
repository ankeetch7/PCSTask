using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class QualificationList
    {
        public QualificationList()
        {
            EMP_Qualifications = new List<EMP_Qualification>();
        }
        public Guid Q_Id { get; set; }
        public string Q_Name { get; set;}
        public ICollection<EMP_Qualification> EMP_Qualifications { get; set; }
    }
}
