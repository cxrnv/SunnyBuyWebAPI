using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SunnyBuy.Domain.Entities
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        public string Description { get; set; }
        public DateTime DateMessage { get; set; }

        public int ClientId { get; set; }

        [ForeignKey(nameof(ClientId))]
        public Client Client { get; set; }

        public int EmployeeId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }

        [Column("PersonTypeId")]
        public PersonTypeEnum PersonTypeEnum { get; set; }

        [ForeignKey(nameof(PersonTypeEnum))]
        public PersonType PersonType { get; set; }
    }
}
