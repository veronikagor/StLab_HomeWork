using System;
using System.Collections.Generic;
using ConsoleTables;
using Lessons3_ClassesObjectsMethods.Interfaces;
using Lessons3_ClassesObjectsMethods.Models;

namespace Lessons3_ClassesObjectsMethods.ReportGenerators
{
    public class EmployeeReportGenerator : IReportGenerator
    {
        private static List<Employee> Employees { get; set; }

        public EmployeeReportGenerator(List<Employee> employees)
        {
            Employees = employees;
        }

        public void SortUsers()
        {
            Employees.Sort(new EmployeeComparer());
        }

        public void ShowSortedUserInfo()
        {
            var table = new ConsoleTable("User Id", "Company name", "Users full name", "Job salary");
            foreach (var employee in Employees)
            {
                table.AddRow(employee.Id, employee.Company.Name, employee.FullName, employee.Job.Salary);
            }

            Console.WriteLine(table);
        }
    }
}