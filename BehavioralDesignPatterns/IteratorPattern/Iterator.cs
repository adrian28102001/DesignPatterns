using BehavioralDesignPatterns.Mediator;

namespace BehavioralDesignPatterns.IteratorPattern;

public class Iterator : IIterator
{
    private readonly StudentEnum _studentName;
    private readonly List<Student> _studentsList;
    private int _position;

    public Iterator(StudentEnum studentName, List<Student> studentsList)
    {
        _studentName = studentName;
        _studentsList = studentsList;
    }

    public bool HasNext()
    {
        while (_position < _studentsList.Capacity)
        {
            var st = _studentsList[_position];
            if (st.Equals(_studentName) || _studentName.Equals(_studentsList))
            {
                return true;
            }

            _position++;
        }

        return false;
    }

    public Student Next()
    {
        var st = _studentsList[_position];
        _position++;
        return st;
    }
}