using BehavioralDesignPatterns.Mediator;

namespace BehavioralDesignPatterns.StatePattern;

public class OnLine : IState
{
    private readonly Student _student;

    public OnLine(Student student){
        _student = student;
    }
    
    public void Send(string message)
    {
        Console.WriteLine(_student.GetName() + ": Sending Message: " + message);
        _student.GetMediator().SendMessage(message, _student);
    }

    public void Receive(string message)
    {
        Console.WriteLine(_student.GetName() + ": Received Message: " + message);
    }
}