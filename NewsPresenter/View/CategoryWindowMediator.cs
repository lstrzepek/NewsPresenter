﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using EtherSoftware.NewsPresenter.View.Component;

namespace EtherSoftware.NewsPresenter.View {
    public class CategoryWindowMediator : Mediator, IMediator {

        public override string MediatorName {
            get {
                return "CategoryWindowMediator";
            }
        }

        public override IList<string> ListNotificationInterests() {
            return new List<string>() {
                ApplicationFacade.CreateCategoryWindow,
                ApplicationFacade.RenameCategoryWindow
            };
        }

        public override void HandleNotification(INotification notification) {
            switch (notification.Name) {
                case ApplicationFacade.CreateCategoryWindow:
                    categoryWindow = new CategoryWindow();
                    if (categoryWindow.ShowDialog().GetValueOrDefault() == true)
                        Facade.SendNotification(ApplicationFacade.AddCategory, categoryWindow.CategoryName);
                    break;
                case ApplicationFacade.RenameCategoryWindow:
                    categoryWindow = new CategoryWindow();
                    categoryWindow.CategoryName = notification.Body as string;
                    if (categoryWindow.ShowDialog().GetValueOrDefault() == true)
                        Facade.SendNotification(
                            ApplicationFacade.RenameCategory,
                            new KeyValuePair<string, string>(notification.Body as string, categoryWindow.CategoryName));
                    break;
                default:
                    break;
            }
        }

        private CategoryWindow categoryWindow;
    }
}
