using BehavioralDesignPatterns.StrategyPattern;

namespace BehavioralDesignPatterns.Mediator;

public class MediatorPattern
{
    public static void MainMediator(string[] args)
    {
        IStudentChat chat = new StudentChat();
        Student student1 = new NewStudent(chat, "Ana");
        Student student2 = new NewStudent(chat, "Ina");
        Student student3 = new NewStudent(chat, "Cornel");
        Student student4 = new NewStudent(chat, "Matei");

        chat.AddStudent(student1);
        chat.AddStudent(student2);
        chat.AddStudent(student3);
        chat.AddStudent(student4);

        student2.Send("Hi");
        Console.WriteLine(chat);

        var context = new Context(new HappyPattern());
        Console.WriteLine(student1.Name + " reacted to the message " + context.ExecuteStrategy(student2.Send("Hi")));
    }
}