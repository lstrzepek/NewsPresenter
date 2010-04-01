using EtherSoftware.NewsPresenter.Common;
using EtherSoftware.NewsPresenter.Parser;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using EtherSoftware.NewsPresenter.Services;
using EtherSoftware.NewsPresenter.Model.DataObject;

namespace EtherSoftware.NewsPresenter.Controller
{
    public class SubscribeCommand : SimpleCommand, ICommand
    {
        public override void Execute(INotification notification)
        {
            if (notification.Name == ApplicationFacade.Subscribe) {
                PublisherService publisherService = new PublisherService();
                SubscribeDataObject sdo = notification.Body as SubscribeDataObject;
                Publisher publisher = publisherService.CreatePublisher(sdo.Source);
                publisher.Category = new Category();
                publisher.Category.Name = sdo.Category;
                Facade.SendNotification(ApplicationFacade.AddPublisher, publisher);
            }
        }
    }
}
