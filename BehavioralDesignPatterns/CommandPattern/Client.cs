using BehavioralDesignPatterns.Mediator;

namespace BehavioralDesignPatterns.CommandPattern;

public class Client
{
    public static void MainClient(string[] args)
    {
        IStudentChat chat = new StudentChat();
        var msg = "Hi";
        Student student = new NewStudent(chat, " Ana");
        
        ICommand clickSend = new SendMsgCommand(chat,msg, student);
        var commandInvoker = new CommandInvoker(clickSend);

        commandInvoker.ClickSend();

    }
}