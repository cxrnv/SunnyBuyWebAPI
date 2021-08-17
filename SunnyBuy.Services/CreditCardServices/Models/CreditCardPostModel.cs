using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace SunnyBuy.Services.ClientServices.Models
{
    public class CreditCardPostModel
    {
        public int ClientId { get; set; }

        [MaxLength(5)]
        public string DueDate { get; set; }

        [NotNull, MaxLength(16)]
        public string Number { get; set; }

        [NotNull, MaxLength(3)]
        public string SecurityCode { get; set; }
        
        [MaxLength(20)]
        public string Operator { get; set; }

        public void Validator()
        {
            if (this.DueDate.Length != 5)
                throw new Exception("Due date invalid (00/00)");

            if (this. Number.Length != 16)
                throw new Exception("Number card invalid (it must have 16 digits)");

            if (this.SecurityCode.Length != 3)
                throw new Exception("Security code invalid");

            if (this. Operator.Length > 20 && Operator.Length < 4 )
                throw new Exception("Operator invalid");
        }
    }
}
