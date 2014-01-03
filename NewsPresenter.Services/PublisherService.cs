using EtherSoftware.NewsPresenter.Common;
using EtherSoftware.NewsPresenter.Service.Parser;
using System;
using System.Xml;

namespace EtherSoftware.NewsPresenter.Services
{
    public class PublisherService
    {
        public Publisher CreatePublisher(string source)
        {
            Publisher publisher;
            XmlDocument document = new XmlDocument();
            document.Load(source);
            IParser parser = GetParser(document);
            try {
                publisher = parser.ParsePublisher(document);
                publisher.Source = source;
            } catch (ParserException e) {
                throw new ApplicationException("Cannot parse publisher", e);
            }
            return publisher;
        }

        private IParser GetParser(XmlDocument document)
        {
            IParser parser;
            switch (document.DocumentElement.Name) {
                case "rss":
                    parser = ParserFactory.Instance.CreateParser(PublisherType.Rss);
                    break;
                default:
                    throw new ArgumentException("Unrecognized type of message");
            }
            return parser;
        }
    }
}
