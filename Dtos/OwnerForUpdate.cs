using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using OwnerAPI.Entities;

namespace OwnerAPI.Dtos
{
    public class OwnerForUpdate
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        public string DateOfBirth { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [MaxLength(100, ErrorMessage = "Address can't be longer than 100 characters")]
        public string Address { get; set; }
    }
}