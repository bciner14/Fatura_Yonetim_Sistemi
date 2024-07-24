namespace ApartmentManagement.Models
{
    public class CreditCardInfo
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string CardNumber { get; set; }
        public decimal Balance { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
