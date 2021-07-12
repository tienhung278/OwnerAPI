using System;
using System.ComponentModel.DataAnnotations;

namespace OwnerAPI.Dtos
{
    public class AccountForCreate
    {
        [Required(ErrorMessage = "Date created is required")]
        public string DateCreated { get; set; }

        [Required(ErrorMessage = "Account type is required")]
        [MaxLength(45, ErrorMessage = "Account type can't be longer than 45 characters")]
        public string AccountType { get; set; }

        [Required(ErrorMessage = "Owner id is required")]
        [MaxLength(36, ErrorMessage = "Owner id can't be longer than 36 characters")]
        [MinLength(36, ErrorMessage = "Owner id can't be shorter than 36 characters")]
        public Guid OwnerId { get; set; }
    }
}