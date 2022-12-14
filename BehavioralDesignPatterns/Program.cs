using BehavioralDesignPatterns.Mediator;

namespace BehavioralDesignPatterns;

public class Program
{
    public static void Main(string[] args)
    {
        IStudentChat chat = new StudentChat();

        Student student1 = new NewStudent(chat, "Ana");
        Student student2 = new NewStudent(chat, "Ina");

        chat.AddStudent(student1);
        chat.AddStudent(student2);

        student1.OnLine();
        student2.OffLine();

        Console.WriteLine(student1.GetName() + " is currently " + student1.GetState());
    }
}