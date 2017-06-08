using HtmlAgilityPack;

namespace BeautifulWeb
{
    public class BeautifulNode
    {
        public HtmlNode HtmlNode { get; }

        public BeautifulNode(HtmlNode htmlNode)
        {
            HtmlNode = htmlNode;
        }

        public string ToText()
        {
            return HtmlNode?.InnerText.Trim();
        }

        public string Href => HtmlNode?.GetAttributeValue("href", string.Empty);
        public string InnerText => HtmlNode?.InnerText.Trim();
        public bool HasValue => HtmlNode != null;
    }
}