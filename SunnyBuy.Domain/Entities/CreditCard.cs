using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SunnyBuy.Domain
{
    public class CreditCard
    {
        [Key]
        public int CreditCardId { get; set; }
        public string Operator { get; set; }
        public string Number { get; set; }
        public string DueDate { get; set; }
        public string SecurityCode { get; set; }
        public bool Deleted { get; set; }

        public int ClientId { get; set; }

        [ForeignKey("ClientId")]
        public Client Client { get; set; }
    }
}
