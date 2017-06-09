using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace BeautifulWeb
{
    public class BeautifulPage
    {
        private readonly HtmlNode _htmlNode;

        public BeautifulPage(string pageContent)
        {
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(pageContent);

            _htmlNode = htmlDocument.DocumentNode;
        }

        public BeautifulNode SelectNode(string xpath)
        {
            if (xpath.EndsWith("option"))
            {
                return new BeautifulNode(_htmlNode.SelectSingleNode(xpath).NextSibling);
            }

            return new BeautifulNode(_htmlNode.SelectSingleNode(xpath));
        }

        public IEnumerable<BeautifulNode> SelectNodes(string xpath)
        {
            var nodes = _htmlNode.SelectNodes(xpath);
            if (nodes == null || !nodes.Any()) return new List<BeautifulNode>();

            if (xpath.EndsWith("option"))
            {
                return nodes.Select(n => new BeautifulNode(n.NextSibling));
            }

            return nodes.Select(n => new BeautifulNode(n));
        }
    }
}
