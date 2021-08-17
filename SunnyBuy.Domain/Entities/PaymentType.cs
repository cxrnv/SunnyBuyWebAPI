using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SunnyBuy.Domain
{
    public class PaymentType
    {
        [Key]

        [Column("PaymentTypeId")]
        public PaymentTypeEnum PaymentTypeEnum { get; set; }
        public string Description { get; set; }
    }
}
