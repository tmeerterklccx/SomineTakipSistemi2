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
    public class MainTopManager : IMainTopService
    {
        private readonly IMainTopDal _mainTopDal;

        public MainTopManager(IMainTopDal mainTopDal)
        {
            _mainTopDal = mainTopDal;
        }

        public void TDelete(MainTop t)
        {
            _mainTopDal.Delete(t);
        }

        public MainTop TGetByID(int id)
        {
            return _mainTopDal.GetByID(id);
        }

        public List<MainTop> TGetList()
        {
            return _mainTopDal.GetList();
        }

        public void TInsert(MainTop t)
        {
            _mainTopDal.Insert(t);
        }

        public void TUpdate(MainTop t)
        {
            _mainTopDal.Update(t);
        }
    }
}
