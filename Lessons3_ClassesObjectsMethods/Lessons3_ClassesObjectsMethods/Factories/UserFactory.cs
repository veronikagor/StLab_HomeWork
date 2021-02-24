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
            return GetBaseUserInfo<Candidate>().Generate(userCount);
        }

        public List<Employee> GetEmployees(int userCount) 
        {
           return GetBaseUserInfo<Employee>()
               .RuleFor(b => b.CompanyName, f => f.Name.JobDescriptor())
                .RuleFor(b => b.CompanyCountry, f => f.Address.Country())
                .RuleFor(b => b.CompanyCity, f => f.Address.City())
                .RuleFor(b => b.CompanyStreet, f => f.Address.StreetName()).Generate(userCount);
        }

        private Faker<TUser> GetBaseUserInfo<TUser>() where TUser : BaseUser
        {
            return new Faker<TUser>()
                .RuleFor(c => c.Id, f => Guid.NewGuid())
                .RuleFor(c => c.FirstName, f => f.Name.FirstName())
                .RuleFor(c => c.LastName, f => f.Name.LastName())
                .RuleFor(c => c.LastName, f => f.Name.LastName())
                .RuleFor(c => c.FullName, f => f.Name.FullName())
                .RuleFor(c => c.JobTittle, f => f.Name.JobTitle())
                .RuleFor(c => c.JobDescription, f => f.Name.JobDescriptor())
                .RuleFor(c => c.JobSalary, f => f.Random.Int(0, 20000));
        }
    }
}