using SunnyBuy.Services.ProductServices.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SunnyBuy.Services;
using SunnyBuy.Domain;
using SunnyBuy.Services.MessageServices;
using SunnyBuy.Services.MessageServices.Models;

namespace SunnyBuy.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class MessageController : ControllerBase
    {
        protected readonly MessageService messageService;
        public MessageController(MessageService messageService)
        {
            this.messageService = messageService;
        }

        [HttpPost()]
        public async Task<bool> Post(PostMessageModel model)
        {
            return await messageService.PostMessage(model);
        }

        [HttpGet("{clientId}/{employeeId}")]
        public async Task<List<GetMessageModel>> Get(int clientId, int employeeId)
        {
            return await messageService.GetMessage(clientId, employeeId);
        }
    }
}
