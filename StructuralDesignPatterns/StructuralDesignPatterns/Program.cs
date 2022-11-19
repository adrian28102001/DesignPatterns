using StructuralDesignPatterns.Adapter;
using StructuralDesignPatterns.Bridge;
using StructuralDesignPatterns.Composite;

namespace StructuralDesignPatterns;

public static class Program
{
    private static void AdapterMain()
    {
        ICreditCard creditCard = new BankCustomer();
        creditCard.GiveBankDetails();
        Console.WriteLine(creditCard.GetCreditCard());
    }

    private static void BridgeMain()
    {
        var customers = new Customers
        {
            Data = new CustomersData("Chicago")
        };

        customers.Show();
        customers.Next();
        customers.Show();
        customers.Next();
        customers.Show();
        customers.Add("Henry Velasquez");
        customers.ShowAll();

        Console.ReadKey();
    }

    private static void CompositePattern()
    {
        IEmployee emp1 = new Cashier(101, "Sohan Kumar", 20000.0);
        IEmployee emp2 = new Cashier(102, "Mohan Kumar", 25000.0);
        IEmployee emp3 = new Accountant(103, "Seema Mahiwal", 30000.0);
        IEmployee manager1 = new BankManager(100, "Ashwani Rajput", 100000.0);

        manager1.Add(emp1);
        manager1.Add(emp2);
        manager1.Add(emp3);
        manager1.GetEmployee();
    }

    public static void Main(string[] args)
    {
        // AdapterMain();
        // BridgeMain();
        CompositePattern();
    }
}