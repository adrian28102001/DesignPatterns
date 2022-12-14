namespace BehavioralDesignPatterns.Mediator;

public class StudentChat : IStudentChat
{
    private readonly List<Student?> _students;

    public StudentChat()
    {
        _students = new List<Student?>();
    }

    public void SendMessage(string msg, Student student)
    {
        foreach (var s in _students)
        {
            s?.Receive(msg);
        }
    }

    public void AddStudent(Student student)
    {
        _students.Add(student);
    }
}