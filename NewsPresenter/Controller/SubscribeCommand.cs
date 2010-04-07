using EtherSoftware.NewsPresenter.Common;
using EtherSoftware.NewsPresenter.Model.DataObject;
using EtherSoftware.NewsPresenter.Services;
using PureMVC.Interfaces;
using PureMVC.Patterns;

namespace EtherSoftware.NewsPresenter.Controller
{
    class SubscribeCommand : SimpleCommand, ICommand
    {
        public override void Execute(INotification notification)
        {
            if (notification.Name == ApplicationFacade.Subscribe) {
                PublisherService publisherService = new PublisherService();
                SubscribeDataObject sdo = notification.Body as SubscribeDataObject;
                Publisher publisher = publisherService.CreatePublisher(sdo.Source);
                publisher.Category = sdo.Category;
                Facade.SendNotification(ApplicationFacade.AddPublisher, publisher);
            }
        }
    }
}
