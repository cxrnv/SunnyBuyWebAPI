using System;

namespace SunnyBuy.Services.CartServices.Models
{
    public class CartListModel
    {
        public int Count { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public DateTime DateInclude { get; set; }
        public string image { get; set; }
        public string Detail { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool Deleted { get; set; }
        public bool Sold { get; set; }
    }
}
