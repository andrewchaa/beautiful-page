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
        public string Id => HtmlNode?.Id;
        public string Src => HtmlNode?.GetAttributeValue("src", string.Empty);
        public string Alt => HtmlNode?.GetAttributeValue("alt", string.Empty);
        public string Class => HtmlNode?.GetAttributeValue("class", string.Empty);
        public string Rel => HtmlNode?.GetAttributeValue("rel", string.Empty);
        public string Title => HtmlNode?.GetAttributeValue("title", string.Empty);
        public string Value => HtmlNode?.GetAttributeValue("value", string.Empty);
        public string Html => HtmlNode?.InnerHtml.Trim();
        public string Text => HtmlNode?.InnerText.Trim();
        public string Name => HtmlNode?.Name;
        public bool HasValue => HtmlNode != null;
    }
}