using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SunnyBuy.Services.CartServices.Models;
using SunnyBuy.Domain;

namespace SunnyBuy.Services.CartServices
{
    public class CartService
    {
        protected readonly SunnyBuyContext context;
        public CartService(SunnyBuyContext context)
        {
            this.context = context;
        }
        
        public async Task<List<CartListModel>> GetCartListProducts(int clientId)
        {
            var products = new List<CartListModel>();

            var cart = context.Cart
                .Include(a => a.Product)
                .Where(a => a.ClientId == clientId && !a.Deleted);

            return products = await cart.Select(b => new CartListModel
            {
                CartId = b.CartId,
                ProductId = b.ProductId,
                Name = b.Product.Name,
                Price = b.Product.Price,
                DateInclude = b.DateInclude
            }).ToListAsync();
        }
        public async Task<bool> Checkout(int clientId, int productId)
        {
            var model = new Cart()
            {
                ClientId = clientId,
                ProductId = productId,
                DateInclude = DateTime.Now,
                Deleted = false
            };

            await context.Cart.AddAsync(model);
            await context.SaveChangesAsync();

            return true;
        }
        public async Task<bool> PutCart(PutCartModel model)
        {
            var cart = context.Cart
                    .FirstOrDefault(a => a.CartId == model.CartId && model.Deleted);

            cart.Deleted = model.Deleted;

            context.Cart.UpdateRange();
            await context.SaveChangesAsync();

            return true;
        }
    }
}