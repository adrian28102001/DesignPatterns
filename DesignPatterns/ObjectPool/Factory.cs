using System.Collections;

namespace ObjectPool;

public class Factory
{
    private const int PoolMaxSize = 3;

    // My Collection Pool
    private static readonly Queue ObjPool = new Queue(PoolMaxSize);

    public Student GetStudent()
    {
        Student student;
        if (Student.ObjectCounter >= PoolMaxSize &&
            ObjPool.Count > 0)
        {
            student = RetrieveFromPool();
        }
        else
        {
            student = GetNewStudent();
        }

        return student;
    }

    private Student GetNewStudent()
    {
        var oStu = new Student("Adrian", "Gherman", 1, "Class");
        ObjPool.Enqueue(oStu);
        return oStu;
    }

    private Student RetrieveFromPool()
    {
        Student student;
        if (ObjPool.Count > 0)
        {
            student = (Student) ObjPool.Dequeue()!;
            Student.ObjectCounter--;
        }
        else
        {
            student = new Student();
        }

        return student;
    }
}