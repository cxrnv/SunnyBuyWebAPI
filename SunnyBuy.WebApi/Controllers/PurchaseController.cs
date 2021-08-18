using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using SunnyBuy.Services.PurchaseServices;
using SunnyBuy.Services.PurchaseServices.Models;

namespace SunnyBuy.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class PurchaseController : Controller
    {
        protected readonly PurchaseService purchaseService;
        public PurchaseController(PurchaseService purchaseService)
        {
            this.purchaseService = purchaseService;
        }

        [HttpGet("{clientId}")]
        public async Task<List<ListModel>> Get(int clientId)
        {
            return await purchaseService.GetPurchaseComplete(clientId);
        }
        
        [HttpPost()]
        public async Task<bool> Post(ListModel model)
        {
            return await purchaseService.PostPurchase(model);
        }
    }
}