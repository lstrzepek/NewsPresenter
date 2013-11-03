using System;
using System.Collections.Generic;
using System.Xml;
using EtherSoftware.NewsPresenter.Common;

namespace EtherSoftware.NewsPresenter.Service.Parser.AtomParser {
    public class AtomParser : IParser {
        public Publisher ParsePublisher(XmlDocument document) {
            if (document != null)
                return new Publisher();

            return null;
            //Publisher publisher = null;
            //XmlElement root = document.DocumentElement;
            //if (root.Name.Equals(AtomTag.Feed)) {

            //    publisher = new Publisher();
            //    publisher.Name = ParserUtility.GetValueOfElement(root, AtomTag.Title);
            //    publisher.Description = ParserUtility.GetValueOfElement(root, AtomTag.Subtitle);
            //    publisher.Address = ParserUtility.GetValueOfAtribute(root, AtomTag.Link, "href");

            //    XmlNodeList entries = root.GetElementsByTagName(AtomTag.Entry);
            //    if (entries.Count > 0) {
            //        publisher.Messages = new List<Message>();
            //        Message message;
            //        for (int i = 0; i < entries.Count; i++) {
            //            message = new Message();
            //            message.Name = ParserUtility.GetValueOfElement((XmlElement)entries.Item(i), AtomTag.Title);
            //            message.Address = ParserUtility.GetValueOfAtribute((XmlElement)entries.Item(i), AtomTag.Link, "href");
            //            string desc = ParserUtility.GetValueOfElement((XmlElement)entries.Item(i), AtomTag.Summary);
            //            message.Value = (desc != null) ? desc : ParserUtility.GetValueOfElement((XmlElement)entries.Item(i), AtomTag.Content);
            //            message.PublishDate = DateTime.Parse(ParserUtility.GetValueOfElement((XmlElement)entries.Item(i), AtomTag.Published));
            //            message.Author = ParserUtility.GetValueOfElement((XmlElement)entries.Item(i), AtomTag.Author);
            //            message.Viewed = false;
            //            publisher.Messages.Add(message);
            //        }
            //    }
            //    return publisher;
            //}
            //throw new ParserException("Bad header xml");
        }
    }
}
