namespace StructuralDesignPatterns.Composite;

public class Accountant : IEmployee
{
    private int _id;  
    private string _name;  
    private double _salary;

    public Accountant(int id, string name, double salary)
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
        //this is leaf node so this method is not applicable to this class.  
    }

    public void Remove(IEmployee employee)
    {
        //this is leaf node so this method is not applicable to this class.  
    }

    public IEmployee GetChild(int i)
    {
         //this is leaf node so this method is not applicable to this class. 
        return null;  
    }

    public void GetEmployee()
    {
        //this is leaf node so this method is not applicable to this class. 
    }
}