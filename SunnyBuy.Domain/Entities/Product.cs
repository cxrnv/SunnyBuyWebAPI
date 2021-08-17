using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SunnyBuy.Domain
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Detail { get; set; }
        public int Quantity { get; set; }
        public int Rank { get; set; }
        public bool Deleted { get; set; }

        [Column ("CategoryId")]
        public CategoryEnum CategoryEnum { get; set; }

        [ForeignKey(nameof(CategoryEnum))]
        public Category Category { get; set; }
    }
}