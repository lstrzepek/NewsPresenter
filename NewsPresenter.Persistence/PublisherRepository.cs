using EtherSoftware.NewsPresenter.Common;
using System.Collections.Generic;

namespace EtherSoftware.NewsPresenter.Persistence
{
    public class PublisherRepository : Repository<Publisher>
    {
        public IList<Publisher> FindByCategory(Category category)
        {
            return DataBaseSession.Instance.DataBase.Query<Publisher>(x => x.Category == category);
        }
    }
}
