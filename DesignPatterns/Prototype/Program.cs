namespace Prototype;

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