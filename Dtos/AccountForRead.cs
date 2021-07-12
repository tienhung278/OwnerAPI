using System;
using OwnerAPI.Entities;

namespace OwnerAPI.Dtos
{
    public class AccountForRead
    {
        public Guid Id { get; set; }

        public string DateCreated { get; set; }

        public string AccountType { get; set; }

        public Owner Owner { get; set; }
    }
}