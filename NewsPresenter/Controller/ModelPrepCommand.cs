using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using EtherSoftware.NewsPresenter.View;

namespace EtherSoftware.NewsPresenter.Controller
{
    public class ModelPrepCommand : SimpleCommand
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

            ///TODO
            Facade.RegisterCommand(ApplicationFacade.Subscribe, typeof(SubscribeCommand));
            Facade.RegisterCommand(ApplicationFacade.AddCategory, typeof(CreateCategoryCommand));
        }
    }
}
