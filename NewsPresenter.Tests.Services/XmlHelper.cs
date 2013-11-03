using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace EtherSoftware.NewsPresenter.Tests.Services
{
    class XmlHelper
    {
        public static XmlDocument GetAtomSingleEntryDocument()
        {
            var xmlDocument = new XmlDocument();

            var assembly = Assembly.GetExecutingAssembly();
            var stream = assembly.GetManifestResourceStream("EtherSoftware.NewsPresenter.Tests.Services.SampleData.AtomSingleEntry.xml");

             xmlDocument.Load(stream);
             return xmlDocument;
        }
    }
}
