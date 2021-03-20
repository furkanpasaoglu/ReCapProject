namespace Core.Entities.Concrete.Fake
{
    public class FakeCreditCardModel : IPaymentModel
    {
        public string CardHolderName { get; set; }
        public int ExpirationMonth { get; set; }
        public int ExpirationYear { get; set; }
        public string CardNumber { get; set; }
        public string Cvv { get; set; }
    }
}