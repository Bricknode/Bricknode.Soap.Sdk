namespace Bricknode.Soap.Sdk.Factories;

using System;
using System.Collections.Concurrent;
using System.Net.Http;
using System.Reflection;
using Configuration;

/// <summary>
/// Builds the NSwag-generated REST resource clients (e.g. <c>AccountsClient</c>).
/// Every generated client exposes a <c>(HttpClient)</c> constructor and a settable
/// <c>BaseUrl</c> property, so we configure them generically via reflection.
/// </summary>
internal static class RestResourceClientActivator
{
    private static readonly ConcurrentDictionary<Type, PropertyInfo> BaseUrlProperties = new();

    public static TClient Create<TClient>(HttpClient httpClient, BfsApiConfiguration configuration)
        where TClient : class
    {
        var client = (TClient)Activator.CreateInstance(typeof(TClient), httpClient)!;

        if (!string.IsNullOrWhiteSpace(configuration.EndpointAddress))
        {
            var baseUrlProperty = BaseUrlProperties.GetOrAdd(
                typeof(TClient),
                static type => type.GetProperty("BaseUrl", BindingFlags.Public | BindingFlags.Instance)!);

            baseUrlProperty?.SetValue(client, configuration.EndpointAddress);
        }

        return client;
    }
}
