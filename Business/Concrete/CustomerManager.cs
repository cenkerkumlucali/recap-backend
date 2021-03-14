using System.Collections.Generic;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

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
        public IDataResult<Customer> GetById(int customerId)
       {
           return new SuccessDataResult<Customer>(_customerDal.Get(c=>c.CustomerId==customerId));
       }

       [ValidationAspect(typeof(CustomerValidator))]
       [SecuredOperation("admin")]
        public IResult Add(Customer customer)
        {
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
           _customerDal.Update(customer);
           return new SuccessResult(Messages.CustomerUpdated);

       }
   }
}
