using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace EtherSoftware.NewsPresenter.Parser
{
    static class ParserUtility
    {
        public static string GetValueOfElement(XmlElement element, string elemName)
        {
            string value = "";
            if (element != null) {
                XmlNodeList list = element.GetElementsByTagName(elemName);
                if (list.Count > 0) {
                    value = list.Item(0).InnerText;
                }
            }
            return value;
        }

        public static string GetValueOfAtribute(XmlElement element, string elemName, string atrName)
        {
            string value = null;
            if (element != null) {
                XmlNodeList list = element.GetElementsByTagName(elemName);
                if (list.Count > 0) {
                    XmlElement elem = (XmlElement)list[0];
                    value = elem.GetAttribute(atrName);
                }
            }
            return value;
        }
    }
}
