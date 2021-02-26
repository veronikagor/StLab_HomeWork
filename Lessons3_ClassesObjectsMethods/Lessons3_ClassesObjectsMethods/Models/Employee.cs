using System;
using Lessons3_ClassesObjectsMethods.Interfaces;

namespace Lessons3_ClassesObjectsMethods.Models
{
    public class Employee : BaseUser, IInfoActions
    {
        public Job Job { get; set; }

        public Company Company { get; set; }

        public void ShowInfo()
        {
            Console.WriteLine(
                $"Hello, I am {FullName}, {Job.Tittle} in {Company.Name} ({Company.Country}, {Company.City}, {Company.Street}) and my salary {Job.Salary}");
        }
    }
}