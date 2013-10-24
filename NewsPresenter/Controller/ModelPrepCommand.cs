using PureMVC.Interfaces;
using PureMVC.Patterns;
using EtherSoftware.NewsPresenter.Model;
using EtherSoftware.NewsPresenter.Persistence;
using EtherSoftware.NewsPresenter.Common;

namespace EtherSoftware.NewsPresenter.Controller
{
    class ModelPrepCommand:SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            var categoryRepository = new Repository<Category>();
            var publishersRepository = new Repository<Publisher>();

            Facade.RegisterProxy(new CategoryProxy(categoryRepository));
            Facade.RegisterProxy(new PublisherProxy(publishersRepository));
        }
    }
}
