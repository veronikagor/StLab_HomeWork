using Bogus;
using Lessons3_ClassesObjectsMethods.Factories;

namespace Lessons3_ClassesObjectsMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new UserFactory();

            var candidates = factory.GetCandidates(new Faker().Random.Int(1, 10));
            var employees = factory.GetEmployees(new Faker().Random.Int(1, 10));

            foreach (var candidate in candidates)
            {
                candidate.ShowInfo();
            }

            foreach (var employee in employees)
            {
                employee.ShowInfo();
            }

            EmployeeReportGenerator employeeReportGenerator = new EmployeeReportGenerator();
            СandidateReportGenerator сandidateReportGenerator = new СandidateReportGenerator();

            candidates.Sort(сandidateReportGenerator.Compare);
            employees.Sort(employeeReportGenerator.Compare);

            СandidateReportGenerator.ShowSortedUserInfo(candidates);
            EmployeeReportGenerator.ShowSortedUserInfo(employees);
        }
    }
}