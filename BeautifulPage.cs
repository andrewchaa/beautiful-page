using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace BeautifulWeb
{
    public class BeautifulPage
    {
        private readonly HtmlDocument _htmlDocument;

        public BeautifulPage(string pageContent)
        {
            _htmlDocument = new HtmlDocument();
            _htmlDocument.LoadHtml(pageContent);
        }

        public BeautifulNode SelectNode(string xpath)
        {
            if (xpath.EndsWith("option"))
            {
                return new BeautifulNode(_htmlDocument.DocumentNode.SelectSingleNode(xpath).NextSibling);
            }

            return new BeautifulNode(_htmlDocument.DocumentNode.SelectSingleNode(xpath));
        }

        public IEnumerable<BeautifulNode> SelectNodes(string xpath)
        {
            if (xpath.EndsWith("option"))
            {
                return _htmlDocument.DocumentNode.SelectNodes(xpath).Select(n => new BeautifulNode(n.NextSibling));
            }

            return _htmlDocument.DocumentNode.SelectNodes(xpath).Select(n => new BeautifulNode(n));
        }
    }
}
