using SunnyBuy.Services.PurchaseServices.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using SunnyBuy.Domain;
using System.Linq;
using System;

namespace SunnyBuy.Services.PurchaseServices
{
    public class PurchaseService
    {
        protected readonly SunnyBuyContext context;
        public PurchaseService(SunnyBuyContext context)
        {
            this.context = context;
        }

        public async Task<List<ListModel>> Get(int clientId)
        {
            return await context.Purchase
                .Where(a => a.ClientId == clientId)
                .Select(b => new ListModel
                {
                    PurchaseId = b.PurchaseId,
                    ClientId = b.ClientId,
                    CartId = b.CartId,
                    PaymentTypeEnum = b.PaymentTypeEnum,
                    DatePurchase = b.DatePurchase
                }).ToListAsync();
        }
        public async Task<bool> Post(ListModel model)
        {
            var purchase = new Purchase
            {
                CartId = model.CartId,
                DatePurchase = DateTime.Now,
                PaymentTypeEnum = model.PaymentTypeEnum,
                ClientId = model.ClientId
            };

            await context.Purchase.AddAsync(purchase);
            await context.SaveChangesAsync();

            return true;
        }
    }
}