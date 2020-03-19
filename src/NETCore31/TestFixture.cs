using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NETCore31WebApp;
using Shared;
using Xunit;

namespace NETCore31
{
    public class TestFixture : IntegrationTests<Startup>
    {
        [Fact]
        public void SayHallo()
        {
            var service = Services.GetService<IHelloService>();
            Assert.Equal("Hello from custom service", service.Say());
        }

        protected override void ConfigureServices(IServiceCollection services)
        {
            services.TryAddSingleton<IHelloService, CustomHelloService>();
        }
    }
}
