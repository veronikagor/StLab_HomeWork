using System;
using System.Collections.Generic;
using ConsoleTables;
using Lessons3_ClassesObjectsMethods.Factories;

namespace Lessons3_ClassesObjectsMethods
{
    public class СandidateReportGenerator : IReportGenerator<Candidate>
    {
        public int Compare(object a, object b)
        {
            Candidate c1 = (Candidate) a;
            Candidate c2 = (Candidate) b;
            if (c2.JobTittle == c1.JobTittle)
            {
                if (c1.JobSalary > c2.JobSalary)
                    return 1;
                if (c1.JobSalary < c2.JobSalary)
                    return -1;
                else
                    return 0;
            }

            return String.Compare(c1.JobTittle, c2.JobTittle);
        }
        
        public static void ShowSortedUserInfo(List<Candidate> candidates)
        {
            var table = new ConsoleTable("Id", "Users full name", "Job tittle", "Job salary");

            foreach (var candidate in candidates)
            {
                table.AddRow(candidate.Id, candidate.FullName, candidate.JobTittle, candidate.JobSalary);
            }

            Console.WriteLine(table);
        }
    }
}