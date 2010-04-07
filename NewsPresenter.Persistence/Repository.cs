using System;
using System.Collections.Generic;
using EtherSoftware.NewsPresenter.Common;

namespace EtherSoftware.NewsPresenter.Persistence
{
    public class Repository<TServiceObject> where TServiceObject : class, IServiceObject, new()
    {
        public virtual TServiceObject FindById(Guid id)
        {
            return DataBaseSession.Instance.DataBase.QueryByExample(new TServiceObject() { Id = id }).Next() as TServiceObject;
        }

        public virtual IList<TServiceObject> GetAll()
        {
            return DataBaseSession.Instance.DataBase.Query<TServiceObject>();
        }

        public virtual void Save(TServiceObject obj)
        {
            DataBaseSession.Instance.DataBase.Store(obj);
            DataBaseSession.Instance.DataBase.Commit();
        }

        public Guid NextId { get { return Guid.NewGuid(); } }

        //protected static IObjectContainer DataBase
        //{
        //    get
        //    {
        //        if (db == null) {
        //            lock (dbLock) {
        //                if (db == null) {
        //                    db = Db4oEmbedded.OpenFile(Properties.Settings.Default.DataBaseFile);
        //                }
        //            }
        //        }
        //        return db;
        //    }
        //}

        //private static IObjectContainer db;
        //private static object dbLock = new object();
    }
}
