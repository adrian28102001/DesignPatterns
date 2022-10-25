# Topic: Creational Design Patterns.

## Course: Software design techniques

## Author: Gherman Adrian

# Theory

The best techniques employed by experienced object-oriented software engineers
are represented by design patterns. Design patterns are solutions to common issues
that software developers ran across when creating new applications. Many software
developers over a sizable period of time came up with these solutions through trial and error.

One type of the design pattern that will be implemented in this laboratory work is Creational
Design Pattern. Instead of instantiating objects directly with the new operator, these design
patterns offer a mechanism to generate things while concealing the creation logic.
As a result, the program has more freedom to choose which objects should be created
for a particular use case.

Types of Creational design patterns are:

1. **Factory Method**. A creational design pattern that provides an interface for creating
   objects in a superclass, but allows subclasses to alter the type of objects that will
   be created.
2. **Abstract Factory**. A creational design pattern that lets you produce families
   of related objects without specifying their concrete classes.
3. **Builder**. A creational design pattern that lets you construct complex objects
   step by step. The pattern allows you to produce different types and representations of an object using the same
   construction code.
4. **Prototype**. A creational design pattern that lets you copy existing objects without
   making your code dependent on their classes.
5. **Singleton**. A creational design pattern that lets you ensure that a class has only one instance, while providing a
   global access point to this instance.

# Objectives:

1. Study and understand the Creational Design Patterns.
2. Choose a domain, define its main classes/models/entities and
   choose the appropriate instantiation mechanisms.
3. Use some creational design patterns for object instantiation in a sample project.

# Implementation description

To start with,this project is based on shapes creation. it generates different types
of shapes like sharp(ex: square) and rounded(ex:circle). Further the implementation is based on
how to manipulate with these shapes, starting with their creation and structure changing.

### Factory Method

Firstly the Factory Method was implemented. An abstract class Bill was created with two methods:
CalculateBill() and SetPrice()

```csharp
public abstract class Bill
{
    protected double Price;
    
    public abstract void SetPrice();

    public void CalculateBill(int volume)
    {
        Console.WriteLine(volume * Price);
    }
}
````

Further the abstract class was extended by different classes like GasBill, LightBill and WaterBill.
These classes override the methods in the class. An example of this is provided below, the same
principle is followed also in the rest of classes.

```csharp
   public class GasBill : Bill
{
    public override void SetPrice()
    {
        Price = 20;
    }
}
````

### Abstract Factory

Secondly, the Abstract Factory was implemented. This patterns work around a
super-factory which creates other factories. We are going to use the previously created
Shape interface and concrete classes implementing this interface. Further,
create an abstract class to get factories for Sharp and Rounded Shape Objects.

````
public abstract class AbstractFactory
{
    public abstract Bank GetBank(MoldovianBanks bank);  
    public abstract Loan GetLoan(LoansPurposes loan);  
}
````

We proceed with creating concrete Factory classes extending AbstractFactory interface
with its abstract method to generate object
of concrete class based on given information. For instance, we have RoundedShapeFactory
and SharpShapeFactory.

Bank factory

```csharp
public class BankFactory : AbstractFactory
{
    public override Bank GetBank(MoldovianBanks bank)
    {
        return bank switch
        {
            MoldovianBanks.MobiasBank => new MobiasBank(),
            MoldovianBanks.VictoriaBank => new VictoriaBank(),
            MoldovianBanks.MoldovaAgroinBank => new MAIBBank(),
            _ => null!
        };
    }


    public override Loan GetLoan(LoansPurposes loan)
    {
        return null!;
    }
}

````

Loan factory

```csharp
public class LoanFactory : AbstractFactory
{
    public override Bank GetBank(MoldovianBanks bank)
    {
        return null!;
    }

    public override Loan GetLoan(LoansPurposes loan)
    {
        return loan switch
        {
            LoansPurposes.Home=> new HomeLoan(),
            LoansPurposes.Business=> new BusinessLoan(),
            LoansPurposes.Education=> new EducationLoan(),
            _ => null!
        };
    }
}

````

### Singleton

This pattern involves a single class which is responsible to create an object while making sure that only
single object gets created. For instance the Rectangle class, this class provides a way to access its only object
which can be accessed directly without need to instantiate the object of the class.
SingleObject class provides a static method to get its static instance to outside world.

```csharp
public class LoadBalancer
{
    private static readonly LoadBalancer Instance = new();

    private readonly List<Server> _servers;
    private readonly Random _random = new();

    private LoadBalancer()
    {
        _servers = new List<Server>
        {
            new() {Name = "ServerI", IP = "120.14.220.18"},
            new() {Name = "ServerII", IP = "120.14.220.19"},
            new() {Name = "ServerIII", IP = "120.14.220.20"},
            new() {Name = "ServerIV", IP = "120.14.220.21"},
            new() {Name = "ServerV", IP = "120.14.220.22"},
        };
    }

    public static LoadBalancer GetLoadBalancer()
    {
        return Instance;
    }

    public Server NextServer
    {
        get
        {
            var r = _random.Next(_servers.Count);
            return _servers[r];
        }
    }

````

### Prototype

Prototype pattern refers to creating duplicate object while keeping performance in mind. We are
going to create an interface called IPrototype with its method getClone().

```csharp
public interface IPrototype
{
    public IPrototype GetClone();  
}
````

Further, implementing the interface in a concrete class Rectangle.We created a constructor
with two parameters length and height. To proceed the implemented method return the cloned object
with those parameters.

```csharp
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

````

Here we can observe the cloning process. A clone object rectangle is generated with 2 different
parameters and the new area si computed.

```csharp
public class Program
{
    public static void Main(string[] args)
    {
        var employeeRecord = new EmployeeRecord(1, "Mihai", 10000, "UTM");
        employeeRecord.ShowRecord();
        var secondEmployeeRecord = (EmployeeRecord) employeeRecord.GetClone();
        secondEmployeeRecord.ShowRecord();
    }
}
````

Output:

````
Teach with id: 1 and name: Mihai has a salary of: 10000 at UTM
Teach with id: 1 and name: Mihai has a salary of: 10000 at UTM (clone)
````

### Builder

Builder pattern builds a complex object using simple objects and using a step-by-step approach.
We are going to create an Item interface representing square type items such as big squares or
small squares and concrete classes implementing the Item interface

```csharp
public interface ITem
{
    public string Name();
    public IPacking Packing();
    public float Price();	
}

````

```csharp
public abstract class Burger : ITem
{
    public virtual string Name()
    {
        throw new NotImplementedException();
    }

    public IPacking Packing()
    {
        return new Wrapper();
    }

    public virtual float Price()
    {
        throw new NotImplementedException();
    }
}

````

```csharp
public abstract class ColdDrink : ITem
{
    public virtual string Name()
    {
        throw new NotImplementedException();
    }

    public IPacking Packing()
    {
        return new Bottle();
    }

    public virtual float Price()
    {
        throw new NotImplementedException();
    }
}
````

Further, we are going to create different type of Burger and ColdDrinks

```csharp
public class ChickenBurger : Burger
{
    public override float Price() {
        return 25.0f;
    }
    
    public override string Name() {
        return "Veg Burger";
    }
}

````

```csharp
public class VeganBurger : Burger
{
    public override float Price() {
        return 25.0f;
    }
    
    public override string Name() {
        return "Veg Burger";
    }
}
```

And different types of ColdDrinks

```csharp
public class Coke : ColdDrink
{
    public override float Price()
    {
        return 20.0f;
    }

    public override string Name()
    {
        return "Coke";
    }
}
```

```csharp
public class Pepsi : ColdDrink
{
    public override float Price() {
        return 20.0f;
    }

    public override string Name() {
        return "Pepsi";
    }
}
```

The actual builder class responsible to create objects.

```csharp
public class Meal
{
    private List<ITem> items = new List<ITem>();

    public float GetCost()
    {
        return items.Sum(item => item.Price());
    }
    
    public void showItems(){

        foreach (var item in items)
        {
            Console.Write("Item : " + item.Name());
            Console.Write(", Packing : " + item.Packing().Pack());
            Console.WriteLine(", Price : " + item.Price());
        }
        
    }

    public void AddItem(ITem item)
    {
        items.Add(item);
    }

}

````

```csharp
public class MealBuilder
{
    public Meal PrepareVegMeal (){
        var meal = new Meal();
        meal.AddItem(new VeganBurger());
        meal.AddItem(new Coke());
        return meal;
    }   

    public Meal PrepareNonVegMeal (){
        var meal = new Meal();
        meal.AddItem(new ChickenBurger());
        meal.AddItem(new Pepsi());
        return meal;
    }
}
```

To see the builder pattern the follow the code below.

```csharp
public class Program
{
    public static void Main(string[] args)
    {
        var mealBuilder = new MealBuilder();

        var vegMeal = mealBuilder.PrepareVegMeal();
        Console.WriteLine("Veg Meal");
        vegMeal.showItems();
        Console.WriteLine("Total Cost: " + vegMeal.GetCost());

        var nonVegMeal = mealBuilder.PrepareNonVegMeal();
        Console.WriteLine("Non-Veg Meal");
        nonVegMeal.showItems();
        Console.WriteLine("Total Cost: " + nonVegMeal.GetCost());
    }
}
````

Output:

````
Veg Meal
Item : Veg Burger, Packing : Wrapper, Price : 25
Item : Coke, Packing : Bottle, Price : 20
Total Cost: 45
Non-Veg Meal
Item : Veg Burger, Packing : Wrapper, Price : 25
Item : Pepsi, Packing : Bottle, Price : 20
Total Cost: 45


````

# Conclusion

To sum up, creational design patterns enabling you to discuss a system at a higher
level of abstraction than that of a design notation or programming
language, design patterns make a system appear less difficult.
Just state that design patterns are merely fixes for often occurring issues in software design.