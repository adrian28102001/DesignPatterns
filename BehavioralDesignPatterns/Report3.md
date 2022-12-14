# Topic: Behavioral Design Patterns.

## Course: Software design techniques

## Author: Gherman Adrian

# Theory

The best techniques employed by experienced object-oriented software engineers
are represented by design patterns. Design patterns are solutions to common issues
that software developers ran across when creating new applications. Many software
developers over a sizable period of time came up with these solutions through trial and error.

One type of the design pattern that will be implemented in this laboratory work is Behavioral
Design Pattern. Behavioral design patterns is a category of design patterns that focus on
communication between objects. These patterns are used to help objects cooperate and coordinate their
behavior in order to achieve a common goal.
In these design patterns, the interaction between the objects should be in such a way that
they can easily talk to each other and still should be loosely coupled.

Types of Behavioral design patterns are:

1. **Chain of Responsibility Pattern**. A behavioral design pattern where sender sends a request to a chain
   of objects. The request can be handled by any object in the chain.
2. **Command Pattern**. A behavioral design pattern that encapsulates a command request as an object.
3. **Interpreter Pattern**. A behavioral design pattern that is used in a way to include language elements in a program.
4. **Iterator Pattern**. A behavioral design pattern that sequentially access the elements of a collection.
5. **Mediator Pattern**. A behavioral design pattern that defines simplified communication between classes.
6. **Memento Pattern** . A behavioral design pattern that capture and restore an object's internal state.
7. **Observer Pattern**. A behavioral design pattern that is used in a way of notifying change to a number of classes.
8. **State Pattern**. A behavioral design pattern that alter an object's behavior when its state changes.
9. **Strategy Pattern**. A behavioral design pattern that encapsulates an algorithm inside a class.
10. **Template Pattern**. A behavioral design pattern that defer the exact steps of an algorithm to a subclass.
11. **Visitor Pattern**. A behavioral design pattern that defines a new operation to a class without change.
12. **Null Object**. A behavioral design pattern that was designed to act as a default value of an object.

# Objectives:

1. Study and understand the Behavioral Design Patterns.
2. Choose a domain, define its main classes/models/entities and
   choose the appropriate instantiation mechanisms.
3. Use some behavioral design patterns for object instantiation in a sample project.

# Implementation description

To start with,this project is based on student chat manipulation. It is aim to present the structure
of the chat.
Further the implementation is based on how to manipulate with these classes, and what relations it could have.

### Mediator Design Pattern

Firstly, the Mediator Pattern was implemented. This pattern define an object that encapsulates
how a set of objects interact. Mediator promotes loose coupling by keeping objects from
referring to each other explicitly, and it lets you vary their interaction independently.
To start with, a target interface IStudentChat was created with two methods sendMessage() and addStudent().
This is the mediator interface class which will be used further.

```csharp
public interface IStudentChat {
    public void SendMessage(string msg, Student student);
    void AddStudent(Student student);
}
  
````

Further students can send and receive messages, so the Student abstract class was created.
Notice that Student has a reference to the mediator object, it’s required for the communication
between different users.

```csharp
public abstract class Student
{
    private readonly IStudentChat _chat;
    public readonly string Name;
    private IState _state;

    protected Student(IStudentChat chat, string name)
    {
        _chat = chat;
        Name = name;
    }

    public abstract string Send(string msg);

    public abstract void Receive(string msg);


````

We continue by creating the concrete mediator class StudentChat that
implements IStudentChat, it will have a list of students in the
group and provide logic for the communication between them.

```csharp
public class StudentChat : IStudentChat
{
    private readonly List<Student?> _students;

    public StudentChat()
    {
        _students = new List<Student?>();
    }

    public void SendMessage(string msg, Student student)
    {
        foreach (var s in _students)
        {
            s?.Receive(msg);
        }
    }

    public void AddStudent(Student student)
    {
        _students.Add(student);
    }
}
````

Now we can create concrete student classes NewStudent, that will be used by client system.

```csharp
 private readonly IStudentChat _chat;
    private readonly string _name;
    public NewStudent(IStudentChat chat, string name) : base(chat, name)
    {
        _chat = chat;
        _name = name;
    }

    public override string Send(string msg)
    {
        Console.WriteLine(_name+": Sending Message="+msg);
        _chat.SendMessage(msg, this);
        return msg;
    }

    public override void Receive(string msg)
    {
        Console.WriteLine(_name+": Received Message:"+msg);
    }
````

### Command Pattern

Secondly, the Command Pattern was implemented. This pattern encapsulate a request
under an object as a command and pass it to invoker object. Invoker object looks
for the appropriate object which can handle this command and pass the command to
the corresponding object and that object executes the command.

The ICommand interface was created with the execute() method. This interface will act
as a command.

```csharp
public interface ICommand
{
    public void Execute();
}
````

As the Receiver class will be used the Student class implemented earlier.
Next the concrete command sendMsgCommand was created. This implements the ICommand interface
and ovverrides its methods.

```csharp
public class SendMsgCommand : ICommand
{
    private readonly IStudentChat _studentChat;
    private readonly Student _student;
    private readonly string _message;

    public SendMsgCommand(IStudentChat studentChat, string message, Student student)
    {
        _studentChat = studentChat;
        _message = message;
        _student = student;
    }
    public void Execute()
    {
        _studentChat.SendMessage(_message, _student);
    }
}
````

Further, the Invoker class CommandInvoker was implemented.

```csharp
public class CommandInvoker
{
    private ICommand _sendCommand;

    public CommandInvoker(ICommand sendCommand)
    {
        _sendCommand = sendCommand;
    }

    public void ClickSend()
    {
        Console.WriteLine("The message is sent");
    }
}
````

### Iterator Pattern

This pattern is used to access the elements of an aggregate object sequentially without exposing
its underlying implementation. The Iterator pattern is also known as Cursor.

We have already the student class, that generates different students in the chat.
Now we introduce the IStudentCollection interface that has the add and remove methods,
as well as the iterator method that returns the iterator for traversal.

```csharp
public interface IStudentCollection {
    public void AddStudent(Student student);

    public void RemoveStudent(Student student);

    public IIterator Iterator(StudentEnum studentName);
}
````

We introduce the IIterator interface that defines the hasNext() and next() methods.

```csharp
public interface IIterator
{
    public bool HasNext();
    public Student Next();
}
````

Now, that the base interfaces are ready, the core classes are implemented.
Firstly, we have the StudentCollection class, that implements the IStudentCollection
interface with its methods, for adding removing students and the iteration among the
list of those students.

```csharp
public class StudentCollection : IStudentCollection
{
    private readonly List<Student> _studentsList;

    public StudentCollection()
    {
        _studentsList = new List<Student>();
    }

    public void AddStudent(Student student)
    {
        _studentsList.Add(student);
    }

    public void RemoveStudent(Student student)
    {
        _studentsList.Remove(student);
    }

    public IIterator Iterator(StudentEnum studentName)
    {
        return new Iterator(studentName, _studentsList);
    }
````

The Iterator class implements the IIterator interface and its methods.This will let us
iterate through the student list and return the needed student.

```csharp
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
````

### Strategy Pattern

A Strategy Pattern says that just "defines a family of functionality, encapsulate each
one, and make them interchangeable". It provides a substitute to subclassing and
defines each behavior within its own class, eliminating the need for conditional statements.

We started with the creation of the interface Strategy class.

````
public interface IStrategy
{
    public string SendReactionToMsg(string message);
}
````

Then the SadStrategy and HappyStrategy classes were crated. Each class implements the Strategy
interface with its methods.

````
public class SadReaction : IStrategy
{
    public string SendReactionToMsg(string message)
    {
        Console.WriteLine("Student is sad with this message");
        return message;
    }
}
````

Create a Context class that will ask from Strategy interface to execute the type of strategy.

```csharp
public class Context
{
    private readonly IStrategy _strategy;

    public Context(IStrategy strategy)
    {
        _strategy = strategy;
    }

    public string ExecuteStrategy(string message)
    {
        return _strategy.SendReactionToMsg(message);
    }
````

Having the implementation of the strategy pattern, the students will be able to react to the message
sent by others, using either the happy reaction or the sad one.

````
Ina: Sending Message: Hi
Ana reacted to the message Hi
Student is happy with this message
````

### State Pattern

A State Pattern says that "the class behavior changes based on its state".
In State Pattern, we create objects which
represent various states and a context object whose behavior varies as its state object changes.

Firstly, the IState interface was created, with send() and receive() methods.

```csharp
public interface IState
{
    void Send(string message);
    void Receive(string message);
}
````

Further we create the OffLine and OnLine classes that implements this interface.
The State interface defines the common interface for different states, and the
OffLine and OnLine classes are concrete implementations of this interface that define
the behavior for the corresponding states. This allows the behavior of a Student object to
be changed depending on its state.

```csharp
  private readonly Student _student;

    public OffLine(Student student)
    {
        _student = student;
    }

    public void Send(string message)
    {
      Console.WriteLine(_student.GetName() + "is not logged in and cannot send messages");
    }

    public void Receive(string message)
    {
        Console.WriteLine(_student.GetName() + "is not logged in and cannot send messages");
    }
}
````

The State interface defines send() and receive() methods that are used to send and receive
messages in the chat room. These methods are implemented by the OffLine and OnLine classes,
which define the behavior for the corresponding states. For example,
the OffLine class does not allow the student to send and receive messages,
while the OnLine class does.

```csharp
public class OnLine : IState
{
    private readonly Student _student;

    public OnLine(Student student){
        _student = student;
    }
    
    public void Send(string message)
    {
        Console.WriteLine(_student.GetName() + ": Sending Message: " + message);
        _student.GetMediator().SendMessage(message, _student);
    }

    public void Receive(string message)
    {
        Console.WriteLine(_student.GetName() + ": Received Message: " + message);
    }
}

````

Finally, when a student is online the Student object sets its state to OnLine,
and when he is offline its state is OffLine.
This allows the behavior of the Student object to be changed depending on its state.

````
Ana is currently OnLine
````

### Conclusion

To sum up, Behavioral design patterns are concerned with the interaction and responsibility of objects.
These design patterns call for the interaction of the items to be loosely
connected while still allowing for easy communication between them.