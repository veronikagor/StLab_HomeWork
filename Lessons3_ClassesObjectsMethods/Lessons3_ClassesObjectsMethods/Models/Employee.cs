using System;

namespace Lessons3_ClassesObjectsMethods.Models
{
    public class Employee : BaseUser, IInfoActions
    {
        public string CompanyName { get; set; }
        public string CompanyCountry { get; set; }
        public string CompanyCity { get; set; }
        public string CompanyStreet { get; set; }
        
        public void ShowInfo()
        {
            Console.WriteLine(
                $"Hello, I am {FullName}, {JobTittle} in {CompanyName} ({CompanyCountry}, {CompanyCity}, {CompanyStreet}) and my salary {JobSalary}");
        }
    }
}