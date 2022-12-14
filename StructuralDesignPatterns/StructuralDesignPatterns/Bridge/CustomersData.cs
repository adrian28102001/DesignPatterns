namespace StructuralDesignPatterns.Bridge;

public class CustomersData : DataObject
{
    private readonly List<string> _customers = new();
    private int _current;
    private readonly string _city;

    public CustomersData(string city)
    {
        _city = city;
        _customers.Add("Jim Jones");
        _customers.Add("Samual Jackson");
        _customers.Add("Allen Good");
        _customers.Add("Ann Stills");
        _customers.Add("Lisa Giolani");
    }

    public override void NextRecord()
    {
        if (_current <= _customers.Count - 1)
        {
            _current++;
        }
    }

    public override void PriorRecord()
    {
        if (_current > 0)
        {
            _current--;
        }
    }

    public override void AddRecord(string customer)
    {
        _customers.Add(customer);
    }

    public override void DeleteRecord(string customer)
    {
        _customers.Remove(customer);
    }

    public override void ShowRecord()
    {
        Console.WriteLine(_customers[_current]);
    }

    public override void ShowAllRecords()
    {
        Console.WriteLine("Customer City: " + _city);
        foreach (var customer in _customers)
        {
            Console.WriteLine(" " + customer);
        }
    }
}