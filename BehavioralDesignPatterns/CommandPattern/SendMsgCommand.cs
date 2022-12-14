using BehavioralDesignPatterns.Mediator;

namespace BehavioralDesignPatterns.CommandPattern;

public class SendMsgCommand : ICommand
{
    private readonly IStudentChat _studentChat;
    private readonly Student _student;
    private readonly string _message;

    public SendMsgCommand(IStudentChat studentChat, string message, Student student)
    {
        _studentChat = studentChat;
        _message = message;
        _student = student;
    }
    public void Execute()
    {
        _studentChat.SendMessage(_message, _student);
    }
}