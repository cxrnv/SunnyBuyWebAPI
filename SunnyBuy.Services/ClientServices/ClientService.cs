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
                Name = model.Name,
                Email = model.Email,
                Password = model.Password,
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
                 .AnyAsync(e => e.Email == model.Email))
            {
                throw new Exception("This email already exists");
            }
            else
            {
                return false;
            }
        }

        public async Task<int> Login(LoginModel model)
        {
            var login = await context.Client
                .Where(e => e.Email == model.Email && e.Password == model.Password && !e.Disabled)
                .FirstOrDefaultAsync();

            if (login == null)
            {
                return 0;
            }

            return login.ClientId;
        }

        public async Task<List<GetClientModel>> GetAll()
        {
            return await context.Client
                .Where(a => !a.Disabled)
                .Select(c => new GetClientModel
                {
                    ClientId = c.ClientId,
                    ClientCpf = c.ClientCpf,
                    Name = c.Name,
                    Email = c.Email,
                    Address = c.Address,
                    Phone = c.Phone,
                    Image = c.Image
                    
                }).ToListAsync();
        }

        public async Task<List<GetClientModel>> GetClientsChat()
        {
            var clients = await context.Message
                .Select(c => c.ClientId)
                .Distinct()
                .ToListAsync();

            return await context.Client
                .Where(a => !a.Disabled && clients.Any(c => c == a.ClientId))
                .Select(c => new GetClientModel
                {
                    ClientId = c.ClientId,
                    ClientCpf = c.ClientCpf,
                    Name = c.Name,
                    Email = c.Email,
                    Address = c.Address,
                    Phone = c.Phone,
                    Image = c.Image
                }).ToListAsync();
        }

        public async Task<GetClientModel> GetClient(int id)
        {
            return await context.Client
            .Where(a => a.ClientId == id && !a.Disabled)
            .Select(c => new GetClientModel
            {
                ClientCpf = c.ClientCpf,
                Name = c.Name,
                Password = c.Password,
                Email = c.Email,
                Address = c.Address,
                Phone = c.Phone,
                Image = c.Image
            }).FirstOrDefaultAsync();
        }

        public async Task<bool> PutClientDisabled(PutClientModel model)
        {
            var client = context.Client
                .FirstOrDefault(a => a.ClientId == model.ClientId && model.Disabled);

            client.Disabled = model.Disabled;

            context.Client.UpdateRange();
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> EditClientData(EditClientModel model)
        {
            var client = context.Client
                .FirstOrDefault(a => a.ClientId == model.ClientId);

            client.ClientCpf = model.ClientCpf;
            client.Name = model.Name;
            client.Email = model.Email;
            client.Password = model.Password;
            client.Address = model.Address;
            client.Phone = model.Phone;
            client.Image = model.Image;

            context.Client.Update(client);
            await context.SaveChangesAsync();

            return true;
        }
    }
}