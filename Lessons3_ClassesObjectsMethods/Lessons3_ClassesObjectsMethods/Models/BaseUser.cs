using System;

namespace Lessons3_ClassesObjectsMethods.Models
{
    public abstract class BaseUser
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }
    }
}