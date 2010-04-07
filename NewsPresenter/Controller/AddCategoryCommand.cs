using EtherSoftware.NewsPresenter.Persistence;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using EtherSoftware.NewsPresenter.Model;
using EtherSoftware.NewsPresenter.Common;

namespace EtherSoftware.NewsPresenter.Controller
{
    class AddCategoryCommand : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            CategoryProxy categoryProxy =(CategoryProxy) Facade.RetrieveProxy(CategoryProxy.NAME);
            Category category = notification.Body as Category;
            category.Id = categoryProxy.NextId;
            categoryProxy.Store(category);
            SendNotification(ApplicationFacade.AddCategory, category);
        }
    }
}
