using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Db4objects.Db4o;

namespace EtherSoftware.NewsPresenter.Persistence
{
    class DataBaseSession
    {
        public IObjectContainer DataBase { get { return db; } }
        private static IObjectContainer db;

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static DataBaseSession()
        {
        }

        private DataBaseSession()
        {
            db = Db4oEmbedded.OpenFile(Properties.Settings.Default.DataBaseFile);
        }

        public static DataBaseSession Instance
        {
            get
            {
                return instance;
            }
        }

        static readonly DataBaseSession instance = new DataBaseSession();
    }
}
