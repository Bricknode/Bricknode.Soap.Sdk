namespace Bricknode.Soap.Sdk.Extensions
{
    using System;
    using Builders;
    using Configuration;
    using Factories;
    using Microsoft.Extensions.DependencyInjection;

    public static class MultiBfsApiClientBuilderExtensions
    {
        public static IMultiBfsApiClientBuilder AddNamedBfsApiClient(this IMultiBfsApiClientBuilder builder,
            string bfsApiClientName, Action<BfsApiConfiguration> bfsApiConfiguration)
        {
            var configuration = new BfsApiConfiguration();
            bfsApiConfiguration(configuration);

            builder.AddBfsApiConfiguration(bfsApiClientName, configuration);

            return builder;
        }

        public static void BuildClients(this IMultiBfsApiClientBuilder builder)
        {
            var bfsApiClientFactory = new BfsApiClientFactory();
            bfsApiClientFactory.AddConfigurations(builder.GetBfsApiConfigurations());

            builder.Services.AddSingleton<IBfsApiClientFactory, BfsApiClientFactory>(provider => bfsApiClientFactory);
        }
    }
}