using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EtherSoftware.NewsPresenter.Common;


namespace EtherSoftware.NewsPresenter.Persistence
{
    public class CategoryRepository : Repository<Category>
    {
        public IList<Category> GetAll()
        {
            return DataBase.Query<Category>();
        }

        public override void Save(Category category)
        {
            DataBase.Store(category);
            DataBase.Commit();
        }
    }
}
