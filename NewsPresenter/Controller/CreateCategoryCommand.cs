using EtherSoftware.NewsPresenter.Persistence;
using PureMVC.Interfaces;
using PureMVC.Patterns;

namespace EtherSoftware.NewsPresenter.Controller {
    class CreateCategoryCommand : SimpleCommand, ICommand {
        public override void Execute(INotification notification) {
            //CategoryRepository repository = new CategoryRepository();
            //repository.Save(new EtherSoftware.NewsPresenter.Common.Category() { Name = notification.Body as string });
        }
    }
}
