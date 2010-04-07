using System.Collections.Generic;
using EtherSoftware.NewsPresenter.View.Component;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using EtherSoftware.NewsPresenter.Common;

namespace EtherSoftware.NewsPresenter.View
{
    class CategoryWindowMediator : Mediator
    {

        public override string MediatorName
        {
            get
            {
                return "CategoryWindowMediator";
            }
        }

        public override IList<string> ListNotificationInterests()
        {
            return new List<string>() {
                ApplicationFacade.CreateCategoryWindow,
                ApplicationFacade.RenameCategoryWindow
            };
        }

        public override void HandleNotification(INotification notification)
        {
            switch (notification.Name) {
                case ApplicationFacade.CreateCategoryWindow:
                    categoryWindow = new CategoryWindow();
                    if (categoryWindow.ShowDialog().GetValueOrDefault() == true) {
                        Category category = new Category();
                        category.Name = categoryWindow.CategoryName;
                        Facade.SendNotification(ApplicationFacade.CreateCategory, category);
                    }
                    break;
                case ApplicationFacade.RenameCategoryWindow:
                    categoryWindow = new CategoryWindow();
                    categoryWindow.CategoryName = notification.Body as string;
                    if (categoryWindow.ShowDialog().GetValueOrDefault() == true)
                        Facade.SendNotification(
                            ApplicationFacade.RenameCategory,
                            new KeyValuePair<string, string>(notification.Body as string, categoryWindow.CategoryName));
                    break;
                default:
                    break;
            }
        }

        private CategoryWindow categoryWindow;
    }
}
