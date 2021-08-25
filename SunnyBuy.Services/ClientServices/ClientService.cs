using SunnyBuy.Services.ClientServices.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using SunnyBuy.Domain;
using System.Linq;
using System;

namespace SunnyBuy.Services
{
    public class ClientService
    {
        protected readonly SunnyBuyContext context;

        public ClientService(SunnyBuyContext context)
        {
            this.context = context;
        }
        public async Task<bool> PostClient(PostModel model)
        {
            await ExistingClientVerifier(model);

            var client = new Client
            {
                ClientCpf = model.Cpf,
                Name = model.Name,
                Email = model.Email,
                Password = model.Password,
                Address = model.Address,
                Phone = model.Phone
            };

            await context.Client.AddAsync(client);
            await context.SaveChangesAsync();

            return true;
        }

        /* I persisted the model in Verifier because the model I use in it
         * is directly linked to my Post, so I use the same parameter for both*/
        public async Task<bool> ExistingClientVerifier(PostModel model)
        {
            if (await context.Client
                 .AnyAsync(e => e.Email == model.Email || e.ClientCpf == model.Cpf))
            {
                throw new Exception("This email or cpf already exists");
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Login(LoginModel model)
        {
            if (await context.Client
                 .AnyAsync(e => e.Email == model.Email && e.Password == model.Password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<GetModel>> GetAll()
        {
            return await context.Client
                .Where(a => a.Disabled == false)
                .Select(c => new GetModel
                {
                    Cpf = c.ClientCpf,
                    Name = c.Name,
                    Email = c.Email,
                    Address = c.Address,
                    Phone = c.Phone
                }).ToListAsync();
        }

        public async Task<GetModel> GetClient(string cpf)
        {
            return await context.Client
            .Where(a => a.ClientCpf == cpf && !a.Disabled)
            .Select(c => new GetModel
            {
                Cpf = c.ClientCpf,
                Name = c.Name,
                Email = c.Email,
                Address = c.Address,
                Phone = c.Phone
            }).FirstOrDefaultAsync();
        }

        public async Task<bool> DeleteClient(string cpf)
        {
            var client = context.Client
                .Where(a => a.ClientCpf == cpf)
                .Single();

            context.Client.Remove(client);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> PutClientDisabled(PutClientModel model)
        {
            var client = context.Client
                .FirstOrDefault(a => a.ClientCpf == model.ClientCpf && model.Disabled);

            client.Disabled = model.Disabled;

            context.Client.UpdateRange();
            await context.SaveChangesAsync();

            return true;
        }
    }
}