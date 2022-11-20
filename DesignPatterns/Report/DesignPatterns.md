# Topic: Structural Design Patterns.
## Course: Software design techniques
## Author: Gherman Adrian

# Theory
The best techniques employed by experienced object-oriented software engineers
are represented by design patterns. Design patterns are solutions to common issues
that software developers ran across when creating new applications. Many software
developers over a sizable period of time came up with these solutions through trial and error.

One type of the design pattern that will be implemented in this laboratory work is Structural
Design Pattern. Structural design patterns are concerned with how classes and objects can be composed,
to form larger structures. The structural design patterns simplifies the structure by identifying
the relationships. These patterns focus on, how the classes inherit from each other and how they
are composed of other classes.

Types of Structural design patterns are:
1. **Adapter Pattern**. A structural design pattern that adapts an interface into another according to
   client expectation.
2. **Bridge Pattern**. A structural design pattern that separates abstraction (interface) from implementation.
3. **Composite Pattern**. A structural design pattern that allows clients to operate on hierarchy of objects.
4. **Decorator Pattern**. A structural design pattern that adds functionality to an object dynamically.
5. **Facade Pattern**. A structural design pattern that provides an interface to a set of interfaces.
6. **Flyweight Pattern** . A structural design pattern that reuses an object by sharing it.
7. **Proxy Pattern**. A structural design pattern that is used to represent another object.

# Objectives:
1. Study and understand the Structural Design Patterns.
2. Choose a domain, define its main classes/models/entities and
   choose the appropriate instantiation mechanisms.
3. Use some structural design patterns for object instantiation in a sample project.

# Implementation description
To start with,this project is based on banking system. It is aim to present the structure of bank
and client communication and the services that this provides to its customers .
Further the implementation is based on how to manipulate with these classes, and what relations it could have.


### Adapter Pattern
Firstly the Adapter Pattern was implemented. Adapter is a structural design pattern that allows objects
with incompatible interfaces to collaborate.
To start with, a target interface ICreditCard was created with two methods GiveBankDetails() and GetCreditCard().
This is the desired interface class which will be used by the clients, it describes a protocol that other
classes must follow to be able to collaborate with the client code.

````
public interface ICreditCard
{
    public void GiveBankDetails();  
    public string GetCreditCard();  
}
  
````
Further the adaptee class BankDetails was implemented. This is the class which is used by the Adapter class
to reuse the existing functionality and modify them for desired use.

````
public class BankDetails
{
    private string BankName { get; set; }
    private string AccountHolderName { get; set; }
    private long AccountNumber { get; set; }


    protected string GetBankName()
    {
        return BankName;
    }

    protected string GetAccountHolderName()
    {
        return AccountHolderName;
    }

    protected long GetAccountNumber()
    {
        return AccountNumber;
    }

    protected void SetBankDetails(string bankName, string accountHolderName, long accountNumber)
    {
        BankName = bankName;
        AccountHolderName = accountHolderName;
        AccountNumber = accountNumber;
    }
}

````
We continue by creating the adapter class BankCustomer. This class is a wrapper class which implements
the desired target interface and modifies the specific request available from the Adaptee class.

````
!!!!!!!!!!!!!!adauga te rog adapter class!!!!!!!!!!!!!!!!!!!
````



### Bridge Pattern
Secondly, the Bridge Pattern was implemented. This pattern lets you split a large class or a set of closely
related classes into two separate hierarchies—abstraction and implementation—which can be developed
independently of each other.
To start with, the DataObject interface was created.

````
public abstract class DataObject
{
    public abstract void NextRecord();
    public abstract void PriorRecord();
    public abstract void AddRecord(string name);
    public abstract void DeleteRecord(string name);
    public abstract void ShowRecord();
    public abstract void ShowAllRecords();
}
````
We continue with the implementation of CustomersData class that implements DataObject.

````
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
````
The QuestionManager class will use IQuestionAboutCreditCard interface which will act as a bridge(QuestionManager).

````
public class CustomersBase
{
    private DataObject _dataObject;

    public DataObject Data
    {
        set { _dataObject = value; }
        get { return _dataObject; }
    }

    public void Next()
    {
        _dataObject.NextRecord();
    }

    public void Prior()
    {
        _dataObject.PriorRecord();
    }

    public void Add(string customer)
    {
        _dataObject.AddRecord(customer);
    }

    public void Delete(string customer)
    {
        _dataObject.DeleteRecord(customer);
    }

    public void Show()
    {
        _dataObject.ShowRecord();
    }

    public virtual void ShowAll()
    {
        _dataObject.ShowAllRecords();
    }
}
````
AICI NU STIU CE SA SCRIU XDDD

````
public class Customers : CustomersBase
{
    public override void ShowAll()
    {
        Console.WriteLine();
        Console.WriteLine("------------------------");
        base.ShowAll();
        Console.WriteLine("------------------------");
    }
}

````
### Decorator Pattern
This pattern says that just "attach a flexible additional responsibilities to an object dynamically".
In other words, The Decorator Pattern  lets you attach new behaviors to objects by placing these objects
inside special wrapper objects that contain the behaviors.
The IFood interface was firstly created.

````
public interface IFood
{
    public string PrepareFood();  
    public double FoodPrice();  
}
````

The FoodDecorator class implements the IFood interface and override its all methods.
Now it has the ability to decorate some more food, in our case, for exaple the ChineeseFood .

````
public abstract class FoodDecorator : IFood
{
    private readonly IFood _newFood;

    protected FoodDecorator(IFood newFood)
    {
        _newFood = newFood;
    }

    public string PrepareFood()
    {
        return _newFood.PrepareFood();
    }

    public double FoodPrice()
    {
        return _newFood.FoodPrice();
    }
}
````
Continue with the creation of concrete classes like ChineeseFood that extends the decorator class and override
it's all methods. There is also the NonVegFood class that could be seen in the
same Decorator package.

````
public class ChineseFood : FoodDecorator
{
    private IFood NewFood { get; }
    public ChineseFood(IFood newFood) : base(newFood)
    {
        NewFood = newFood;
    }
    
    public new string PrepareFood()
    {
        return NewFood.PrepareFood() + "ChineseFood";
    }

    public new double FoodPrice()
    {
        return NewFood.FoodPrice() + 250;
    }
}

````
### Facade Pattern
A Facade Pattern is a pattern that provides a simplified interface to a library, a framework,
or any other complex set of classes.

To start with the IMobileShop interface.

````
public interface IMobileShop
{
    public void ModelNo();  
    public void Price();  
}
````

Here two new classes were created the IPhone and the Samsung that implements the IMobileShop interface..

````
public class Iphone : IMobileShop
{
    public void ModelNo()
    {
        Console.WriteLine(" Iphone 6 ");  
    }

    public void Price()
    {
        Console.WriteLine("10000 lei");  

    }
}

````
And the second Samsung concrete class.

````
public class Samsung : IMobileShop
{
    public void ModelNo()
    {
        Console.WriteLine(" S22 Ultra ");  
    }

    public void Price()
    {
        Console.WriteLine("10000 lei");  

    }
}
````
Then the ShopKeeperconcrete class was created and this class uses the IMobileShop interface.

````
public class ShopKeeper
{
    private IMobileShop Iphone;
    private IMobileShop Samsung;

    public ShopKeeper()
    {
        Iphone = new Iphone();
        Samsung = new Samsung();
    }

    public void IphoneSale()
    {
        Iphone.ModelNo();
        Iphone.Price();
    }
    public void SamsungSale()
    {
        Samsung.ModelNo();
        Samsung.Price();
    }
}
````
Now, we could create a client class that can choose which type of mobile phone the client wants
from IMobileShop through a representative as ShopKeeper.

### Composite Pattern
A Composite Pattern says that just "allow clients to operate in generic manner on objects
that may or may not represent a hierarchy of objects".
It defines class hierarchies that contain primitive and complex objects, as well as
makes easier to add new kinds of components.

Firstly, the IEmployee interface for objects in composition. was created. It is treated as a component element.
Its aim is to implement default behavior for the interface common to all classes as appropriate.
````
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
````
Further we create BankManager class that will be treated as a Composite and implements Employee interface.
It implements child related operations in the component interface.

````
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
````
To continue, we created a Cashier class that will be treated as a leaf
and it will implement to the Employee interface. To notice that the leaf has no children.
It defines behavior for primitive objects in the composition.

````
public class Cashier : IEmployee
{
    private readonly int _id;
    private readonly string _name;
    private readonly double _salary;

    public Cashier(int id, string name, double salary)
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

    public void Add(IEmployee employee) {  
        //this is leaf node so this method is not applicable to this class.  
    }

    public void Remove(IEmployee employee)
    {
        //this is leaf node so this method is not applicable to this clas
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
````
We also have an Accountant class that will also be treated as a leaf and it will implement
to the Employee interface.

````
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
```` 

### Conclusion

To sum up, Structural design patterns enabling you to  explain how to assemble objects
and classes into larger structures, while keeping these structures flexible and efficient.
Structural design patterns are concerned with how classes and objects can be composed,
to form larger structures.