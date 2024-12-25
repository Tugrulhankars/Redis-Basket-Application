using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Redis.Basket.Services;

namespace Redis.Basket.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BasketController : ControllerBase
{
    private readonly IBasketService _basketService;
    public BasketController(IBasketService basketService)
    {
        _basketService = basketService;
    }


    [HttpGet("getBasket")]
    public async Task<IActionResult> GetBasket([FromQuery] string userId)
    {
       
        return Ok(_basketService.GetBasket(userId));
    }

    [HttpPost("addBasket")]
    public async Task<IActionResult> AddBasket([FromBody] Basket.Models.Basket basket)
    {
       
        return Ok(_basketService.SaveBasket(basket));
    }

    [HttpDelete("delete")] 
    public async Task<IActionResult> DeleteBasket([FromBody] string userId)
    {
        
        return Ok(_basketService.DeleteBasket(userId));
    }
}
