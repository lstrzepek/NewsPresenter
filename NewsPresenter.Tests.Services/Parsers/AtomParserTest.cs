using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using EtherSoftware.NewsPresenter.Service.Parser.AtomParser;
using Xunit;

namespace EtherSoftware.NewsPresenter.Tests.Services.Parsers
{
    public class AtomParserTest
    {
        [Fact]
        public void Throws_argument_null_exception_when_xml_is_null()
        {
            var parser = new AtomParser();
            Assert.Throws<ArgumentNullException>(
                () => parser.ParsePublisher(null)
            );
        }

        [Fact]
        public void Returns_not_empty_publisher_when_xml_has_single_entry()
        {
            var parser = new AtomParser();
            var xmlDocument = XmlHelper.GetAtomSingleEntryDocument();
            
            var publisher = parser.ParsePublisher(xmlDocument);
            
            Assert.NotNull(publisher);
            Assert.Equal("Example Feed", publisher.Name);
        }
    }
}
