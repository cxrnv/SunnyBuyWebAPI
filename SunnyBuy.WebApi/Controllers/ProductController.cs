using SunnyBuy.Services.ProductServices.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SunnyBuy.Services;
using SunnyBuy.Domain;

namespace SunnyBuy.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class ProductController : ControllerBase
    {
        protected readonly ProductService productService;
        public ProductController(ProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet()]
        public async Task<List<ListModel>> GetAll()
        {
            return await productService.GetAll();
        }

        [HttpGet("category/{categoryEnum}")]
        public async Task<List<ListModel>> GetProductsCategory(CategoryEnum categoryEnum)
        {
            return await productService.GetCategory(categoryEnum);
        }

        [HttpGet("product/{productId}")]
        public async Task<GetModel> Get(int productId)
        {
            return await productService.Get(productId);
        }
    }
}