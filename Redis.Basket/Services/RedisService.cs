
using Newtonsoft.Json;
using Redis.Basket.Models;
using StackExchange.Redis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Redis.Basket.Services;

public class RedisService : IRedisService
{
    private readonly IDatabase _database;
    public RedisService(IConnectionMultiplexer connectionMultiplexer)
    {
        _database=connectionMultiplexer.GetDatabase();
    }
    public async Task<string> Add(string key, object value)
    {
      
        string serialieValue = JsonConvert.SerializeObject(value);
        _database.StringSet(key, serialieValue);
            return "ürün sepete başarılı bir şekilde eklendi";
    }

   

    public object Get(string key)
    {
        var exist = _database.StringGet(key);
        return System.Text.Json.JsonSerializer.Deserialize<BasketItem>(exist);
    }

    public bool IsAdd(string key)
    {
        var exist = _database.StringGet(key);
        if (exist.HasValue)
        {
            return true;
        }

        return false;
    }

    public async Task Remove(string key)
    {
        await _database.KeyDeleteAsync(key);
    }
}
