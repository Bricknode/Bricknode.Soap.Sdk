﻿namespace Bricknode.Soap.Sdk.Factories;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bricknode.Soap.Sdk.Configuration;

public class BfsApiConfigurationProvider : IBfsApiConfigurationProvider
{
    private IReadOnlyDictionary<string, BfsApiConfiguration> _bfsApiConfigurations;

    public BfsApiConfigurationProvider()
    {
        _bfsApiConfigurations = new Dictionary<string, BfsApiConfiguration>(StringComparer.OrdinalIgnoreCase);
    }

    public BfsApiConfigurationProvider(IDictionary<string, BfsApiConfiguration> configurations)
    {
        _bfsApiConfigurations = new Dictionary<string, BfsApiConfiguration>(configurations, StringComparer.OrdinalIgnoreCase);
    }

    public void AddConfigurations(Dictionary<string, BfsApiConfiguration> configurations)
    {
        _bfsApiConfigurations = configurations;
    }

    public ValueTask<BfsApiConfiguration> GetConfigurationAsync(string? bfsApiClientName = null)
    {
        return new ValueTask<BfsApiConfiguration>(_bfsApiConfigurations[bfsApiClientName ?? string.Empty]);
    }
}