using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SunnyBuy.Domain.Entities
{
    public class PersonType
    {
        [Key]

        [Column("PersonTypeId")]
        public PersonTypeEnum PersonTypeEnum { get; set; }
        public string Description { get; set; }
    }
}
