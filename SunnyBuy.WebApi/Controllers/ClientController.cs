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

        [HttpPost("login")]
        public async Task<int> Login(LoginModel model)
        {
            return await clientService.Login(model);
        }

        [HttpGet("verifier")]
        public async Task<bool> Verifier(PostModel model)
        {
            return await clientService.ExistingClientVerifier(model);
        }

        [HttpGet("clients")]
        public async Task<List<GetClientModel>> GetAll()
        {
            return await clientService.GetAll();
        }

        [HttpGet("clients-chat")]
        public async Task<List<GetClientModel>> GetClientsChat()
        {
            return await clientService.GetClientsChat();
        }


        [HttpGet("{clientId}")]
        public async Task<GetClientModel> Get(int clientId)
        {
            return await clientService.GetClient(clientId);
        }

        [HttpPut("edit")]
        public async Task<bool> EditClient([FromBody] EditClientModel model)
        {
            return await clientService.EditClientData(model);
        }

        [HttpPut("disable")]
        public async Task<bool> PutClient([FromBody]PutClientModel model)
        {
            return await clientService.PutClientDisabled(model);
        }
    }
}