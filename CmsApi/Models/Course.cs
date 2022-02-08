using System.Collections.Generic;

namespace CmsApi.Models
{
    public class Course : Entity
    {
        public string Name { get; set; }
        public IEnumerable<Subject> Subjects { get; set; }

        public Course() : base()
        {
        }

        public Course(int id, string name) : base(id)
        {
            Name = name;
        }
    }
}