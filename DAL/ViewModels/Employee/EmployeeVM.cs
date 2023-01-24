using DAL.Common;
using FluentValidation;
using System.Text.RegularExpressions;

namespace DAL.ViewModels.Employee
{
    public class EmployeeVM
    {
        public Guid Employee_Id { get; set; }
        public string Employee_Name { get; set; }
        public string DOB { get; set; }
        public string DOBinString { get; set; }
        public Gender Gender { get; set; }
        public string GenderName { get; set; }
        public string Salary { get; set; }
        public string Entry_By { get; set; }
        public DateTime Entry_Date { get; set; }
        public string EntryDateInString { get; set; }
        public List<EmpolyeeQualification> EmpolyeeQualifications { get; set; }
    }
    public class CreateEmployeeCommand
    {
        public string Employee_Name { get; set; }
        public string DOB { get; set; }
        public Gender Gender { get; set; }
        public string Salary { get; set; }
        public string Entry_By { get; set; }
        public DateTime Entry_Date { get; set; }
        public List<EmpolyeeQualification> EmpolyeeQualifications { get; set; }
    }
    public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeCommandValidator()
        {
            RuleFor(x => x.Employee_Name)
                  .NotEmpty()
                      .WithErrorCode("required")
                      .WithMessage("Employee Name is required")
                  .Must(MustOnlyBeCharacters)
                      .WithErrorCode("onlyCharacters")
                      .WithMessage("Employee name only contains characters");

            RuleFor(x => x.DOB)
                    .NotEmpty()
                        .WithErrorCode("required")
                        .WithMessage("DOB is required")
                     .Must(BeValidDate)
                        .WithErrorCode("notValidDate")
                        .WithMessage("Must be valid date");

            RuleFor(x => x.DOB)
                    .Must(BePastDate)
                        .WithErrorCode("notPastDate")
                        .WithMessage("Date of birth cannot be future date");

            RuleFor(x => x.Gender)
                    .NotEmpty()
                        .WithErrorCode("required")
                        .WithMessage("Gender is required")
                    .Must(MustBeValidGenderValue)
                        .WithErrorCode("notValidGenderValue")
                        .WithMessage("Gender value is not valid");
            RuleFor(x => x.Salary)
                   .NotEmpty()
                        .WithErrorCode("required")
                        .WithMessage("Salary is required")
                    .Must(BeValidNumber)
                        .WithErrorCode("notValidNumber")
                        .WithMessage("Number is not valid");

            RuleFor(x => x.Entry_By)
                    .NotEmpty()
                        .WithErrorCode("required")
                        .WithMessage("Entry name is required");

        }

        private bool BePastDate(string date)
        {
            try
            {
                var dateValue = DateTime.Parse(date).ToString("yyyy-MM-dd");
                if (DateTime.Parse(dateValue) >= DateTime.Today)
                    return false;
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool BeValidDate(string date)
        {
            try
            {
                var dateValue = DateTime.Parse(date).ToString("yyyy-MM-dd");
                if (DateTime.TryParse(dateValue, out DateTime val))
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
            
        }

        private bool BeValidNumber(string number)
        {
            if (int.TryParse(number, out int num1) || float.TryParse(number, out float num2))
                return true;
            return false;
        }

        private bool MustBeValidGenderValue(Gender value)
        {
            if (value is Gender.Male || value is Gender.Female || value is Gender.ThirdGender) 
                return true;
            return false;
        }

        private bool MustOnlyBeCharacters(string employeeName)
        {
            string pattern = @"\w+(\s\w+)*";
            if (Regex.IsMatch(employeeName, pattern)) 
                return true;
            return false;
        }
    }
    public class UpdateEmployeeCommand
    {
        public Guid Employee_Id { get; set; }
        public string Employee_Name { get; set; }
        public string DOB { get; set; }
        public Gender Gender { get; set; }
        public string Salary { get; set; }
        public string Entry_By { get; set; }
        public DateTime Entry_Date { get; set; }
        public List<EmpolyeeQualification> UpdateQualifications { get; set; }
    }
    public class EmpolyeeQualification
    {
        public Guid Q_Id { get; set; }
        public string Q_Name { get; set; }
        public double? Marks { get; set; }
    }
}
