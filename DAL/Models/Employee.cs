using DAL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Employee
    {
        public Employee()
        {
            EMP_Qualifications = new List<EMP_Qualification>();
        }
        public Guid Employee_Id { get; set; }
        public string Employee_Name { get; set; }
        public string DOB { get; set;}
        public Gender Gender { get; set;}
        public double Salary { get; set;}
        public string Entry_By { get; set;}
        public DateTime Entry_Date { get; set;}
        public ICollection<EMP_Qualification> EMP_Qualifications { get; set; }

        public void AddEmployeeQualification(EMP_Qualification eMP_Qualification)
        {
            EMP_Qualifications.Add(eMP_Qualification);
        }
    }
}
