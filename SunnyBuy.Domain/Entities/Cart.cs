using SunnyBuy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SunnyBuy.Domain
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public int ClientId { get; set; }

        [ForeignKey(nameof(ClientId))]
        public Client Client { get; set; }

        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }

        public DateTime DateInclude { get; set; }
        public bool Deleted { get; set; }
        public bool Sold { get; set; }
        public IList<Purchase_Cart> Purchase_Carts { get; set; }
    }
}
