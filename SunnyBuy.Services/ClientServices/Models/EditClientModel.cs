﻿namespace SunnyBuy.Services.ClientServices.Models
{
    public class EditClientModel
    {
        public int ClientId { get; set; }
        public string ClientCpf { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }
    }
}
