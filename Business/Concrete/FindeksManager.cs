using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class FindeksManager:IFindeksService
    {
        private IFindeksDal _findeksDal;

        public FindeksManager(IFindeksDal findeksDal)
        {
            _findeksDal = findeksDal;
        }

        public IDataResult<List<Findeks>> GetAll()
        {
            return new SuccessDataResult<List<Findeks>>(_findeksDal.GetAll());
        }

        public IDataResult<List<FindeksDetailDto>> GetFindeksDetail()
        {
            return new SuccessDataResult<List<FindeksDetailDto>>(_findeksDal.GetFindeksDetail());
        }

        public IDataResult<List<FindeksDetailDto>> GetFindeksDetailByUserId(int userId)
        {
            List<FindeksDetailDto> findeksDetail = _findeksDal.GetFindeksDetail(x=>x.UserId==userId);
            return new SuccessDataResult<List<FindeksDetailDto>>(findeksDetail);
            

        }

        public IDataResult<List<FindeksDetailDto>> GetFindeksDetailByFindeksId(int findeksId)
        {
            List<FindeksDetailDto> findeksDetail = _findeksDal.GetFindeksDetail(x => x.FindeksId == findeksId);
            return new SuccessDataResult<List<FindeksDetailDto>>(findeksDetail);
        }

        public IResult Add(Findeks findeks)
        {
            _findeksDal.Add(findeks);
            return new SuccessResult(Messages.FindeksAdded);
        }

        public IResult Delete(Findeks findeks)
        {
            _findeksDal.Delete(findeks);
            return new SuccessResult(Messages.FindeksDeleted);
        }

        public IResult Update(Findeks findeks)
        {
            _findeksDal.Update(findeks);
            return new SuccessResult(Messages.FindeksUpdated);
        }
    }
}