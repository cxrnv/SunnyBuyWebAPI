﻿using System.ComponentModel.DataAnnotations;

namespace SunnyBuy.Domain.Entities
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public string Position { get; set; }

    }
}
