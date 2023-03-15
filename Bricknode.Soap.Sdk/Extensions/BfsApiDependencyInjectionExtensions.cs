namespace Bricknode.Soap.Sdk.Extensions
{
    using System;
    using System.Collections.Generic;
    using Bricknode.Soap.Sdk.Builders;
    using Configuration;
    using Factories;
    using Microsoft.Extensions.DependencyInjection;
    using Services;

    public static class BfsApiDependencyInjectionExtensions
    {
        public static IServiceCollection AddBfsApiClient(
            this IServiceCollection services,
            Action<BfsApiConfiguration> configureAction)
        {
            services.AddSingleton<IBfsApiClientFactory>(new SingleBfsClientFactory(configureAction));
            AddBfsServices(services);
            return services;
        }

        public static IServiceCollection AddBfsApiClients(
            this IServiceCollection services,
            Func<IDictionary<string, BfsApiConfiguration>> configureFactory)
        {
            services.AddSingleton<IBfsApiConfigurationProvider>(_ => new BfsApiConfigurationProvider(configureFactory()));
            services.AddScoped<IBfsApiClientFactory, BfsApiClientFactory>();
            AddBfsServices(services);
            return services;
        }

        public static IServiceCollection AddBfsApiClients(
            this IServiceCollection services,
            Func<IServiceProvider, IBfsApiConfigurationProvider> providerFactory)
        {
            services.AddSingleton<IBfsApiConfigurationProvider>(providerFactory);
            services.AddScoped<IBfsApiClientFactory, BfsApiClientFactory>();
            AddBfsServices(services);
            return services;
        }

        [Obsolete($"The usage of {nameof(IMultiBfsApiClientBuilder)} is deprecated, please migrate to {nameof(AddBfsServices)} or for more flexibility you can create a custom implementation of {nameof(IBfsApiConfigurationProvider)}. {nameof(IMultiBfsApiClientBuilder)} will be removed in a future release.")]
        public static IMultiBfsApiClientBuilder AddMultiBfsApiClient(this IServiceCollection services)
        {
            var builder = new MultiBfsApiClientBuilder(services);

            services.AddScoped<IBfsApiClientFactory, BfsApiClientFactory>();
            AddBfsServices(services);

            return builder;
        }

        public static IServiceCollection AddBfsServices(this IServiceCollection services)
        {
            services.AddTransient<IBfsLegalEntitiesService, BfsLegalEntitiesService>();
            services.AddTransient<IBfsAccountService, BfsAccountService>();
            services.AddTransient<IBfsAssetService, BfsAssetService>();
            services.AddTransient<IBfsAllocationProfileService, BfsAllocationProfileService>();
            services.AddTransient<IBfsAuthenticationService, BfsAuthenticationService>();
            services.AddTransient<IBfsBankIdService, BfsBankIdService>();
            services.AddTransient<IBfsCurrencyService, BfsCurrencyService>();
            services.AddTransient<IBfsFileService, BfsFileService>();
            services.AddTransient<IBfsDealService, BfsDealService>();
            services.AddTransient<IBfsTrsService, BfsTrsService>();
            services.AddTransient<IBfsInstructionService, BfsInstructionService>();
            services.AddTransient<IBfsInsuranceService, BfsInsuranceService>();
            services.AddTransient<IBfsOrderService, BfsOrderService>();
            services.AddTransient<IBfsPositionService, BfsPositionService>();
            services.AddTransient<IBfsPowerOfAttorneyService, BfsPowerOfAttorneyService>();
            services.AddTransient<IBfsPriceService, BfsPriceService>();
            services.AddTransient<IBfsTransactionService, BfsTransactionService>();
            services.AddTransient<IBfsBusinessEventService, BfsBusinessEventService>();
            services.AddTransient<IBfsTransferReceiverService, BfsTransferReceiverService>();
            services.AddTransient<IBfsWhiteLabelService, BfsWhiteLabelService>();
            services.AddTransient<IBfsTaskService, BfsTaskService>();
            services.AddTransient<IBfsNoteService, BfsNoteService>();
            services.AddTransient<IBfsMessageService, BfsMessageService>();
            services.AddTransient<IBfsReservationService, BfsReservationService>();
            services.AddTransient<IBfsTransactionNoteService, BfsTransactionNoteService>();
            services.AddTransient<IBfsTaxService, BfsTaxService>();
            services.AddTransient<IBfsCountryService, BfsCountryService>();
            services.AddTransient<IBfsWebhookService, BfsWebhookService>();
            services.AddTransient<IBfsFeeManagerService, BfsFeeManagerService>();
            services.AddTransient<IBfsCustomFieldService, BfsCustomFieldService>();
            return services;
        }
    }
}