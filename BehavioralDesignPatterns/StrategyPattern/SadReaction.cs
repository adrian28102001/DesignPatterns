namespace BehavioralDesignPatterns.StrategyPattern;

public class SadReaction : IStrategy
{
    public string SendReactionToMsg(string message)
    {
        Console.WriteLine("Student is sad with this message");
        return message;
    }
}