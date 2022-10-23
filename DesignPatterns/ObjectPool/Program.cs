namespace ObjectPool;

public class Program
{
    public static void Main(string[] args)
    {
        var factory = new Factory();
        var myStudent1 = factory.GetStudent();
        Console.WriteLine("First object");
        var myStudent2 = factory.GetStudent();
        Console.WriteLine("Second object");
        var myStudent3 = factory.GetStudent();
        Console.WriteLine("Third object");
        Console.Read();
    }
}