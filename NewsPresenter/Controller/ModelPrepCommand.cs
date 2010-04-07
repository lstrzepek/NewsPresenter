using PureMVC.Interfaces;
using PureMVC.Patterns;
using EtherSoftware.NewsPresenter.Model;

namespace EtherSoftware.NewsPresenter.Controller
{
    class ModelPrepCommand:SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            Facade.RegisterProxy(new CategoryProxy());
            Facade.RegisterProxy(new PublisherProxy());
        }
    }
}
