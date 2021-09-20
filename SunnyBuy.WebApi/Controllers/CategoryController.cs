using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SunnyBuy.Services.CategoryServices;
using SunnyBuy.Services.CategoryServices.Models;

namespace SunnyBuy.WebApi.Controllers
{
    [Route("[controller]")]

    [ApiController]
    public class CategoryController : Controller
    {
        protected readonly CategoryService categoryService;
        public CategoryController(CategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        
        [HttpGet()]
        public async Task<List<CategoryModel>> Get()
        {
            return await categoryService.GetCategory();
        }
    }
}