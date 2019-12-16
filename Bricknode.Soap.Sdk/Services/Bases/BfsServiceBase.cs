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
    public abstract class BfsServiceBase
    {
        protected static BfsApiConfiguration _bfsApiConfiguration;
        protected ILogger _logger;

        protected BfsServiceBase(IOptions<BfsApiConfiguration> bfsApiConfiguration, ILogger logger)
        {
            _bfsApiConfiguration = bfsApiConfiguration.Value;
            _logger = logger ?? NullLogger.Instance;
        }

        protected static T GetRequest<T>() where T : Request
        {
            var request = Activator.CreateInstance<T>();

            request.identify = _bfsApiConfiguration.Identifier;
            request.Credentials = _bfsApiConfiguration.Credentials;

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

        protected void LogErrors(IEnumerable<EntityBase> entities, [CallerMemberName] string callerMethodName = "")
        {
            var errorMessages = ResolveErrorsInResponse(entities);

            _logger.LogError($"Error in {callerMethodName} with the following error message: {errorMessages}");
        }

        protected void LogErrors(string message, [CallerMemberName] string callerMethodName = "")
        {
            _logger.LogError($"Error in {callerMethodName} with the following error message: {message}");
        }

        protected static string ResolveErrorsInResponse(IEnumerable<EntityBase> entities)
        {
            return string.Join(", ", entities.SelectMany(e => e.Errors));
        }
    }
}