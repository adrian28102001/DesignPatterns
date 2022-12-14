namespace BehavioralDesignPatterns.CommandPattern;

public class CommandInvoker
{
    private ICommand _sendCommand;

    public CommandInvoker(ICommand sendCommand)
    {
        _sendCommand = sendCommand;
    }

    public void ClickSend()
    {
        Console.WriteLine("The message is sent");
    }
}