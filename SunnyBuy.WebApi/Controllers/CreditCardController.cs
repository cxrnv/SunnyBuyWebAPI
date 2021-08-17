using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using SunnyBuy.Services.CreditCardServices;
using SunnyBuy.Services.ClientServices.Models;
using SunnyBuy.Services.CreditCardServices.Models;

namespace SunnyBuy.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CreditCardController : Controller
    {
        protected readonly CreditCardService creditCardService;
        public CreditCardController(CreditCardService creditCardService)
        {
            this.creditCardService = creditCardService;
        }

        [HttpPost()]
        public async Task<bool> Post(CreditCardPostModel model)
        {
            return await creditCardService.Post(model);
        }

        [HttpGet("{clientId}")]
        public async Task<List<CreditCardListModel>> ExistingCard(int clientId)
        {
            return await creditCardService.ExistingCard(clientId);
        }

        [HttpGet("{creditCardId}")]
        public async Task<List<CreditCardListModel>> Get(int creditCardId)
        {
            return await creditCardService.Get(creditCardId);
        }

        [HttpDelete("{clientId}/{creditCardId}")]
        public async Task<bool> Delete(int clientId, int creditCardId)
        {
            return await creditCardService.Delete(clientId, creditCardId);
        }
    }
}
