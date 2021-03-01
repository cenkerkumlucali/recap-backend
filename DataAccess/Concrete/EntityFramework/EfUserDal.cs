using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, NorthwindContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new NorthwindContext())
            {
                var result = from oc in context.OperationClaims
                    join usc in context.UserOperationClaims
                        on oc.Id equals usc.OperationClaimId
                    where usc.UserId == user.Id
                    select new OperationClaim {Id = oc.Id, Name = oc.Name};
                return result.ToList();

            }
        }
    }
}
