﻿using System.ComponentModel.DataAnnotations;

namespace DemoMapperDTO.Models
{
    public class UserRegisteration
    {

        [Key]
        public Guid Id { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;

        
    }
}
