using System.Collections;

namespace CmsApi.Models;

public class StudentSubject : Entity
{
    public int StudentId { get; set; }
    public Student? Student { get; set; }
    public int SubjectId { get; set; }
    public Subject? Subject { get; set; }

    public StudentSubject() : base()
    {
    }

    public StudentSubject(int studentId, int subjectId) : base()
    {
        StudentId = studentId;
        SubjectId = subjectId;
    }
}