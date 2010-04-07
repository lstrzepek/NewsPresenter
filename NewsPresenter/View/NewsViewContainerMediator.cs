using System.Collections.Generic;
using EtherSoftware.NewsPresenter.Common;
using EtherSoftware.NewsPresenter.View.Component;
using PureMVC.Interfaces;
using PureMVC.Patterns;

namespace EtherSoftware.NewsPresenter.View
{
    class NewsViewContainerMediator : Mediator
    {

        public NewsViewContainerMediator(NewsViewContainer newsViewContainer)
        {
            this.newsViewContainer = newsViewContainer;
        }

        public override string MediatorName
        {
            get
            {
                return "NewsViewContainerMediator";
            }
        }

        public override IList<string> ListNotificationInterests()
        {
            return new List<string>(){
                ApplicationFacade.ShowPublisher
            };
        }

        public override void HandleNotification(INotification notification)
        {
            switch (notification.Name) {
                case ApplicationFacade.ShowPublisher:
                    this.newsViewContainer.ShowView(notification.Body as Publisher);
                    break;
                default:
                    break;
            }
        }

        private NewsViewContainer newsViewContainer;
    }
}
