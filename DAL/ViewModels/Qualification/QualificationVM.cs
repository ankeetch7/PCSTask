using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels.Qualification
{
    public class QualificationVM
    {
        public Guid Q_Id { get; set; }
        public string Q_Name { get; set; }
    }
    public class CreateQualificationCommand
    {
        public string Q_Name { get; set; }
    }
    public class UdateQualificationCommand
    {
        public Guid Q_Id { get; set; }
        public string Q_Name { get; set; }
    }
}
