using SunnyBuy.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SunnyBuy.Entities
{
    public class Category
    {
        [Key]
        [Column("CategoryId")]
        public CategoryEnum CategoryEnum { get; set; }
        public string Description { get; set; }
    }
}
