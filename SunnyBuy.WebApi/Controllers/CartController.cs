using SunnyBuy.Services.CartServices.Models;
using SunnyBuy.Services.CartServices;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SunnyBuy.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CartController : Controller
    {
        protected readonly CartService cartService;
        public CartController(CartService cartService)
        {
            this.cartService = cartService;
        }

        [HttpGet("{clientId}")]
        public async Task<List<CartListModel>> Get(int clientId)
        {
            return await cartService.GetCart(clientId);
        }

        [HttpPost("{clientId}/{productId}")]
        public async Task<bool> Post(int clientId, int productId)
        {
            return await cartService.PostCart(clientId, productId);
        }

        [HttpDelete()]
        public async Task<bool> Put([FromBody]PutCartModel model)
        {
            return await cartService.PutCart(model);
        }
    }
}