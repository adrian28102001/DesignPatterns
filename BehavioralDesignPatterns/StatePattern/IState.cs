namespace BehavioralDesignPatterns.StatePattern;

public interface IState
{
    void Send(string message);
    void Receive(string message);
}