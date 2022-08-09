namespace async_local;

public interface IConnection : IDisposable
{
    string ID { get; }
    void Open();
    void Close();
}

public class Connection : IConnection
{
    public string ID { get; }

    public Connection()
    {
        this.ID = Guid.NewGuid().ToString();
    }

    public void Close()
    {
        Console.WriteLine($"Closing Conn - {this.ID}");
    }

    public void Dispose()
    {
        this.Close();
    }

    public void Open()
    {
        Console.WriteLine($"Opening new Conn - {this.ID}");
    }
}
