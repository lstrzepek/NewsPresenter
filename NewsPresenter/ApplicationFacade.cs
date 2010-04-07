using EtherSoftware.NewsPresenter.Controller;
using PureMVC.Interfaces;
using PureMVC.Patterns;

namespace EtherSoftware.NewsPresenter
{
    public class ApplicationFacade : Facade, IFacade
    {

        #region Notifications
        public const string Startup = "Startup";

        public const string SubscribeWindow = "SubscribeWindow";
        public const string ShowSubscribeWindow = "ShowSubscribeWindow";

        public const string Subscribe = "Subscribe";

        public const string AddPublisher = "AddPublisher";
        public const string ShowPublisher = "ShowPublisher";

        public const string CreateCategoryWindow = "CreateCategoryWindow";
        public const string RenameCategoryWindow = "RenameCategoryWindow";
        
        public const string AddCategory = "AddCategory";
        public const string CreateCategory = "CreateCategory";
        public const string InitCategory = "InitCategory";
        public const string RefreshCategory = "RefreshCategory";
        public const string RenameCategory = "RenameCategory";


        #endregion

        public new static ApplicationFacade Instance
        {
            get
            {
                if (m_instance == null) {
                    lock (m_staticSyncRoot) {
                        if (m_instance == null)
                            m_instance = new ApplicationFacade();
                    }
                }

                return m_instance as ApplicationFacade;
            }
        }

        public void ApplicationStartup(object window)
        {
            this.SendNotification(Startup, window);
        }

        protected override void InitializeController()
        {
            base.InitializeController();
            this.RegisterCommand(Startup, typeof(StartupCommand));
        }

        protected ApplicationFacade() : base() { }
    }
}
