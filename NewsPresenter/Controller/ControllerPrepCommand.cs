using PureMVC.Interfaces;
using PureMVC.Patterns;

namespace EtherSoftware.NewsPresenter.Controller
{
    class ControllerPrepCommand : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            Facade.RegisterCommand(ApplicationFacade.Subscribe, typeof(SubscribeCommand));
            Facade.RegisterCommand(ApplicationFacade.CreateCategory, typeof(AddCategoryCommand));
            Facade.RegisterCommand(ApplicationFacade.AddPublisher, typeof(AddPublisherCommand));
        }
    }
}
