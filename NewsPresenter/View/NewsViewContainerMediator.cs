using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using EtherSoftware.NewsPresenter.View.Component;
using EtherSoftware.NewsPresenter.Common;

namespace EtherSoftware.NewsPresenter.View {
    public class NewsViewContainerMediator : Mediator, IMediator {

        public NewsViewContainerMediator(NewsViewContainer newsViewContainer) {
            this.newsViewContainer = newsViewContainer;
        }

        public override string MediatorName {
            get {
                return "NewsViewContainerMediator";
            }
        }

        public override IList<string> ListNotificationInterests() {
            return new List<string>(){
                ApplicationFacade.ShowPublisher
            };
        }

        public override void HandleNotification(INotification notification) {
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
