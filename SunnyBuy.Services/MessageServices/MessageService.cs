using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using SunnyBuy.Domain;
using System.Linq;
using System;
using SunnyBuy.Services.MessageServices.Models;
using SunnyBuy.Domain.Entities;

namespace SunnyBuy.Services.MessageServices
{
    public class MessageService
    {
        protected readonly SunnyBuyContext context;

        public MessageService(SunnyBuyContext context)
        {
            this.context = context;
        }

        public async Task<bool> PostMessage(PostMessageModel model)
        {
            var message = new Message
            {
                ClientId = model.ClientId,
                EmployeeId = model.EmployeeId,
                //Date.time.UTC.Now
                DateMessage = DateTime.Now,
                Description = model.Description,
                PersonTypeEnum = model.PersonTypeEnum
            };

            await context.Message.AddAsync(message);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<List<GetMessageModel>> GetMessage(int clientId, int employeeId)
        {
            return await context.Message
            .Where(a => a.ClientId == clientId && a.EmployeeId == employeeId)
            .Select(c => new GetMessageModel
            {
                MessageId = c.MessageId,
                ClientId = c.ClientId,
                EmployeeId = c.EmployeeId,
                Description = c.Description,
                DateMessage = c.DateMessage,
                PersonTypeEnum = c.PersonTypeEnum
            }).ToListAsync();
        }
    }
}
