using Microsoft.EntityFrameworkCore;
using SunnyBuy.Domain;
using SunnyBuy.Services.CategoryServices.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SunnyBuy.Services.CategoryServices
{
    public class CategoryService
    {
        protected readonly SunnyBuyContext context;

        public CategoryService(SunnyBuyContext context)
        {
            this.context = context;
        }

        public async Task<List<CategoryModel>> GetCategory()
        {
            return await context.Category
                .Select(c => new CategoryModel
                {
                    CategoryEnum = c.CategoryEnum,
                    Description = c.Description
                }).ToListAsync();
        }
    }
}
