using System;
using System.Collections.Generic;
using ConsoleTables;
using Lessons3_ClassesObjectsMethods.Models;

namespace Lessons3_ClassesObjectsMethods
{
    public class EmployeeReportGenerator : IReportGenerator<Employee>
    {
        public int Compare(object a, object b)
        {
            Employee e1 = (Employee) a;
            Employee e2 = (Employee) b;
            if (e2.CompanyName == e1.CompanyName)
            {
                if (e1.JobSalary < e2.JobSalary)
                    return 1;
                if (e1.JobSalary > e2.JobSalary)
                    return -1;
                else
                    return 0;
            }

            return String.Compare(e1.CompanyName, e2.CompanyName);
        }

        public static void ShowSortedUserInfo(List<Employee> employees)
        {
            var table = new ConsoleTable("User Id", "Company name", "Users full name", "Job salary");

            foreach (var employee in employees)
            {
                table.AddRow(employee.Id, employee.CompanyName, employee.FullName, employee.JobSalary);
            }

            Console.WriteLine(table);
        }
    }
}