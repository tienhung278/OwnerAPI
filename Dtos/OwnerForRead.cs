using System;
using System.Collections.Generic;
using OwnerAPI.Entities;

namespace OwnerAPI.Dtos
{
    public class OwnerForRead
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string DateOfBirth { get; set; }

        public string Address { get; set; }

        public ICollection<Account> Accounts { get; set; }
    }
}