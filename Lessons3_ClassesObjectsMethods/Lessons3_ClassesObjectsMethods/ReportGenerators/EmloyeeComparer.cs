using System;
using System.Collections.Generic;
using Lessons3_ClassesObjectsMethods.Models;

namespace Lessons3_ClassesObjectsMethods.ReportGenerators
{
    class EmployeeComparer : IComparer<Employee>
    {
        public int Compare(Employee u1, Employee u2)
        {
            if (u2.Company.Name == u1.Company.Name)
            {
                if (u1.Job.Salary < u2.Job.Salary)
                    return 1;
                if (u1.Job.Salary > u2.Job.Salary)
                    return -1;
                else
                    return 0;
            }

            return String.Compare(u1.Company.Name, u2.Company.Name);
        }
    }
}