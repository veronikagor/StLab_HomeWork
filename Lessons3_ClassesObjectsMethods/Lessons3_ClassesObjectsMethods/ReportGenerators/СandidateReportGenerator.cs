using System;
using System.Collections.Generic;
using ConsoleTables;
using Lessons3_ClassesObjectsMethods.Factories;
using Lessons3_ClassesObjectsMethods.Interfaces;

namespace Lessons3_ClassesObjectsMethods
{
    public class СandidateReportGenerator : IReportGenerator
    {
        public static List<Candidate> _candidates { get; set; }

        public СandidateReportGenerator(List<Candidate> candidates)
        {
            _candidates = candidates;
        }

        public void SortUsers()
        {
            _candidates.Sort(new CandidateComparer());
        }

        public void ShowSortedUserInfo()
        {
            var table = new ConsoleTable("User Id", "Users full name", "Job tittle", "Job salary");
            foreach (var candidate in _candidates)
            {
                table.AddRow(candidate.Id, candidate.FullName, candidate.Job.Tittle, candidate.Job.Salary);
            }

            Console.WriteLine(table);
        }
    }
}