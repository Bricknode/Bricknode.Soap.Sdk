using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using BfsApi;
using Bricknode.Soap.Sdk.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

namespace Bricknode.Soap.Sdk.Services.Bases
{
    using Factories;

    public abstract class BfsServiceBase
    {
        protected static BfsApiConfiguration _bfsApiConfiguration;
        protected ILogger _logger;
        protected IBfsApiClientFactory _bfsApiClientFactory;
        protected bfsapiSoap Client;

        protected BfsServiceBase(IOptions<BfsApiConfiguration> bfsApiConfiguration, ILogger logger, IBfsApiClientFactory bfsApiClientFactory, bfsapiSoap client)
        {
            _bfsApiConfiguration = bfsApiConfiguration.Value;
            _logger = logger ?? NullLogger.Instance;
            _bfsApiClientFactory = bfsApiClientFactory;
            Client = client;
        }

        protected bfsapiSoap GetClient(string bfsApiClientName = null)
        {
            if (string.IsNullOrWhiteSpace(bfsApiClientName))
                return Client;

            return _bfsApiClientFactory.CreateClient(bfsApiClientName).Client;
        }

        protected T GetRequest<T>(string bfsApiClientName = null) where T : Request
        {
            var request = Activator.CreateInstance<T>();

            if (string.IsNullOrWhiteSpace(bfsApiClientName))
            {
                request.identify = _bfsApiConfiguration.Identifier;
                request.Credentials = _bfsApiConfiguration.Credentials;
            }
            else
            {
                var bfsApiConfiguration = _bfsApiClientFactory.CreateClient(bfsApiClientName).BfsApiConfiguration;
                request.identify = bfsApiConfiguration.Identifier;
                request.Credentials = bfsApiConfiguration.Credentials;
            }

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

        protected void LogErrors(IEnumerable<EntityBase> entities, [CallerMemberName] string callerMethodName = "")
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

        protected void LogErrors(IEnumerable<DtoBase> entities, [CallerMemberName] string callerMethodName = "")
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