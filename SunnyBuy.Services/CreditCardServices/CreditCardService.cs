using SunnyBuy.Services.CreditCardServices.Models;
using SunnyBuy.Services.ClientServices.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using SunnyBuy.Domain;
using System.Linq;

namespace SunnyBuy.Services.CreditCardServices
{
    public class CreditCardService
    {
        protected readonly SunnyBuyContext context;

        public CreditCardService(SunnyBuyContext context)
        {
            this.context = context;
        }
        public async Task<List<CreditCardListModel>> ExistingCard(int clientId)
        {
            return await context.CreditCard
                .Where(a => a.ClientId == clientId)
                .Select(b => new CreditCardListModel
                {
                    ClientId = b.ClientId,
                    CreditCardId = b.CreditCardId,
                    Operator = b.Operator,
                    Number = b.Number,
                    DueDate = b.DueDate,
                    SecurityCode = b.SecurityCode
                }).ToListAsync();
        }
        public async Task<bool> Post(CreditCardPostModel model)
        {
            model.Validator();

            var card = new CreditCard()
            {
                ClientId = model.ClientId,
                DueDate = model.DueDate,
                Number = model.Number,
                SecurityCode = model.SecurityCode,
                Operator = model.Operator
            };

            context.CreditCard.Add(card);
            await context.SaveChangesAsync();

            return true;
        }
        public async Task<List<CreditCardListModel>> Get(int creditCardId)
        {
            return await context.CreditCard
                .Where(a => a.CreditCardId == creditCardId)
                .Select(b => new CreditCardListModel
                {
                    CreditCardId = b.CreditCardId,
                    ClientId = b.ClientId,
                    Operator = b.Operator,
                    Number = b.Number,
                    DueDate = b.DueDate,
                    SecurityCode = b.SecurityCode
                })
                .ToListAsync();
        }
        public async Task<bool> Delete(int clientId, int creditCardId)
        {
            var creditCard = context.CreditCard
                .Where(a => a.ClientId == clientId && a.CreditCardId == creditCardId)
                .Single();

            context.CreditCard.Remove(creditCard);
            await context.SaveChangesAsync();

            return true;
        }
    }
}
