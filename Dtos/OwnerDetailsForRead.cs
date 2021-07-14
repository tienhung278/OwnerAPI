using System.Collections.Generic;

namespace OwnerAPI.Dtos
{
    public class OwnerDetailsForRead
    {
        public string Name { get; set; }
        public string DateOfBirth { get; set; }
        public IEnumerable<AccountForRead> Accounts { get; set; }
    }
}