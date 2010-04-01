using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using EtherSoftware.NewsPresenter.View.Component;

namespace EtherSoftware.NewsPresenter.View {
    public class MainMenuMediator : Mediator, IMediator {

        public MainMenuMediator(MainMenu mainMenu)
            : base() {
            this.mainMenu = mainMenu;
            this.mainMenu.subscribeFileMenu.Click += new System.Windows.RoutedEventHandler(subscribeFileMenu_Click);
            this.mainMenu.newCategoryFileMenu.Click += new System.Windows.RoutedEventHandler(newCategoryFileMenu_Click);
        }

        void newCategoryFileMenu_Click(object publisher, System.Windows.RoutedEventArgs e) {
            Facade.SendNotification(ApplicationFacade.CreateCategoryWindow);
        }

        void subscribeFileMenu_Click(object publisher, System.Windows.RoutedEventArgs e) {
            Facade.SendNotification(ApplicationFacade.SubscribeWindow);
        }

        public override string MediatorName {
            get {
                return "MainMenuMediator";
            }
        }

        private MainMenu mainMenu;
    }
}
