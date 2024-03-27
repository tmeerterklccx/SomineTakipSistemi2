using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class GetContactManager : IGetContactService
    {
        private readonly IGetContactDal _getContactDal;

        public GetContactManager(IGetContactDal getContactDal)
        {
            _getContactDal = getContactDal;
        }

        public void TDelete(GetContact t)
        {
            _getContactDal.Delete(t);
        }

        public GetContact TGetByID(int id)
        {
            return _getContactDal.GetByID(id);
        }

        public List<GetContact> TGetList()
        {
            return _getContactDal.GetList();
        }

        public void TInsert(GetContact t)
        {
            _getContactDal.Insert(t);
        }

        public void TUpdate(GetContact t)
        {
            _getContactDal.Update(t);
        }
    }
}
