using Bogus;
using Lessons3_ClassesObjectsMethods.Models;

namespace Lessons3_ClassesObjectsMethods.Factories
{
    public class JobFaker
    {
        private const int MinSalary = 100;
        private const int MaxSalary = 20000;

        public Faker<Job> GetJobInfo()
        {
            return new Faker<Job>()
                .RuleFor(j => j.Tittle, f => f.Name.JobTitle())
                .RuleFor(j => j.Description, f => f.Name.JobDescriptor())
                .RuleFor(j => j.Salary, f => f.Random.Int(MinSalary, MaxSalary));
        }
    }
}