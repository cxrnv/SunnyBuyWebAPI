using SunnyBuy.Domain;
using System;

namespace SunnyBuy.Services.MessageServices.Models
{
    public class PostMessageModel
    {
        public int MessageId { get; set; }
        public string Description { get; set; }
        public DateTime DateMessage { get; set; }
        public int ClientId { get; set; }
        public int EmployeeId { get; set; }
        public PersonTypeEnum PersonTypeEnum { get; set; }
    }
}
