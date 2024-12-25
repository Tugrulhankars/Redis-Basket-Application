using Redis.Basket.Models;

namespace Redis.Basket.Services;

public class BasketService : IBasketService
{
    private readonly IRedisService _redisService;
    public BasketService(IRedisService redisService)
    {
        _redisService = redisService;
    }
    public async Task DeleteBasket(string userId)
    {
        await _redisService.Remove(userId);
    }

    public BasketItem GetBasket(string userId)
    {
       return (BasketItem)_redisService.Get(userId);
             
    }

    public async Task SaveBasket(Basket.Models.Basket basket)
    {
      await  _redisService.Add(basket.UserId,basket.BasketItem);
    }
}
