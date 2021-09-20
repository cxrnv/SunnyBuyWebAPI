using SunnyBuy.Services.PurchaseServices.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using SunnyBuy.Domain;
using System.Linq;
using System;
using SunnyBuy.Domain.Entities;
using SunnyBuy.Services.CartServices;

namespace SunnyBuy.Services.PurchaseServices
{
    public class PurchaseService
    {
        protected readonly CartService cartService;
        protected readonly SunnyBuyContext context;
        public PurchaseService(SunnyBuyContext context, CartService cartService)
        {
            this.context = context;
            this.cartService = cartService;
        }

        public async Task<PurchaseListModel> GetPurchase(int clientId)
        {
            var totalCart = await cartService.Total(clientId);

            var purchase = await context.Purchase
                .Where(x => x.ClientId == clientId && !x.Complete)
                .Select(
                x => new PurchaseListModel
                {
                    PurchaseId = x.PurchaseId,
                    Complete = x.Complete,
                    ClientId = x.ClientId,
                    CreditCardId = x.CreditCardId,
                    Name = x.Client.Name,
                    Email = x.Client.Email,
                    Address = x.Client.Address,
                    PaymentTypeEnum = x.PaymentTypeEnum,
                    DatePurchase = x.DatePurchase,
                    Number = x.CreditCard.Number,
                    Operator = x.CreditCard.Operator,
                    Total = totalCart,
                    Quantity = x.Purchase_Carts.Select(x => x.Cart.Product.ProductId).Count(),
                }).OrderByDescending(x => x.DatePurchase)
                .FirstOrDefaultAsync();


            return purchase;
        }
        public async Task<bool> PostPurchase(PurchaseListModel model)
        {
            var purchase = new Purchase
            {
                ClientId = model.ClientId,
                CreditCardId = model.CreditCardId,
                DatePurchase = DateTime.Now,
                PaymentTypeEnum = model.PaymentTypeEnum
            };

            await context.Purchase.AddAsync(purchase);

            await context.SaveChangesAsync();

            var carts = await context.Cart.Where(c => c.ClientId == model.ClientId && !c.Deleted)
                .Select(c => c.CartId)
                .ToListAsync();

            carts.ForEach(cartId =>
            {
                var purchase_cart = new Purchase_Cart
                {
                    CartId = cartId,
                    PurchaseId = purchase.PurchaseId,
                };

                context.Purchase_Cart.Add(purchase_cart);
            });

            await context.SaveChangesAsync();

            return true;
        }
        public async Task<bool> ConfirmPurchase(PutPurchaseModel model)
        {
            var purchase = context.Purchase
                .FirstOrDefault(x => x.PurchaseId == model.PurchaseId && !model.Complete);

            purchase.Complete = true;

            var cartProducts = await context.Cart.Where(c => c.ClientId == model.ClientId).ToListAsync();

            cartProducts.ForEach(a =>
            {
                a.Sold = true;
            });

            context.Cart.UpdateRange();
            context.Purchase.UpdateRange();
            await context.SaveChangesAsync();

            return true;
        }
    }
}