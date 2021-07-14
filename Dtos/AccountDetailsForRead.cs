namespace OwnerAPI.Dtos
{
    public class AccountDetailsForRead
    {
        public string DateCreated { get; set; }
        public string AccountType { get; set; }
        public OwnerForRead Owner { get; set; }
    }
}