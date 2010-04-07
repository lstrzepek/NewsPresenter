using PureMVC.Patterns;
using EtherSoftware.NewsPresenter.Common;
using EtherSoftware.NewsPresenter.Persistence;
using System;
using System.Collections.Generic;

namespace EtherSoftware.NewsPresenter.Model
{
    class PublisherProxy : Proxy
    {
        public override void OnRegister()
        {
            publisherRepository = new Repository<Publisher>();
        }

        public void Store(Publisher publisher)
        {
            publisherRepository.Save(publisher);
        }

        public string Name { get { return "PublisherProxy"; } }
        public Guid NextId { get { return publisherRepository.NextId; } }

        private Repository<Publisher> publisherRepository;
    }
}
