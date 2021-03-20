using Core.Entities.Concrete.Fake;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IPaymentService
    {
        IResult MakePayment(IPaymentModel paymentModel);
    }
}