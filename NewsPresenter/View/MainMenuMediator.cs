using EtherSoftware.NewsPresenter.View.Component;
using PureMVC.Interfaces;
using PureMVC.Patterns;

namespace EtherSoftware.NewsPresenter.View
{
    class MainMenuMediator : Mediator
    {

        public MainMenuMediator(MainMenu mainMenu)
            : base()
        {
            this.mainMenu = mainMenu;
            this.mainMenu.subscribeFileMenu.Click += new System.Windows.RoutedEventHandler(subscribeFileMenu_Click);
            this.mainMenu.newCategoryFileMenu.Click += new System.Windows.RoutedEventHandler(newCategoryFileMenu_Click);
        }

        void newCategoryFileMenu_Click(object publisher, System.Windows.RoutedEventArgs e)
        {
            Facade.SendNotification(ApplicationFacade.CreateCategoryWindow);
        }

        void subscribeFileMenu_Click(object publisher, System.Windows.RoutedEventArgs e)
        {
            Facade.SendNotification(ApplicationFacade.SubscribeWindow);
        }

        public override string MediatorName
        {
            get
            {
                return "MainMenuMediator";
            }
        }

        private MainMenu mainMenu;
    }
}
