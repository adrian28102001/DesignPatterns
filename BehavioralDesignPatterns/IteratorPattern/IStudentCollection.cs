using BehavioralDesignPatterns.Mediator;

namespace BehavioralDesignPatterns.IteratorPattern;

public interface IStudentCollection {
    public void AddStudent(Student student);

    public void RemoveStudent(Student student);

    public IIterator Iterator(StudentEnum studentName);
}