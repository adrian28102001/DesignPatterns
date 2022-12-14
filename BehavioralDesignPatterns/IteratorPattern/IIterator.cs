using BehavioralDesignPatterns.Mediator;

namespace BehavioralDesignPatterns.IteratorPattern;

public interface IIterator
{
    public bool HasNext();
    public Student Next();
}