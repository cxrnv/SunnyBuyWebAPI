using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SunnyBuy.Domain
{
    public class Category
    {
        [Key]
        [Column("CategoryId")]
        public CategoryEnum CategoryEnum { get; set; }
        public string Description { get; set; }
    }
}
