using BehavioralDesignPatterns.StatePattern;

namespace BehavioralDesignPatterns.Mediator;

public class NewStudent : Student
{
    private readonly IStudentChat _chat;
    private readonly string _name;
    public NewStudent(IStudentChat chat, string name) : base(chat, name)
    {
        _chat = chat;
        _name = name;
    }

    public override string Send(string msg)
    {
        Console.WriteLine(_name+": Sending Message="+msg);
        _chat.SendMessage(msg, this);
        return msg;
    }

    public override void Receive(string msg)
    {
        Console.WriteLine(_name+": Received Message:"+msg);
    }
}