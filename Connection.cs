namespace async_local
{
    public interface IConnection : IDisposable
    {
        public string ID { get; }
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
            Console.WriteLine($"Closing conn - {this.ID}");
        }

        public void Dispose()
        {
            this.Close();
        }

        public void Open()
        {
            Console.WriteLine($"Opening conn - {this.ID}");
        }
    }
}