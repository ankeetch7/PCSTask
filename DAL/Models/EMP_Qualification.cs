using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class EMP_Qualification
    {
        public Guid Employee_Id { get; set; }
        public Employee Employee { get; set; }
        public Guid Q_Id { get; set; }
        public QualificationList QualificationList { get; set; }
        public double Marks { get; set; }
    }
}
