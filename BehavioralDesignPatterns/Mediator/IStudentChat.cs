namespace BehavioralDesignPatterns.Mediator;

public interface IStudentChat {
    public void SendMessage(string msg, Student student);
    void AddStudent(Student student);
}