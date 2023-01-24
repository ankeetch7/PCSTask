using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels.EmpQualification
{
    public class EmployeeQualificationVM
    {
        public Guid Employee_Id { get; set; }
        public Guid Q_Id { get; set; }
        public string Q_Name { get; set; }
        public double Marks { get; set; }
    }
    public class CreateEmployeeQualificationCommand
    {
        public Guid Employee_Id { get; set; }
        public Guid Q_Id { get; set; }
        public double Marks { get; set; }
    }
    public class UpdateEmployeeQualificationCommand
    {
        public Guid Employee_Id { get; set; }
        public Guid Q_Id { get; set; }
        public double Marks { get; set; }
    }
}
