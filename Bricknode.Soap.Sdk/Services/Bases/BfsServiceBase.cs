using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using BfsApi;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Bricknode.Soap.Sdk.Services.Bases
{
    using System.Threading.Tasks;
    using Factories;

    public abstract class BfsServiceBase
    {
        private readonly IBfsApiClientFactory _bfsApiClientFactory;
        private readonly ILogger _logger;

        protected BfsServiceBase(IBfsApiClientFactory bfsApiClientFactory, ILogger? logger)
        {
            _bfsApiClientFactory = bfsApiClientFactory;
            _logger = logger ?? NullLogger.Instance;
        }

        protected ValueTask<bfsapiSoap> GetClientAsync(string? bfsApiClientName = null)
        {
            return _bfsApiClientFactory.CreateClientAsync(bfsApiClientName);
        }

        protected async ValueTask<TRequest> GetRequestAsync<TRequest>(string? bfsApiClientName = null)
            where TRequest : Request
        {
            var request = Activator.CreateInstance<TRequest>();
            var configuration = await _bfsApiClientFactory.GetConfigurationAsync(bfsApiClientName);

            request.identify = configuration.Identifier;
            request.Credentials = configuration.Credentials;
            return request;
        }

        protected static T GetFields<T>()
        {
            var fieldClass = Activator.CreateInstance<T>();

            foreach (var property in fieldClass.GetType().GetProperties())
                property.SetValue(fieldClass, true);

            return fieldClass;
        }

        protected static bool ValidateResponse(Response response)
        {
            return response.Message == "OK";
        }

        protected static bool ValidateResponse(ResponseBaseOfFeeRecordDto response)
        {
            return response.Message == "OK";
        }

        protected static bool ValidateResponse(DeleteCustomFieldResponse response)
        {
            return response.Message == "OK";
        }

        protected static bool ValidateResponse(UpdateCustomFieldResponse response)
        {
            return response.Message == "OK";
        }

        protected static bool ValidateResponse(CreateCustomFieldResponse response)
        {
            return response.Message == "OK";
        }

        protected void LogErrors(IEnumerable<EntityBase>? entities, [CallerMemberName] string callerMethodName = "")
        {
            if (entities == null || !entities.Any())
                return;

            var errorMessages = ResolveErrorsInResponse(entities);

            _logger.LogError($"Error in {callerMethodName} with the following error message: {errorMessages}");
        }

        protected void LogErrors(string message, [CallerMemberName] string callerMethodName = "")
        {
            _logger.LogError($"Error in {callerMethodName} with the following error message: {message}");
        }

        protected void LogErrors(IEnumerable<DtoBase>? entities, [CallerMemberName] string callerMethodName = "")
        {
            if (entities == null || !entities.Any())
                return;

            var errorMessages = ResolveErrorsInResponse(entities);

            _logger.LogError($"Error in {callerMethodName} with the following error message: {errorMessages}");
        }

        protected static string ResolveErrorsInResponse(IEnumerable<DtoBase> entities)
        {
            return string.Join(", ", entities.SelectMany(e => e.ErrorMessages));
        }

        protected static string ResolveErrorsInResponse(IEnumerable<EntityBase> entities)
        {
            return string.Join(", ", entities.SelectMany(e => e.Errors));
        }
    }
}