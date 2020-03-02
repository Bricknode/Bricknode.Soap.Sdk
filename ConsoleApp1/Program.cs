using System;

namespace ConsoleApp1
{
    using BfsApi;
    using Bricknode.Soap.Sdk.Extensions;
    using Bricknode.Soap.Sdk.Factories;
    using Bricknode.Soap.Sdk.Services;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddLogging();
            var serviceProvider = services.BuildServiceProvider();
            var logger = serviceProvider.GetService<ILogger<Program>>();
            services.AddSingleton(typeof(ILogger), logger);

            services.AddMultiBfsApiClient()
                .AddNamedBfsApiClient("name1", configuration =>
                {
                    configuration.EndpointAddress = "https://bfs1.bricknode.com/test/api/bfsapi.asmx";
                    configuration.Credentials = new Credentials
                    {
                        UserName = "test1",
                        Password = "test1"
                    };
                }).AddNamedBfsApiClient("name2", configuration =>
                {
                    configuration.EndpointAddress = "https://bfs1.bricknode.com/test/api/bfsapi.asmx";
                    configuration.Credentials = new Credentials
                    {
                        UserName = "test2",
                        Password = "test2"
                    };
                })
                .BuildClients();

            var provider = services.BuildServiceProvider();
            var factory = provider.GetRequiredService<IBfsApiClientFactory>();

            var client1 = factory.CreateClient("name1");
            var client2 = factory.CreateClient("name2");

            var accountService = provider.GetService<IBfsAccountService>();
            
            accountService.GetAccountsAsync(new GetAccountsArgs(), "name1").GetAwaiter().GetResult();
            accountService.GetAccountsAsync(new GetAccountsArgs(), "name2").GetAwaiter().GetResult();

        }
    }
}
