using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete.Fake;
using Core.Utilities.Results;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        [ValidationAspect(typeof(FakePaymentValidator))]
        [PerformanceAspect(5)]
        [TransactionScopeAspect]
        public IResult MakePayment(IPaymentModel paymentModel)
        {
            return new SuccessResult();
        }
    }
}