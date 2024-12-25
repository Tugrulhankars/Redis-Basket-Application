namespace Redis.Basket.Models;

public class Basket
{
    public string UserId { get; set; }
    public BasketItem BasketItem { get; set; }
}
