using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EtherSoftware.NewsPresenter.Common;
using Db4objects.Db4o;

namespace EtherSoftware.NewsPresenter.Persistence
{
    public abstract class Repository<TServiceObject>
    {
        public abstract void Save(TServiceObject obj);
        
        protected static IObjectContainer DataBase { get { return db; } }
        
        private static readonly IObjectContainer db = Db4oEmbedded.OpenFile(Properties.Settings.Default.DataBaseFile);
    }
}
