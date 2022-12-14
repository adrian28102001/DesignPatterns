using BehavioralDesignPatterns.Mediator;

namespace BehavioralDesignPatterns.IteratorPattern;

public class StudentCollection : IStudentCollection
{
    private readonly List<Student> _studentsList;

    public StudentCollection()
    {
        _studentsList = new List<Student>();
    }

    public void AddStudent(Student student)
    {
        _studentsList.Add(student);
    }

    public void RemoveStudent(Student student)
    {
        _studentsList.Remove(student);
    }

    public IIterator Iterator(StudentEnum studentName)
    {
        return new Iterator(studentName, _studentsList);
    }
}