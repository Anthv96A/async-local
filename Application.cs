namespace async_local;

public class Application
{
    private readonly IConnectionManager connectionManager;

    public Application(IConnectionManager connectionManager)
    {
        this.connectionManager = connectionManager ?? throw new ArgumentNullException(nameof(connectionManager));
    }

    public async Task RunAsync()
    {
        for(int i = 1; i <= 2; i++) 
        {
            Console.WriteLine($"Test {i}");
            await this.TestAsync();
            Console.WriteLine();
            Console.WriteLine($"After async method test {i}");

            string msg = this.connectionManager.GetCurrentConnection?.ID ?? "not here anymore";
            Console.WriteLine($"Connection ID {msg}");
            Console.WriteLine();
        }
    }

    private async Task TestAsync(int counter = 3) 
    {
        IConnection conn = this.connectionManager.GetConnection();
        Console.WriteLine($"Current Connection ID from manager: {conn.ID}");

        if (counter != 0) 
        {
            counter -= 1;
            await this.TestAsync(counter);
            return;
        }

        conn.Close();
        await Task.CompletedTask;
    }
}
