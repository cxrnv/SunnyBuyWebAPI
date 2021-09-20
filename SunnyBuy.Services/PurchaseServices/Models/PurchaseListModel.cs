using System;
using SunnyBuy.Domain;

namespace SunnyBuy.Services.PurchaseServices.Models
{
    public class PurchaseListModel
    {
        public int Quantity { get; set; }
        public int PurchaseId { get; set; }
        public bool Complete { get; set; }
        public int ClientId { get; set; }
        public int? CreditCardId { get; set; }
        public string Operator { get; set; }
        public string Number { get; set; }
        public DateTime DatePurchase { get; set; }
        public PaymentTypeEnum PaymentTypeEnum { get; set; }
        public string Product_Name { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public decimal Total { get; set; }
    }
}
