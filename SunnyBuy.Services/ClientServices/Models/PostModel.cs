using SunnyBuy.Domain;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace SunnyBuy.Services.ClientServices.Models
{
    public class PostModel
    {
        protected readonly SunnyBuyContext context;

        [MinLength(11), StringLength(11), NotNull]
        public string Cpf { get; set; }

        [MinLength(3), MaxLength(200), NotNull, Required]
        public string Name { get; set; }

        [EmailAddress, MaxLength(100), Required, NotNull]
        public string Email { get; set; }

        [NotNull, MinLength(5)]
        public string Password { get; set; }

        [NotNull]
        public string Address { get; set; }

        [StringLength(9), NotNull]
        public string Phone { get; set; }
    }
}