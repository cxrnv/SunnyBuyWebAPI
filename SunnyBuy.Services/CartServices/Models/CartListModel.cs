using System;

namespace SunnyBuy.Services.CartServices.Models
{
    public class CartListModel
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public DateTime DateInclude { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
