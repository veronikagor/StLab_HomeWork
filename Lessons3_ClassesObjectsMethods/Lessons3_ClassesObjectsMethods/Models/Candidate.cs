using System;
using Lessons3_ClassesObjectsMethods.Models;

namespace Lessons3_ClassesObjectsMethods.Factories
{
    public class Candidate : BaseUser, IInfoActions
    {
        public Job Job { get; set; }

        public void ShowInfo()
        {
            Console.WriteLine(
                $"Hello, I am {FullName} I want to be a {Job.Tittle} ({Job.Description}) with a salary from {Job.Salary}");
        }
    }
}