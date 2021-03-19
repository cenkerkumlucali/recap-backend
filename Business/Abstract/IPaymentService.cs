using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IPaymentService
    {
        IResult Add(Payment fakeCard);
        IResult Delete(Payment fakeCard);
        IResult Update(Payment fakeCard);
        IDataResult<List<Payment>> GetAll();
        IDataResult<Payment> GetById(int id);
        IDataResult<List<Payment>> GetByCardNumber(string cardNumber);
        IResult IsCardExist(Payment fakeCard);
    }
}
