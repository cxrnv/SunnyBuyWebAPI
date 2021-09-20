﻿using System.Threading.Tasks;
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
            return await creditCardService.PostCreditCard(model);
        }

        [HttpGet("clientId/{clientId}")]
        public async Task<List<CreditCardListModel>> ExistingCards(int clientId)
        {
            return await creditCardService.GetExistingCardsClient(clientId);
        }

        [HttpDelete()]
        public async Task<bool> Put(CreditCardPutModel model)
        {
            return await creditCardService.Put(model);
        }

        [HttpDelete("{clientId}/{creditCardId}")]
        public async Task<bool> DeleteCreditCard(int clientId, int creditCardId)
        {
            return await creditCardService.DeleteCreditCard(clientId, creditCardId);
        }
    }
}