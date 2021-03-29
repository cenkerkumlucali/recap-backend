using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IFindeksService
    {
        IDataResult<List<Findeks>> GetAll();
        IDataResult<List<FindeksDetailDto>> GetFindeksDetail();
        IDataResult<List<FindeksDetailDto>> GetFindeksDetailByUserId(int userId);
        IDataResult<List<FindeksDetailDto>> GetFindeksDetailByFindeksId(int findeksId);
        IResult Add(Findeks findeks);
        IResult Delete(Findeks findeks);
        IResult Update(Findeks findeks);

    }
}