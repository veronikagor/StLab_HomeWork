using System;
using System.Collections.Generic;
using Bogus;
using Lessons3_ClassesObjectsMethods.Models;

namespace Lessons3_ClassesObjectsMethods.Factories
{
    public class UserFactory
    {
        public List<Candidate> GetCandidates(int userCount)
        {
            return GetBaseUserInfo<Candidate>()
                .RuleFor(u => u.Job, f => new JobFaker().GetJobInfo().Generate())
                .Generate(userCount);
        }

        public List<Employee> GetEmployees(int userCount)
        {
            return GetBaseUserInfo<Employee>()
                .RuleFor(u => u.Company, f => new CompanyFaker().GetCompany().Generate())
                .RuleFor(u => u.Job, f => new JobFaker().GetJobInfo().Generate())
                .Generate(userCount);
        }

        private Faker<T> GetBaseUserInfo<T>() where T : BaseUser
        {
            return new Faker<T>()
                .RuleFor(b => b.Id, f => Guid.NewGuid())
                .RuleFor(b => b.FirstName, f => f.Name.FirstName())
                .RuleFor(b => b.LastName, f => f.Name.LastName())
                .RuleFor(b => b.FullName, f => f.Name.FullName());
        }
    }
}