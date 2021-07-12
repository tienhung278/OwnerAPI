using System;
using System.ComponentModel.DataAnnotations;

namespace OwnerAPI.Entities
{
    public class Account
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Date created is required")]
        public DateTime DateCreated { get; set; }

        [Required(ErrorMessage = "Account type is required")]
        [MaxLength(45, ErrorMessage = "Account type can't be longer than 45 characters")]
        public string AccountType { get; set; }

        public Guid OwnerId { get; set; }
        public Owner Owner { get; set; }
    }
}