using System.Collections.Generic;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
   public class CustomerManager:ICustomerService
   {
       private ICustomerDal _customerDal;

       public CustomerManager(ICustomerDal customerDal)
       {
           _customerDal = customerDal;
       }
       [CacheAspect]
        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(),"Customer Listed");
        }
       [CacheAspect]
        public IDataResult<Customer> GetById(int userId)
       {
           return new SuccessDataResult<Customer>(_customerDal.Get(c=>c.UserId==userId));
       }

       [ValidationAspect(typeof(CustomerValidator))]
       [SecuredOperation("admin")]
        public IResult Add(Customer customer)   
        {
            var result = BusinessRules.Run(CheckFindeksScoreMax(customer));
            if (result != null)
            {
                return result;
            }
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
            
        }
        [SecuredOperation("admin")]
        public IResult Delete(Customer customer)
       {
           _customerDal.Delete(customer);
           return new SuccessResult(Messages.CustomerDeleted);
       }

       [ValidationAspect(typeof(CustomerValidator))]
       [SecuredOperation("admin")]
        public IResult Update(Customer customer)
        {
            var result = BusinessRules.Run(CheckFindeksScoreMax(customer));
            if (result != null)
            {

                return null;
            }
           _customerDal.Update(customer);
           return new SuccessResult(Messages.CustomerUpdated);

       }
        public IDataResult<List<CustomerDetailDto>> GetCustomerDetails()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetailDto(), "");
        }

        public IResult CheckFindeksScoreMax(Customer customer)
        {
            if (customer.FindeksScore > 1900)
            {
                return new ErrorResult(Messages.FindeksScoreMax);
            }

            return new SuccessResult(Messages.FindeksScoreSuccesful);
        }

    }
}
