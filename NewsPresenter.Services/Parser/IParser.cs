using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using EtherSoftware.NewsPresenter.Common;

namespace EtherSoftware.NewsPresenter.Service.Parser
{
    interface IParser {
        Publisher ParsePublisher(XmlDocument document);
    }
}
