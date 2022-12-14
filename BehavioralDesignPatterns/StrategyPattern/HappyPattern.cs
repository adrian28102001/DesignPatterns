namespace BehavioralDesignPatterns.StrategyPattern;

public class HappyPattern : IStrategy
{
    public string SendReactionToMsg(string message)
    {
        Console.Write("Student is happy with this message");
        return message;
    }
}