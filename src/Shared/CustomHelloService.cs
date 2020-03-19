namespace Shared
{
    public class CustomHelloService : IHelloService
    {
        public string Say() => "Hello from custom service";
    }
}