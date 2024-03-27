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
    public class OurInfoManager : IOurInfoService
    {
        private readonly IOurInfoDal _ourInfoDal;

        public OurInfoManager(IOurInfoDal ourInfoDal)
        {
            _ourInfoDal = ourInfoDal;
        }

        public void TDelete(OurInfo t)
        {
            _ourInfoDal.Delete(t);
        }

        public OurInfo TGetByID(int id)
        {
            return _ourInfoDal.GetByID(id);
        }

        public List<OurInfo> TGetList()
        {
            return _ourInfoDal.GetList();
        }

        public void TInsert(OurInfo t)
        {
            _ourInfoDal.Insert(t);
        }

        public void TUpdate(OurInfo t)
        {
            _ourInfoDal.Update(t);
        }
    }
}
