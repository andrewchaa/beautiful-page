using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace BeautifulWeb
{
    public class BeautifulPage
    {
        public HtmlNode DocumentNode { get; }

        public BeautifulPage(string pageContent)
        {
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(pageContent);

            DocumentNode = htmlDocument.DocumentNode;
        }

        public BeautifulNode SelectNode(string xpath)
        {
            if (xpath.EndsWith("option"))
            {
                return new BeautifulNode(DocumentNode.SelectSingleNode(xpath).NextSibling);
            }

            return new BeautifulNode(DocumentNode.SelectSingleNode(xpath));
        }

        public IEnumerable<BeautifulNode> SelectNodes(string xpath)
        {
            var nodes = DocumentNode.SelectNodes(xpath);
            if (nodes == null || !nodes.Any()) return new List<BeautifulNode>();

            if (xpath.EndsWith("option"))
            {
                return nodes.Select(n => new BeautifulNode(n.NextSibling));
            }

            return nodes.Select(n => new BeautifulNode(n));
        }
    }
}
