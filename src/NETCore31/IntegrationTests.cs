using System;
using System.IO;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;

namespace NETCore31
{
    public abstract class IntegrationTests<TStartup> : IDisposable where TStartup : class
    {
        private readonly WebApplicationFactory<TStartup> _factory;

        protected IntegrationTests() : this(typeof(TStartup).Assembly.GetName().Name)
        {
        }

        protected IntegrationTests(string projectRelativePath)
        {
            _factory = new WebApplicationFactory<TStartup>().WithWebHostBuilder(b =>
            {
                b
                    .UseSolutionRelativeContentRoot(Path.Combine("src", projectRelativePath))
                    .ConfigureServices(ConfigureServices);
            });

            Services = _factory.Services;
        }
        
        protected IServiceProvider Services { get; }

        protected virtual void ConfigureServices(IServiceCollection services)
        {
        }

        public void Dispose()
        {
            _factory.Dispose();
        }
    }
}