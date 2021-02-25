using System;
using Bogus;
using Lessons3_ClassesObjectsMethods.Models;

namespace Lessons3_ClassesObjectsMethods.Factories
{
    public static class FakerExtensions
    {
        public static Faker<T> GetJobInfo<T>(this Faker<T> faker) where T : Job
        {
            return faker
                .RuleFor(j => j.Tittle, f => f.Name.JobTitle())
                .RuleFor(j => j.Description, f => f.Name.JobDescriptor())
                .RuleFor(j => j.Salary, f => f.Random.Int(0, 20000));
        }

        public static Faker<T> GetCompanyInfo<T>(this Faker<T> faker) where T : Company
        {
            return faker
                .RuleFor(c => c.Name, f => f.Name.JobDescriptor())
                .RuleFor(c => c.Country, f => f.Address.Country())
                .RuleFor(c => c.City, f => f.Address.City())
                .RuleFor(c => c.Street, f => f.Address.StreetName());
        }
    }
}