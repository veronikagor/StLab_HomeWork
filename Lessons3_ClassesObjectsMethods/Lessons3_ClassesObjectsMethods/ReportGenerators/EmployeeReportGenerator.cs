using System;
using System.Collections.Generic;
using ConsoleTables;
using Lessons3_ClassesObjectsMethods.Models;

namespace Lessons3_ClassesObjectsMethods
{
    public class EmployeeReportGenerator : IReportGenerator
    {
        public static List<Employee> _employees { get; set; }

        public EmployeeReportGenerator(List<Employee> employees)
        {
            _employees = employees;
        }

        public void SortUsers()
        {
            _employees.Sort(new EmployeeComparer());
        }

        public void ShowSortedUserInfo()
        {
            var table = new ConsoleTable("User Id", "Company name", "Users full name", "Job salary");
            foreach (var employee in _employees)
            {
                table.AddRow(employee.Id, employee.Company.Name, employee.FullName, employee.Job.Salary);
            }

            Console.WriteLine(table);
        }
    }
}