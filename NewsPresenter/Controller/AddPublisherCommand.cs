using PureMVC.Interfaces;
using PureMVC.Patterns;
using EtherSoftware.NewsPresenter.Common;
using EtherSoftware.NewsPresenter.Model;

namespace EtherSoftware.NewsPresenter.Controller
{
    class AddPublisherCommand : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            PublisherProxy publisherProxy = (PublisherProxy)Facade.RetrieveProxy(CategoryProxy.NAME);
            Publisher publisher = notification.Body as Publisher;
            publisher.Id = publisherProxy.NextId;
            publisherProxy.Store(publisher);
        }
    }
}
