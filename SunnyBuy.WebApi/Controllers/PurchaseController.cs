using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<PurchaseListModel> Get(int clientId)
        {
            return await purchaseService.GetPurchase(clientId); 
        }

        [HttpPost()]
        public async Task<bool> Post(PurchaseListModel model)
        {
            return await purchaseService.PostPurchase(model);
        }

        [HttpPut()]
        public async Task<bool> Put([FromBody]PutPurchaseModel model)
        {
            return await purchaseService.ConfirmPurchase(model);
        }
    }
}