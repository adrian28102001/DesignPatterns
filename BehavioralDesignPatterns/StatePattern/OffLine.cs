using BehavioralDesignPatterns.Mediator;

namespace BehavioralDesignPatterns.StatePattern;

public class OffLine : IState
{
    private readonly Student _student;

    public OffLine(Student student)
    {
        _student = student;
    }

    public void Send(string message)
    {
      Console.WriteLine(_student.GetName() + "is not logged in and cannot send messages");
    }

    public void Receive(string message)
    {
        Console.WriteLine(_student.GetName() + "is not logged in and cannot send messages");
    }
}