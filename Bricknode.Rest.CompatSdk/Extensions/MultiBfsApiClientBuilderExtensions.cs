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
            var configurationProvider = new BfsApiConfigurationProvider();
            configurationProvider.AddConfigurations(builder.GetBfsApiConfigurations());
            builder.Services.AddSingleton<IBfsApiConfigurationProvider>(configurationProvider);
        }
    }
}