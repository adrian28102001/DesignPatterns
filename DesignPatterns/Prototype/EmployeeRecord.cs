namespace Prototype;

public class EmployeeRecord : IPrototype
{
    private readonly int _id;
    private readonly string _name;
    private readonly double _salary;
    private readonly string _address;

    public EmployeeRecord(int id, string name, double salary, string address)
    {
        _id = id;
        _name = name;
        _salary = salary;
        _address = address;
    }

    public IPrototype GetClone()
    {
        return new EmployeeRecord(_id, _name, _salary, _address);
    }

    public void ShowRecord()
    {
        Console.WriteLine($"Teach with id: {_id} and name: {_name} has a salary of: {_salary} at {_address}");
    }
}