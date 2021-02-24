using System;
using Lessons3_ClassesObjectsMethods.Models;

namespace Lessons3_ClassesObjectsMethods.Factories
{
    public class Candidate : BaseUser, IInfoActions
    {
        public void ShowInfo()
        {
            Console.WriteLine(
                $"Hello, I am {FullName} I want to be a {JobTittle} ({JobDescription}) with a salary from {JobSalary}");
        }
        
    }
}