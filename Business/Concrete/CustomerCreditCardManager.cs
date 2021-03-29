using System.Collections.Generic;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CustomerCreditCardManager:ICustomerCreditCardService
    {
        private ICustomerCreditCardDal _customerCreditCardDal;

        public CustomerCreditCardManager(ICustomerCreditCardDal customerCreditCardDal)
        {
            _customerCreditCardDal = customerCreditCardDal;
        }

        public IDataResult<List<CustomerCreditCard>> GetAll()
        {
            return new SuccessDataResult<List<CustomerCreditCard>> (_customerCreditCardDal.GetAll());
        }

        public IDataResult<List<CustomerCreditCard>> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<CustomerCreditCard>>(
                _customerCreditCardDal.GetAll(c => c.CustomerId == customerId));
        }

        public IResult Add(CustomerCreditCard customerCreditCard)
        {
            _customerCreditCardDal.Add(customerCreditCard);
            return new SuccessResult();
        }

        public IResult Delete(CustomerCreditCard customerCreditCard)
        {
            _customerCreditCardDal.Delete(customerCreditCard);
            return new SuccessResult();
        }

        public IResult Update(CustomerCreditCard customerCreditCard)
        {
            _customerCreditCardDal.Update(customerCreditCard);
            return new SuccessResult();
        }
    }
}