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

        public string Href => HtmlNode?.GetAttributeValue("href", string.Empty);
        public string Src => HtmlNode?.GetAttributeValue("src", string.Empty);
        public string Text => HtmlNode?.InnerText.Trim();
        public bool HasValue => HtmlNode != null;
    }
}