using EtherSoftware.NewsPresenter.View;
using PureMVC.Interfaces;
using PureMVC.Patterns;

namespace EtherSoftware.NewsPresenter.Controller
{
    class ViewPrepCommand : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            MainWindow window = notification.Body as MainWindow;
            Facade.RegisterMediator(new MainMenuMediator(window.mainMenu));
            Facade.RegisterMediator(new CategoryContainerMediator(window.categoryContainer));
            Facade.RegisterMediator(new CategoryContainerMenuMediator(window.categoryContainer.menu));
            Facade.RegisterMediator(new NewsViewContainerMediator(window.newsViewContainer));

            Facade.RegisterMediator(new SubscribeWindowMediator());
            Facade.RegisterMediator(new CategoryWindowMediator());
        }
    }
}
