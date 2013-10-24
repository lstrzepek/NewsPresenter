using PureMVC.Patterns;
using EtherSoftware.NewsPresenter.Common;
using EtherSoftware.NewsPresenter.Persistence;
using System;
using System.Collections.Generic;

namespace EtherSoftware.NewsPresenter.Model
{
    public class PublisherProxy : Proxy
    {
        public new static string NAME = "PublisherProxy";
        public PublisherProxy(Repository<Publisher> repository)
            : base(NAME, repository)
        { publisherRepository = repository; }

        public void Store(Publisher publisher)
        {
            publisherRepository.Save(publisher);
        }

        public Guid NextId { get { return publisherRepository.NextId; } }

        private Repository<Publisher> publisherRepository;
    }
}
