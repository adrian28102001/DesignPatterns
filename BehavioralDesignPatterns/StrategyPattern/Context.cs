namespace BehavioralDesignPatterns.StrategyPattern;

public class Context
{
    private readonly IStrategy _strategy;

    public Context(IStrategy strategy)
    {
        _strategy = strategy;
    }

    public string ExecuteStrategy(string message)
    {
        return _strategy.SendReactionToMsg(message);
    }
}