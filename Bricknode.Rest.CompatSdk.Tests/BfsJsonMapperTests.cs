using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using BfsApi;
using CompatSdkTests.TestSupport;
using Bricknode.Soap.Sdk.Mapping;
using Xunit;
using Xunit.Abstractions;
using RestApi = global::Bricknode.Rest.CompatSdk;

namespace CompatSdkTests;

/// <summary>
/// Validates the JSON-bridge mapper used by the REST compat layer:
/// SOAP-shaped <c>BfsApi.*</c> DTOs must survive a SOAP -&gt; REST -&gt; SOAP round-trip unchanged.
/// </summary>
public class BfsJsonMapperTests
{
    private readonly ITestOutputHelper _output;

    public BfsJsonMapperTests(ITestOutputHelper output)
    {
        _output = output;
    }

    // ---- Diagnostic: which BfsApi request/response types have NO REST counterpart? ----
    // These are SOAP operations that cannot be ported by name as-is (the REST op may be absent,
    // renamed, or merged). Informational only - stays green; writes the list to a file artifact.

    [Fact]
    public void Report_Soap_RequestResponse_Types_Without_Rest_Counterpart()
    {
        var assembly = typeof(RestApi.AccountsClient).Assembly;
        var restNames = RestTypeNames(assembly);

        var soapTypes = SoapRequestResponseTypes(assembly).ToList();
        var unmatched = soapTypes
            .Where(t => !restNames.Contains(t.Name))
            .Select(t => t.Name)
            .OrderBy(n => n, StringComparer.Ordinal)
            .ToList();

        var matchedCount = soapTypes.Count - unmatched.Count;

        var report =
            $"BfsApi request/response types: {soapTypes.Count} total, " +
            $"{matchedCount} matched to a REST type, {unmatched.Count} unmatched.\n" +
            "Unmatched (no REST type with the same name):\n" +
            (unmatched.Count == 0 ? "  (none)" : string.Join("\n", unmatched.Select(n => "  " + n)));

        _output.WriteLine(report);

        var path = Path.Combine(AppContext.BaseDirectory, "unmatched-soap-request-response.txt");
        File.WriteAllText(path, report);
        _output.WriteLine("Written to: " + path);
    }

    // ---- Round-trip fidelity for EVERY BfsApi request/response with a REST counterpart ----
    // SOAP -> REST -> SOAP must "look the same". Data-driven so new types are covered automatically.

    [Theory]
    [MemberData(nameof(RequestResponsePairs))]
    public void RequestResponse_RoundTrips(TypePair pair)
    {
        var original = ObjectFiller.Create(pair.Soap);
        Assert.NotNull(original);

        var rest = MapDynamic(original!, pair.Rest);
        Assert.NotNull(rest);

        var roundTripped = MapDynamic(rest!, pair.Soap);
        Assert.NotNull(roundTripped);
        Assert.NotNull(original);

        JsonEquivalence.AssertEquivalent(original, roundTripped);
        Assert.NotEqual(original, roundTripped);
    }

    public static IEnumerable<object[]> RequestResponsePairs()
    {
        var assembly = typeof(RestApi.AccountsClient).Assembly;

        var restByName = assembly.GetTypes()
            .Where(t => t.Namespace == "Bricknode.Rest.CompatSdk" && t.IsPublic && !t.IsAbstract)
            .GroupBy(t => t.Name)
            .ToDictionary(g => g.Key, g => g.First(), StringComparer.Ordinal);

        foreach (var soap in SoapRequestResponseTypes(assembly))
        {
            if (restByName.TryGetValue(soap.Name, out var rest))
                yield return new object[] { new TypePair(soap, rest) };
        }
    }

    private static IEnumerable<Type> SoapRequestResponseTypes(Assembly assembly) =>
        assembly.GetTypes()
            .Where(t => t.Namespace == "BfsApi" && t.IsPublic && t.IsClass && !t.IsAbstract)
            .Where(t => t.Name.EndsWith("Request", StringComparison.Ordinal) ||
                        t.Name.EndsWith("Response", StringComparison.Ordinal))
            .OrderBy(t => t.Name, StringComparer.Ordinal);

    private static HashSet<string> RestTypeNames(Assembly assembly) =>
        assembly.GetTypes()
            .Where(t => t.Namespace == "Bricknode.Rest.CompatSdk" && t.IsPublic && !t.IsAbstract)
            .Select(t => t.Name)
            .ToHashSet(StringComparer.Ordinal);

    private static object? MapDynamic(object source, Type targetType)
    {
        var map = typeof(BfsJsonMapper)
            .GetMethod(nameof(BfsJsonMapper.Map), BindingFlags.Public | BindingFlags.Static)!
            .MakeGenericMethod(targetType);

        return map.Invoke(null, new[] { source });
    }

    /// <summary>Serializable (for xUnit) pair of matched SOAP/REST types with a readable test name.</summary>
    public sealed class TypePair : IXunitSerializable
    {
        public Type Soap { get; private set; } = null!;
        public Type Rest { get; private set; } = null!;

        public TypePair() { }

        public TypePair(Type soap, Type rest)
        {
            Soap = soap;
            Rest = rest;
        }

        public void Deserialize(IXunitSerializationInfo info)
        {
            Soap = Type.GetType(info.GetValue<string>("soap"))!;
            Rest = Type.GetType(info.GetValue<string>("rest"))!;
        }

        public void Serialize(IXunitSerializationInfo info)
        {
            info.AddValue("soap", Soap.AssemblyQualifiedName);
            info.AddValue("rest", Rest.AssemblyQualifiedName);
        }

        public override string ToString() => Soap.Name;
    }

    // ---- Targeted conversions that the generic round-trip relies on ----

    [Fact]
    public void Maps_Credentials_And_Identify_Casing_SoapToRest()
    {
        var soap = new GetAccountsRequest
        {
            identify = "ident-123",
            Credentials = new Credentials { UserName = "user", Password = "pass" },
        };

        var rest = BfsJsonMapper.Map<RestApi.GetAccountsRequest>(soap)!;

        // identify (lower) on SOAP <-> Identify ([JsonPropertyName("identify")]) on REST
        Assert.Equal("ident-123", rest.Identify);
        Assert.NotNull(rest.Credentials);
        Assert.Equal("user", rest.Credentials!.UserName);
        Assert.Equal("pass", rest.Credentials.Password);
    }

    [Fact]
    public void Maps_Array_To_Collection_SoapToRest()
    {
        var id1 = Guid.NewGuid();
        var id2 = Guid.NewGuid();
        var soap = new GetAccountsRequest
        {
            Args = new GetAccountsArgs
            {
                BrickIds = new[] { id1, id2 },
                AccountNos = new[] { "A1", "A2", "A3" },
            },
        };

        var rest = BfsJsonMapper.Map<RestApi.GetAccountsRequest>(soap)!;

        Assert.NotNull(rest.Args);
        Assert.Equal(new[] { id1, id2 }, rest.Args!.BrickIds!.ToArray());
        Assert.Equal(new[] { "A1", "A2", "A3" }, rest.Args.AccountNos!.ToArray());
    }

    [Fact]
    public void Maps_Collection_To_Array_RestToSoap()
    {
        var rest = new RestApi.GetAccountsResponse
        {
            Message = "OK",
            Result = new[]
            {
                new RestApi.GetAccountResponseRow { AccountNo = "ACC-1", BaseCurrencyCode = "SEK" },
            },
        };

        var soap = BfsJsonMapper.Map<GetAccountsResponse>(rest)!;

        Assert.Equal("OK", soap.Message);
        Assert.NotNull(soap.Result);
        Assert.Single(soap.Result);
        Assert.Equal("ACC-1", soap.Result[0].AccountNo);
        Assert.Equal("SEK", soap.Result[0].BaseCurrencyCode);
    }

    [Fact]
    public void Null_Source_Maps_To_Default()
    {
        var rest = BfsJsonMapper.Map<RestApi.GetAccountsRequest>(null);
        Assert.Null(rest);
    }

    private static void AssertRoundTrips<TSoap, TRest>() where TSoap : class
    {
        var original = ObjectFiller.Create<TSoap>();
        Assert.NotNull(original);

        var rest = BfsJsonMapper.Map<TRest>(original);
        Assert.NotNull(rest);

        var roundTripped = BfsJsonMapper.Map<TSoap>(rest);
        Assert.NotNull(roundTripped);
        Assert.NotNull(original);

        JsonEquivalence.AssertEquivalent(original, roundTripped);
        Assert.NotEqual(original, roundTripped);
    }
}
