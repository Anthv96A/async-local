namespace async_local;

public interface IConnectionManager : IDisposable 
{
    public IConnection GetCurrentConnection { get; }
    
    IConnection GetConnection();
}

public class SQLConnectionManager : IConnectionManager
{
    private static AsyncLocal<IConnection> connection = new AsyncLocal<IConnection>();

    public IConnection GetCurrentConnection { get => connection.Value; set => connection.Value = value; }

    public IConnection GetConnection()
    {
        if (this.GetCurrentConnection != null) 
        {
            Console.WriteLine($"Existing Connection {this.GetCurrentConnection.ID}");
            return this.GetCurrentConnection;
        }

        var connection = new Connection();
        Console.WriteLine($"New connection {connection.ID}");

        connection.Open();

        this.GetCurrentConnection = connection;
        
        return connection;
    }

    public void Dispose()
    {
        Console.WriteLine("sql connection manager disposed");
    }
}
