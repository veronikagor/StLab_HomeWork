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

            const int minCountOfUsers = 1;
            const int maxCountOfUsers = 10;

            var candidates = factory.GetCandidates(RandomUtils.RandomInt(minCountOfUsers, maxCountOfUsers));
            var employees = factory.GetEmployees(RandomUtils.RandomInt(minCountOfUsers, maxCountOfUsers));

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