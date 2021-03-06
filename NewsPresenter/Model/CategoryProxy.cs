﻿using System.Collections.Generic;
using EtherSoftware.NewsPresenter.Common;
using EtherSoftware.NewsPresenter.Persistence;
using PureMVC.Patterns;
using System;
using PureMVC.Interfaces;

namespace EtherSoftware.NewsPresenter.Model
{
    public class CategoryProxy : Proxy, IProxy
    {
        public new static string NAME = "CategoryProxy";
        public CategoryProxy(Repository<Category> repository)
            : base(NAME, repository)
        { }

        public override void OnRegister()
        {
            categoryRepository = Data as Repository<Category>;
            publisherRepository = new PublisherRepository();

            categories = categoryRepository.GetAll();
            foreach (var category in categories) {
                category.Publishers = publisherRepository.FindByCategory(category);
            }
            SendNotification(ApplicationFacade.InitCategory, categories);
        }

        public void Store(Category category)
        {
            categoryRepository.Save(category);
        }

        //public string Name { get { return "CategoryProxy"; } }
        public Guid NextId { get { return categoryRepository.NextId; } }
        public IList<Category> Categories { get { return this.categories; } }

        private IList<Category> categories;
        private Repository<Category> categoryRepository;
        private PublisherRepository publisherRepository;
    }
}
