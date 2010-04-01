using System.Collections.Generic;
using EtherSoftware.NewsPresenter.Common;
using EtherSoftware.NewsPresenter.View.Component;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using EtherSoftware.NewsPresenter.Persistence;

namespace EtherSoftware.NewsPresenter.View
{
    public class CategoryContainerMediator : Mediator, IMediator
    {

        public CategoryContainerMediator(CategoryContainer categoryList)
        {
            this.categoryList = categoryList;
            this.categoryList.SelectionChanged += new SelectionChangedEventHandler(categoryList_SelectionChanged);
        }

        public override string MediatorName
        {
            get
            {
                return "CategoryListMediator";
            }
        }

        public override IList<string> ListNotificationInterests()
        {
            return new List<string>(){
                ApplicationFacade.SubscribeWindow,
                ApplicationFacade.AddCategory,
                ApplicationFacade.RenameCategory,
                ApplicationFacade.AddPublisher
            };
        }

        public override void HandleNotification(INotification notification)
        {
            switch (notification.Name) {
                case ApplicationFacade.SubscribeWindow:
                    Facade.SendNotification(
                        ApplicationFacade.ShowSubscribeWindow,
                        this.categoryList.GetCategories());
                    break;
                case ApplicationFacade.AddCategory:
                    this.categoryList.AddCategory(notification.Body as string);
                    Facade.SendNotification(
                        ApplicationFacade.RefreshCategory,
                        this.categoryList.GetCategories());
                    break;
                case ApplicationFacade.RenameCategory:
                    KeyValuePair<string, string> val = (KeyValuePair<string, string>)notification.Body;
                    this.categoryList.RenameCategory(val.Key, val.Value);
                    Facade.SendNotification(
                        ApplicationFacade.RefreshCategory,
                        this.categoryList.GetCategories());
                    break;
                case ApplicationFacade.AddPublisher:
                    Publisher publisher = notification.Body as Publisher;
                    this.categoryList.AddToCategory(publisher.Category.Name, publisher);
                    break;
                default:
                    break;
            }
        }

        private void categoryList_SelectionChanged(EtherSoftware.NewsPresenter.View.Component.CategoryItem category, Publisher publisher)
        {
            Facade.SendNotification(ApplicationFacade.ShowPublisher, publisher);
        }

        private CategoryContainer categoryList;
    }
}
