using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using BuildingBlocks.Types;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace BuildingBlocks.EventStore;

public class JsonEventSerializer : IEventSerializer
{
    private static readonly JsonSerializerSettings JsonSerializerSettings = new()
    {
        ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
        ContractResolver = new PrivateSetterContractResolver()
    };

    private readonly IEnumerable<Assembly> _assemblies;

    public JsonEventSerializer()
    {
        _assemblies = new[] {Assembly.GetExecutingAssembly()};
    }

    public JsonEventSerializer(IEnumerable<Assembly> assemblies)
    {
        _assemblies = assemblies ?? new[] {Assembly.GetExecutingAssembly()};
    }

    public IDomainEvent<TKey> Deserialize<TKey>(string type, byte[] data)
    {
        var jsonData = Encoding.UTF8.GetString(data);
        return Deserialize<TKey>(type, jsonData);
    }

    public IDomainEvent<TKey> Deserialize<TKey>(string type, string data)
    {
        //TODO: cache types
        var eventType = _assemblies.Select(a => a.GetType(type, false))
            .FirstOrDefault(t => t != null) ?? Type.GetType(type);
        if (null == eventType)
            throw new ArgumentOutOfRangeException(nameof(type), $"invalid event type: {type}");

        var result = JsonConvert.DeserializeObject(data, eventType, JsonSerializerSettings);

        return (IDomainEvent<TKey>) result;
    }

    public byte[] Serialize<TKey>(IDomainEvent<TKey> @event)
    {
        var json = JsonSerializer.Serialize((dynamic) @event);
        var data = Encoding.UTF8.GetBytes(json);
        return data;
    }
}