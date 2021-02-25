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
                .RuleFor(u => u.Job, f => FakerExtensions.GetJobInfo(new Faker<Job>()).Generate())
                .Generate(userCount);
        }

        public List<Employee> GetEmployees(int userCount)
        {
            return GetBaseUserInfo<Employee>()
                .RuleFor(u => u.Company, f => FakerExtensions.GetCompanyInfo(new Faker<Company>()))
                .RuleFor(u => u.Job, f => FakerExtensions.GetJobInfo(new Faker<Job>()).Generate())
                .Generate(userCount);
        }

        private Faker<TUser> GetBaseUserInfo<TUser>() where TUser : BaseUser
        {
            return new Faker<TUser>()
                .RuleFor(b => b.Id, f => Guid.NewGuid())
                .RuleFor(b => b.FirstName, f => f.Name.FirstName())
                .RuleFor(b => b.LastName, f => f.Name.LastName())
                .RuleFor(b => b.FullName, f => f.Name.FullName());
        }
    }
}