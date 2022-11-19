namespace StructuralDesignPatterns.Composite;

public interface IEmployee
{
    public int GetId();  
    public string GetName();  
    public double GetSalary();  
    public void Print();  
    public void Add(IEmployee employee);  
    public void Remove(IEmployee employee);  
    public IEmployee GetChild(int i);
    void GetEmployee();
}