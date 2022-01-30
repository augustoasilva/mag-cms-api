namespace CmsApi.Models;

public class Grade : Entity
{
    public int StudentId { get; set; }
    public Student? Student { get; set; }
    public int SubjectId { get; set; }
    public Subject? Subject { get; set; }
    public double Value { get; set; }

    public Grade() : base()
    {
    }

    public Grade(int id, int studentId, int subjectId, double value) : base(id)
    {
        StudentId = studentId;
        SubjectId = subjectId;
        Value = value;
    }
}