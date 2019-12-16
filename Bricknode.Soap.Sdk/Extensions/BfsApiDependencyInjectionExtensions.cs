using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using BfsApi;
using Bricknode.Soap.Sdk.Configuration;
using Bricknode.Soap.Sdk.Helpers;
using Bricknode.Soap.Sdk.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Bricknode.Soap.Sdk.Extensions
{
    public static class BfsApiDependencyInjectionExtensions
    {
        public static IServiceCollection AddBfsApiClient(this IServiceCollection services, Action<BfsApiConfiguration> bfsApiConfiguration)
        {
            services.AddTransient<bfsapiSoap, bfsapiSoapClient>(
                serviceProvider => new bfsapiSoapClient(
                    BfsBinding.GetBfsBinding(),
                    new EndpointAddress(serviceProvider.GetRequiredService<IOptions<BfsApiConfiguration>>().Value
                        .EndpointAddress)
                )
            );

            services.Configure(bfsApiConfiguration);
            services.AddSingleton(bfsApiConfiguration);
            services.AddTransient<IBfsLegalEntitiesService, BfsLegalEntitiesService>();
            services.AddTransient<IBfsAccountService, BfsAccountService>();
            services.AddTransient<IBfsAllocationProfileService, BfsAllocationProfileService>();
            services.AddTransient<IBfsAccountService, BfsAccountService>();
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

            return services;
        }
    }
}
