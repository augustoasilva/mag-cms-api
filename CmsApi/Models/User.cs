using System;

namespace CmsApi.Models
{
    using System.ComponentModel.DataAnnotations;

    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDay { get; set; }

        public User() : base()
        {
        }

        public User(int id, string firstName, string lastName, DateTime birthDay) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDay = birthDay;
        }

        public string GetFullname()
        {
            return FirstName + ' ' + LastName;
        }
    }
}