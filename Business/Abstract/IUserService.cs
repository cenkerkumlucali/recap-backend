using System.Collections.Generic;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<User> GetByUserId(int userId);
        List<OperationClaim> GetClaims(User user);
        User GetByMail(string email);
        IResult Add(User user);
        IResult EditProfil(User user,string password);
        IResult Delete(User user);
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetUserByEmail(string email);
        IDataResult<User> GetById(int id);




    }
}
