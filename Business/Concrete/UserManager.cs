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
   public class UserManager:IUserService
   {
       private IUserDal _userDal;

       public UserManager(IUserDal userDal)
       {
           _userDal = userDal;
       }

       public IDataResult<List<User>> GetAll()
       {
           return new SuccessDataResult<List<User>>(_userDal.GetAll());
       }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.CarAdded);
        }
    }
}
