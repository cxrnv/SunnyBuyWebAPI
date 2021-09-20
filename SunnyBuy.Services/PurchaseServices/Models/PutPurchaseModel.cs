using System;
using System.Collections.Generic;
using System.Text;

namespace SunnyBuy.Services.PurchaseServices.Models
{
    public class PutPurchaseModel
    {
        public int ClientId { get; set; }
        public int PurchaseId { get; set; }
        public bool Complete { get; set; }
        public bool Sold { get; set; }
    }
}
