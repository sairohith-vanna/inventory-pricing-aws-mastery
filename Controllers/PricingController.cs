using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace InventoryPricingService.Controllers;

[ApiController]
[Route("price")]
public class PricingController
{
    readonly Random _random = new ();

    private readonly ILogger<PricingController> _logger;

    public PricingController(ILogger<PricingController> logger)
    {
        _logger = logger;
    }

    [HttpGet(template: "{productId}", Name = "GetPriceForItem")]
    public async Task<IActionResult> GetProductPricingDetails([FromRoute] string productId)
    {
        var productPrice = new
        {
            ProductId = productId,
            CostingId = Guid.NewGuid(),
            MaxCost = Math.Round(_random.NextDouble() * 100, 2),
            MaxDiscount = _random.NextInt64(10, 25)
        };
        return await Task.FromResult<IActionResult>(new OkObjectResult(productPrice));
    }
}
