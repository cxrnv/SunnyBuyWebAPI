namespace SunnyBuy.Services.CreditCardServices.Models
{
    public class CreditCardPutModel
    {
        public int ClientId { get; set; }
        public int CreditCardId { get; set; }
        public bool Deleted { get; set; }
    }
}
