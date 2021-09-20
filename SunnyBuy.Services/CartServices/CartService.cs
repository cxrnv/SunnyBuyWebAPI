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
                .Where(a => a.ClientId == clientId && !a.Deleted && a.Sold == false);

            return products = await cart.Select(b => new CartListModel
            {
                CartId = b.CartId,
                ProductId = b.ProductId,
                Detail = b.Product.Detail,
                image = b.Product.Image,
                Name = b.Product.Name,
                Price = b.Product.Price,
                DateInclude = b.DateInclude,
            })
            .ToListAsync();
        }
        public async Task<bool> Checkout(PostCartModel model)
        {
            var cartList = await context.Cart
                .AnyAsync(a => a.ClientId == model.ClientId && a.ProductId == model.ProductId && !a.Deleted && !a.Sold);

            if (cartList)
            {
                throw new Exception("This product already exists in your cart");
            }

            var cart = new Cart()
            {
                ClientId = model.ClientId,
                ProductId = model.ProductId,
                DateInclude = DateTime.Now,
                Deleted = false,
                Sold = false
            };

            await context.Cart.AddAsync(cart);
            await context.SaveChangesAsync();

            return true;
        }
        public async Task<decimal> Total(int clientId)
        {
            var items = await GetCartListProducts(clientId);
            var total = new TotalCartModel();

            var totalPrice = total.TotalPrice = items
                .Where(item => item.Sold == false)
                .Sum(item => item.Price * 1);

            return totalPrice;
        }
        public async Task<int> Count(int clientId)
        {
            var items = await GetCartListProducts(clientId);
            var count = new TotalCartModel();

            var quantity = count.Count = items
                .Count();

            return quantity;
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