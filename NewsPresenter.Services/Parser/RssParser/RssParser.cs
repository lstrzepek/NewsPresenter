using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using EtherSoftware.NewsPresenter.Common;

namespace EtherSoftware.NewsPresenter.Parser.RssParser {
    public class RssParser : IParser {
        public Publisher ParsePublisher(XmlDocument document) {
            Publisher publisher = new Publisher();
            XmlElement root = document.DocumentElement;
            if (root.Name.Equals(RssTag.Rss)) {
                XmlNodeList list = root.GetElementsByTagName(RssTag.Channel);
                if (root.FirstChild.Name == RssTag.Channel) {
                    XmlElement channel = (XmlElement)root.FirstChild;
                    publisher.Name = ParserUtility.GetValueOfElement(channel, RssTag.Title);
                    publisher.Description = ParserUtility.GetValueOfElement(channel, RssTag.Description);
                    publisher.Address = ParserUtility.GetValueOfElement(channel, RssTag.Link);
                    publisher.AddDate = DateTime.Now.ToUniversalTime();
                    publisher.Messages = new List<Message>();
                    XmlNodeList items = channel.GetElementsByTagName(RssTag.Item);
                    if (items.Count > 0) {
                        Message message;
                        for (int i = 0; i < items.Count; i++) {
                            message = new Message();
                            message.Publisher = publisher;
                            message.Name = ParserUtility.GetValueOfElement((XmlElement)items.Item(i), RssTag.Title);
                            message.Address = ParserUtility.GetValueOfElement((XmlElement)items.Item(i), RssTag.Link);
                            message.Value = ParserUtility.GetValueOfElement((XmlElement)items.Item(i), RssTag.Description);
                            message.PublishDate = DateTime.Parse(ParserUtility.GetValueOfElement((XmlElement)items.Item(i), RssTag.PublishDate));
                            message.Author = ParserUtility.GetValueOfElement((XmlElement)items.Item(i), RssTag.Author);
                            message.Viewed = false;
                            publisher.Messages.Add(message);
                        }
                    }
                    return publisher;
                }
                throw new ParserException("Bad xml tag. Expected " + RssTag.Channel + " but was: " + root.FirstChild);
            }
            throw new ParserException("Bad root xml tag. Expected " + RssTag.Rss + " but was: " + root);
        }
    }
}
