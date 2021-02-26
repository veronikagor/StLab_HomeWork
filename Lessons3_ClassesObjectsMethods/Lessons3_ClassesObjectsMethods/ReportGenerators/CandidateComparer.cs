using System;
using System.Collections.Generic;
using Lessons3_ClassesObjectsMethods.Models;

namespace Lessons3_ClassesObjectsMethods.ReportGenerators
{
    class CandidateComparer : IComparer<Candidate>
    {
        public int Compare(Candidate c1, Candidate c2)
        {
            if (c2.Job.Tittle == c1.Job.Tittle)
            {
                if (c1.Job.Salary > c2.Job.Salary)
                    return 1;
                if (c1.Job.Salary < c2.Job.Salary)
                    return -1;
                else
                    return 0;
            }

            return String.Compare(c1.Job.Tittle, c2.Job.Tittle);
        }
    }
}