using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using EtherSoftware.NewsPresenter.Service.Parser.AtomParser;
using Xunit;

namespace NewsPresenter.Tests.Services.Parsers
{
    public class AtomParserTest
    {
        [Fact]
        public void Returns_publisher_when_xmlDocument_is_not_null()
        {
            // Arrange
            var xmlDocument = new XmlDocument();
            var parser = new AtomParser();
            // Act
            var publisher = parser.ParsePublisher(xmlDocument);
            // Assert
            Assert.NotNull(publisher);
        }   
    }
}
