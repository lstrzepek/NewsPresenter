using EtherSoftware.NewsPresenter.View.Component;
using PureMVC.Interfaces;
using PureMVC.Patterns;

namespace EtherSoftware.NewsPresenter.View
{
    class CategoryContainerMenuMediator : Mediator
    {

        public CategoryContainerMenuMediator(CategoryContainerMenu categoryContainerMenu)
        {
            this.categoryContainerMenu = categoryContainerMenu;
            this.categoryContainerMenu.newCategoryFileMenu.Click += new System.Windows.RoutedEventHandler(newCategoryFileMenu_Click);
        }

        void newCategoryFileMenu_Click(object publisher, System.Windows.RoutedEventArgs e)
        {
            Facade.SendNotification(ApplicationFacade.CreateCategoryWindow);
        }

        private CategoryContainerMenu categoryContainerMenu;
    }
}
