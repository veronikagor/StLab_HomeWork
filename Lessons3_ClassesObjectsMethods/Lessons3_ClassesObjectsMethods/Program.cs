using System.Linq;
using Lessons3_ClassesObjectsMethods.Factories;
using Lessons3_ClassesObjectsMethods.ReportGenerators;
using Lessons3_ClassesObjectsMethods.Utils;

namespace Lessons3_ClassesObjectsMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new UserFactory();

            var candidates = factory.GetCandidates(RandomUtils.CreateRandomNumberOfUsers());
            var employees = factory.GetEmployees(RandomUtils.CreateRandomNumberOfUsers());

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