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
    public class TestiMonialManager : ITestiMonialService
    {
        private readonly ITestiMonialDal _testiMonialDal;

        public TestiMonialManager(ITestiMonialDal testiMonialDal)
        {
            _testiMonialDal = testiMonialDal;
        }

        public void TDelete(TestiMonial t)
        {
            _testiMonialDal.Delete(t);
        }

        public TestiMonial TGetByID(int id)
        {
           return _testiMonialDal.GetByID(id);
        }

        public List<TestiMonial> TGetList()
        {
            return _testiMonialDal.GetList();
        }

        public void TInsert(TestiMonial t)
        {
            _testiMonialDal.Insert(t);
        }

        public void TUpdate(TestiMonial t)
        {
            _testiMonialDal.Update(t);
        }
    }
}
