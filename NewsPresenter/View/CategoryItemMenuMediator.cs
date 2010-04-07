using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PureMVC.Patterns;
using EtherSoftware.NewsPresenter.View.Component;

namespace EtherSoftware.NewsPresenter.View
{
    class CategoryItemMenuMediator : Mediator
    {
        public CategoryItemMenuMediator(CategoryItem categoryItem)
        {
            this.categoryItem = categoryItem;
            this.categoryItem.menu.subscribeMenuItem.Click += new System.Windows.RoutedEventHandler(subscribeMenuItem_Click);
        }

        public override string MediatorName
        {
            get
            {
                return "CategoryItemMenuMediator";
            }
        }

        private void subscribeMenuItem_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Facade.SendNotification(ApplicationFacade.SubscribeWindow, categoryItem.Category);
        }

        private CategoryItem categoryItem;
    }
}
