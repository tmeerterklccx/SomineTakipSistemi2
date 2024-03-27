using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.EntityFramework;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MoreAskQuestionManager : IMoreAskQuestionService
    {
        private readonly IMoreAsqQuestionDal _moreAsqQuestionDal;

        public MoreAskQuestionManager(IMoreAsqQuestionDal moreAsqQuestionDal)
        {
            _moreAsqQuestionDal = moreAsqQuestionDal;
        }

        public void TDelete(MoreAskQuestion t)
        {
            _moreAsqQuestionDal.Delete(t);
        }

        public MoreAskQuestion TGetByID(int id)
        {
            return _moreAsqQuestionDal.GetByID(id);
        }

        public List<MoreAskQuestion> TGetList()
        {
            return _moreAsqQuestionDal.GetList();
        }

        public void TInsert(MoreAskQuestion t)
        {
            _moreAsqQuestionDal.Insert(t);
        }

        public void TUpdate(MoreAskQuestion t)
        {
            _moreAsqQuestionDal.Update(t);
        }
    }
}
