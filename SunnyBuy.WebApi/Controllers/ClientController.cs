using SunnyBuy.Services.ClientServices.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SunnyBuy.Services;

namespace SunnyBuy.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class ClientController : ControllerBase
    {
        protected readonly ClientService clientService;
        public ClientController(ClientService clientService)
        {
            this.clientService = clientService;
        }

        [HttpPost()]
        public async Task<bool> Post(PostModel model)
        {
            return await clientService.PostClient(model);
        }

        [HttpPost("login/{email}/{password}")]
        public async Task<bool> Login( string email, string password)
        {
            return await clientService.Login(email, password);
        }

        [HttpGet("verifier")]
        public async Task<bool> Verifier(PostModel model)
        {
            return await clientService.ExistingClientVerifier(model);
        }

        [HttpGet("clients")]
        public async Task<List<GetModel>> GetAll()
        {
            return await clientService.GetAll();
        }

        [HttpGet("{cpf}")]
        public async Task<GetModel> Get(string cpf)
        {
            return await clientService.GetClient(cpf);
        }

        [HttpPut()]
        public async Task<bool> Put([FromBody]PutClientModel model)
        {
            return await clientService.PutClientDisabled(model);
        }

        [HttpDelete("{cpf}")]
        public async Task<bool> Delete(string cpf)
        {
            return await clientService.DeleteClient(cpf);
        }
    }
}