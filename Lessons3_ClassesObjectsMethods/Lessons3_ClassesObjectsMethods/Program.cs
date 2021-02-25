using System.Collections.Generic;
using System.Linq;
using Bogus;
using Lessons3_ClassesObjectsMethods.Factories;
using Lessons3_ClassesObjectsMethods.Models;

namespace Lessons3_ClassesObjectsMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            const int minCountOfUsers = 1;
            const int maxCountOfUsers = 10;
            UserFactory factory = new UserFactory();

            List<Candidate> candidates =
                factory.GetCandidates(new Faker().Random.Int(minCountOfUsers, maxCountOfUsers));

            List<Employee> employees =
                factory.GetEmployees(new Faker().Random.Int(minCountOfUsers, maxCountOfUsers));

            candidates.First().ShowInfo();
            employees.First().ShowInfo();

            var сandidateReportGenerator = new СandidateReportGenerator(candidates);
            var employeeReportGenerator = new EmployeeReportGenerator(employees);

            сandidateReportGenerator.SortUsers();
            employeeReportGenerator.SortUsers();

            сandidateReportGenerator.ShowSortedUserInfo();
            employeeReportGenerator.ShowSortedUserInfo();
        }
    }
}