namespace CmsApi.Models;

public class Student : User
{
    public int RegistrationNumber { get; set; }
    public IEnumerable<StudentSubject>? Subjects { get; set; }
    public IEnumerable<Grade>? Grades { get; set; }

    public Student() : base()
    {
    }

    public Student(int id, string firstName, string lastName, DateTime birthDay, int registrationNumber) : base(id, firstName, lastName, birthDay)
    {
        RegistrationNumber = registrationNumber;
    }
}