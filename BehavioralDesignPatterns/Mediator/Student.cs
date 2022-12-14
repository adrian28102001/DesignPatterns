using BehavioralDesignPatterns.StatePattern;

namespace BehavioralDesignPatterns.Mediator;

public abstract class Student
{
    private readonly IStudentChat _chat;
    public readonly string Name;
    private IState _state;

    protected Student(IStudentChat chat, string name)
    {
        _chat = chat;
        Name = name;
    }

    public abstract string Send(string msg);

    public abstract void Receive(string msg);

    public string GetName()
    {
        return Name;
    }

    public IStudentChat GetMediator()
    {
        return _chat;
    }

    public void OnLine()
    {
        _state = new OnLine(this);
    }

    public void OffLine()
    {
        _state = new OffLine(this);
    }

    public string? GetState()
    {
        return _state.ToString();
    }
}