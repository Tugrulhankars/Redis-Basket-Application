using Redis.Basket.Models;

namespace Redis.Basket.Services;

public interface IBasketService
{
    BasketItem GetBasket(string userId);
    Task SaveBasket(Basket.Models.Basket basketItem);
    Task DeleteBasket(string userId);
}
