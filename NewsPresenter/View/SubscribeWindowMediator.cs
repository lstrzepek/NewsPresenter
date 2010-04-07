using System.Collections.Generic;
using EtherSoftware.NewsPresenter.Model.DataObject;
using EtherSoftware.NewsPresenter.View.Component;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using EtherSoftware.NewsPresenter.Common;

namespace EtherSoftware.NewsPresenter.View
{
    class SubscribeWindowMediator : Mediator
    {

        public SubscribeWindowMediator()
            : base() { }

        public override string MediatorName
        {
            get
            {
                return "SubscribeWindowMediator";
            }
        }

        public override IList<string> ListNotificationInterests()
        {
            return new List<string>(){
                ApplicationFacade.ShowSubscribeWindow,
                ApplicationFacade.AddCategory
            };
        }

        public override void HandleNotification(INotification notification)
        {
            switch (notification.Name) {
                case ApplicationFacade.ShowSubscribeWindow:
                    ShowSubscribeWindowHandler(notification);
                    break;
                case ApplicationFacade.AddCategory:
                    AddCategoryHandler(notification);
                    break;
                default:
                    break;
            }

        }

        private void ShowSubscribeWindowHandler(INotification notification)
        {
            subscribeWindow = new SubscribeWindow();
            subscribeWindow.newCategoryButton.Click +=
                new System.Windows.RoutedEventHandler(newCategoryButton_Click);
            subscribeWindow.subscribeButton.Click +=
                new System.Windows.RoutedEventHandler(subscribeButton_Click);

            subscribeWindow.SetCategories(notification.Body as IList<Category>);
            //subscribeWindow.SelectCategory(
            subscribeWindow.ShowDialog();
        }

        private void AddCategoryHandler(INotification notification)
        {
            if (subscribeWindow != null) {
                Category category = notification.Body as Category;
                subscribeWindow.AddCategory(category);
                subscribeWindow.SelectCategory(category);
            }
        }

        private void subscribeButton_Click(object publisher, System.Windows.RoutedEventArgs e)
        {
            Facade.SendNotification(
                ApplicationFacade.Subscribe,
                new SubscribeDataObject() {
                    Category = this.subscribeWindow.Category,
                    Source = this.subscribeWindow.Source
                });
        }

        private void newCategoryButton_Click(object publisher, System.Windows.RoutedEventArgs e)
        {
            Facade.SendNotification(ApplicationFacade.CreateCategoryWindow);
        }

        private SubscribeWindow subscribeWindow;
    }
}
