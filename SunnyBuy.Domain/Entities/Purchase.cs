using SunnyBuy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SunnyBuy.Domain
{
    public class Purchase
    {
        [Key]
        public int PurchaseId { get; set; }
        public DateTime DatePurchase { get; set; }

        [Column("PaymentTypeId")]
        public PaymentTypeEnum PaymentTypeEnum { get; set; }

        [ForeignKey(nameof(PaymentTypeEnum))]
        public PaymentType PaymentType { get; set; }

        public int ClientId { get; set; }

        [ForeignKey(nameof(ClientId))]
        public Client Client { get; set; }

        public bool Complete { get; set; }
        public int? CreditCardId { get; set; }

        [ForeignKey(nameof(CreditCardId))]
        public CreditCard CreditCard { get; set; }
        public IList<Purchase_Cart> Purchase_Carts { get; set; }
    }
}
