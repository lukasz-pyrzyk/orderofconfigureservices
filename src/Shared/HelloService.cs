namespace Shared
{
    public class HelloService : IHelloService
    {
        public string Say() => "Hello from original service";
    }
}