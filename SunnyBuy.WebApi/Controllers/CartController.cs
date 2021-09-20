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
            return await cartService.GetCartListProducts(clientId);
        }

        [HttpPost()]
        public async Task<bool> Post([FromBody] PostCartModel model)
        {
            return await cartService.Checkout(model);
        }
        
        [HttpGet("total/{clientId}")]
        public async Task<decimal> Total(int clientId) 
        {
            return await cartService.Total(clientId);
        }

        [HttpGet("count/{clientId}")]
        public async Task<int> Count(int clientId)
        {
            return await cartService.Count(clientId);
        }

        [HttpDelete()]
        public async Task<bool> Put([FromBody]PutCartModel model)
        {
            return await cartService.PutCart(model);
        }
    }
}