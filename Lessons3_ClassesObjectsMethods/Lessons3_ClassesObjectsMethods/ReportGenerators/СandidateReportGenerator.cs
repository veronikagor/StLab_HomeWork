using System;
using System.Collections.Generic;
using ConsoleTables;
using Lessons3_ClassesObjectsMethods.Interfaces;
using Lessons3_ClassesObjectsMethods.Models;

namespace Lessons3_ClassesObjectsMethods.ReportGenerators
{
    public class СandidateReportGenerator : IReportGenerator
    {
        private static List<Candidate> Candidates { get; set; }

        public СandidateReportGenerator(List<Candidate> candidates)
        {
            Candidates = candidates;
        }

        public void SortUsers()
        {
            Candidates.Sort(new CandidateComparer());
        }

        public void ShowSortedUserInfo()
        {
            var table = new ConsoleTable("User Id", "Users full name", "Job tittle", "Job salary");
            foreach (var candidate in Candidates)
            {
                table.AddRow(candidate.Id, candidate.FullName, candidate.Job.Tittle, candidate.Job.Salary);
            }

            Console.WriteLine(table);
        }
    }
}