using System;

namespace CmsApi.Models
{
    public class Teacher : User
    {
        public decimal Salary { get; set; }
        public Subject Subjects { get; set; }

        public Teacher() : base()
        {
        }

        public Teacher(int id, string firstName, string lastName, DateTime birthDay, decimal salary) : base(id, firstName, lastName, birthDay)
        {
            Id = id;
            Salary = salary;
        }
    }
}