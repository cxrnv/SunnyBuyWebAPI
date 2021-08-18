﻿using SunnyBuy.Services.ClientServices.Models;
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
            return await clientService.Post(model);
        }

        [HttpGet()]
        public async Task<bool> Login([FromBody] LoginModel model)
        {
            return await clientService.Login(model);
        }

        [HttpGet("verifier")]
        public async Task<bool> Verifier(PostModel model)
        {
            return await clientService.Verifier(model);
        }

        [HttpGet("clients")]
        public async Task<List<GetModel>> GetAll()
        {
            return await clientService.GetAll();
        }

        [HttpGet("{cpf}")]
        public async Task<GetModel> Get(string cpf)
        {
            return await clientService.Get(cpf);
        }

        [HttpPut()]
        public async Task<bool> Put([FromBody]PutClientModel model)
        {
            return await clientService.Put(model);
        }

        [HttpDelete("{cpf}")]
        public async Task<bool> Delete(string cpf)
        {
            return await clientService.Delete(cpf);
        }
    }
}