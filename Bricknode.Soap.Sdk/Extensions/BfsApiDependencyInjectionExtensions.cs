namespace Bricknode.Soap.Sdk.Extensions
{
    using System;
    using System.ServiceModel;
    using BfsApi;
    using Builders;
    using Configuration;
    using Factories;
    using Helpers;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;
    using Services;

    public static class BfsApiDependencyInjectionExtensions
    {
        public static IServiceCollection AddBfsApiClient(this IServiceCollection services,
            Action<BfsApiConfiguration> bfsApiConfiguration)
        {
            services.AddScoped<bfsapiSoap, bfsapiSoapClient>(
                serviceProvider => new bfsapiSoapClient(
                    BfsBinding.GetBfsBinding(),
                    new EndpointAddress(serviceProvider.GetRequiredService<IOptions<BfsApiConfiguration>>().Value
                        .EndpointAddress)
                )
            );

            services.AddScoped<IBfsApiClientFactory, BfsApiClientFactory>();

            services.Configure(bfsApiConfiguration);
            services.AddSingleton(bfsApiConfiguration);

            AddBfsServices(services);

            return services;
        }

        public static IMultiBfsApiClientBuilder AddMultiBfsApiClient(this IServiceCollection services)
        {
            var builder = new MultiBfsApiClientBuilder(services);

            services.AddScoped<bfsapiSoap, bfsapiSoapClient>(provider => new bfsapiSoapClient(bfsapiSoapClient.EndpointConfiguration.bfsapiSoap));
            services.AddOptions();
            AddBfsServices(services);

            return builder;
        }

        private static void AddBfsServices(IServiceCollection services)
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
        }
    }
}