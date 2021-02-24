using System;

namespace Lessons3_ClassesObjectsMethods.Models
{
    public abstract class BaseUser
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string JobTittle { get; set; }
        public string JobDescription { get; set; }
        public int JobSalary { get; set; }
    }
}