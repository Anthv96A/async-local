namespace async_local
{
    public class Application
    {
        private readonly IConnectionManager connectionManager;
        public Application(IConnectionManager connectionManager)
        {
            this.connectionManager = connectionManager ?? throw new ArgumentNullException(nameof(connectionManager));
        }

        public async Task RunAsync()
        {
            Console.WriteLine("Test 1");
            await this.Test();
            Console.WriteLine();
            Console.WriteLine("After async method test 1");

            string msg = this.connectionManager.GetCurrentConnection?.ID ?? "not here anymore";
            Console.WriteLine($"Connection ID {msg}");
            Console.WriteLine();


            Console.WriteLine("Test 2");
            await this.Test();
            Console.WriteLine();
            Console.WriteLine("After async method test 2");

            string msg2 = this.connectionManager.GetCurrentConnection?.ID ?? "not here anymore";
            Console.WriteLine($"Connection ID {msg2}");
        }

        private async Task Test(int counter = 3) 
        {
            var conn = this.connectionManager.GetConnection();
            Console.WriteLine($"get conn ID {conn.ID}");

            var current = this.connectionManager.GetCurrentConnection;
            Console.WriteLine($"get manager ID {conn.ID}");

            if (counter != 0) 
            {
                counter -= 1;
                await this.Test(counter);
                return;
            }

            conn.Close();
            await Task.CompletedTask;
        }
    }
}