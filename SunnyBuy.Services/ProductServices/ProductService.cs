using SunnyBuy.Services.ProductServices.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using SunnyBuy.Domain;
using System.Linq;

namespace SunnyBuy.Services
{
    public class ProductService
    {
        protected readonly SunnyBuyContext context;

        public ProductService(SunnyBuyContext context)
        {
            this.context = context;
        }
        public async Task<List<ListModel>> GetAll()
        {
            return await context.Product
                .Select(p => new ListModel
                {
                    ProductId = p.ProductId,
                    Price = p.Price,
                    Name = p.Name
                }).ToListAsync();
        }
        public async Task<List<ListModel>> GetCategory(CategoryEnum categoryEnum)
        {
            return await context.Product
                .Where(a => a.CategoryEnum == categoryEnum)
                .Select(b => new ListModel
                {
                    ProductId = b.ProductId,
                    Name = b.Name,
                    Price = b.Price
                }).ToListAsync();
        }
        public async Task<GetModel> Get(int productId)
        {
            return await context.Product
                .Where(a => a.ProductId == productId)
                .Select(c => new GetModel
                {
                    ProductId = c.ProductId,
                    Name = c.Name,
                    Price = c.Price,
                    Detail = c.Detail,
                    Quantity = c.Quantity
                }).FirstOrDefaultAsync();
        }
    }
}