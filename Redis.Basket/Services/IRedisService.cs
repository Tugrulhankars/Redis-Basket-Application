namespace Redis.Basket.Services;

public interface IRedisService
{
    object Get(string key);
    Task<string> Add(string key,object value);
    bool IsAdd(string key);
    Task Remove(string key);
   
}
