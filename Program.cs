using async_local;

namespace async.local;

public static class Program 
{
    static async Task Main(string[] args) 
    {
        try 
        {
            using var manager = new SQLConnectionManager();
            var app = new Application(manager);
            await app.RunAsync();
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}
    



