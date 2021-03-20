using Core.Entities.Concrete.Fake;
using Entities.Concrete;

namespace Entities.DTOs
{
    public class RentalPaymentDto
    {
        public Rental Rental { get; set; }
        public FakeCreditCardModel FakeCreditCardModel { get; set; }
    }
}