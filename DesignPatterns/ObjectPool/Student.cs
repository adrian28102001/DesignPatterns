namespace ObjectPool;

public class Student
{
    public static int ObjectCounter = 0;

    public Student(string firstname, string lastname, int rollNumber, string @class)
    {
        _firstname = firstname;
        _lastname = lastname;
        _rollNumber = rollNumber;
        _class = @class;
        ++ObjectCounter;
    }

    private string _firstname;
    private string _lastname;
    private int _rollNumber;
    private string _class;

    public Student()
    {
        throw new NotImplementedException();
    }
}