namespace StructuralDesignPatterns.Bridge;

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