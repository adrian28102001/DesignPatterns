namespace StructuralDesignPatterns.Composite;

public class BankManager : IEmployee
{
    private int _id;
    private String _name;
    private double _salary;
    private List<IEmployee> _employees = new();  
    
    public BankManager(int id, string name, double salary)
    {
        _id = id;
        _name = name;
        _salary = salary;
    }

    public int GetId()
    {
        return _id;
    }

    public string GetName()
    {
        return _name;
    }

    public double GetSalary()
    {
        return _salary;
    }

    public void Print()
    {
        Console.WriteLine("==========================");  
        Console.WriteLine("Id ="+GetId());  
        Console.WriteLine("Name =" + GetName());  
        Console.WriteLine("Salary =" + GetSalary());  
        Console.WriteLine("==========================");  
    }

    public void Add(IEmployee employee)
    {
        _employees.Add(employee);
    }

    public void Remove(IEmployee employee)
    {
        _employees.Remove(employee);
    }

    public IEmployee GetChild(int i)
    {
        return _employees[i];  
    }

    public void GetEmployee()
    {
        foreach (var employee in _employees)
        {
            employee.Print();;
        }
    }
}