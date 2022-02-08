using System.Collections.Generic;

namespace CmsApi.Models
{
    public class Subject : Entity
    {
        public string Name { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public IEnumerable<StudentSubject> Students { get; set; }

        public Subject() : base()
        {
        }

        public Subject(int id, string name, int teacherId, int courseId) : base(id)
        {
            Name = name;
            TeacherId = teacherId;
            CourseId = courseId;
        }
    }
}