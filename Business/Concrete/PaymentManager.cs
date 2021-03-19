using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        IFakeCardDal _fakeCardDal;

        public PaymentManager(IFakeCardDal fakeCardDal)
        {
            _fakeCardDal = fakeCardDal;
        }

        public IResult Add(Payment fakeCard)
        {
            _fakeCardDal.Add(fakeCard);
            return new SuccessResult();
        }

        public IResult Delete(Payment fakeCard)
        {
            _fakeCardDal.Delete(fakeCard);
            return new SuccessResult();
        }

        public IDataResult<List<Payment>> GetAll()
        {
            return new SuccessDataResult<List<Payment>>(_fakeCardDal.GetAll());
        }

        public IDataResult<Payment> GetById(int id)
        {
            return new SuccessDataResult<Payment>(_fakeCardDal.Get(c => c.Id == id));
        }

        public IDataResult<List<Payment>> GetByCardNumber(string cardNumber)
        {
            return new SuccessDataResult<List<Payment>>(_fakeCardDal.GetAll(c => c.CardNumber == cardNumber));
        }

        public IResult IsCardExist(Payment fakeCard)
        {
            var result = _fakeCardDal.Get(c =>
                c.NameOnTheCard == fakeCard.NameOnTheCard && c.CardNumber == fakeCard.CardNumber &&
                c.CardCvv == fakeCard.CardCvv);
            if (result == null)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }

        public IResult Update(Payment fakeCard)
        {
            _fakeCardDal.Update(fakeCard);
            return new SuccessResult();
        }
    }
}
