using System;
using SunnyBuy.Domain;

namespace SunnyBuy.Services.PurchaseServices.Models
{
    public class ListModel
    {
        public int PurchaseId { get; set; }
        public DateTime DatePurchase { get; set; }
        public PaymentTypeEnum PaymentTypeEnum { get; set; }
        public int ClientId { get; set; }
        public int CartId { get; set; }
    }
}
