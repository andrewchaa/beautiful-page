using System.Collections.Generic;
using Machine.Specifications;

namespace BeautifulWeb.Tests
{
    public class BeautifulPageTests
    {
        private static BeautifulPage _page;


        [Subject(typeof(BeautifulPage))]
        public class SelectNodes_should_handle_empty_result
        {
            private static IEnumerable<BeautifulNode> _nodes;

            Establish context = () =>
            {
                string pageContent = "page content without nodes";
                _page = new BeautifulPage(pageContent);
            };

            Because of = () => _nodes = _page.SelectNodes("//div[@id='itemSizes']/ul[@id='itemSizes']/li[@class='sizeBoxIn']");

            It should_return_empty_nodes = () => _nodes.ShouldBeEmpty();
        }

        [Subject(typeof(BeautifulPage))]
        public class Text_should_replace_br_with_carriage_return
        {
            private static BeautifulNode _node;

            Establish context = () =>
            {
                string pageContent = "<div id=\"test\">Paragraph1\r\nParagraph2</div>";
                _page = new BeautifulPage(pageContent);
            };

            Because of = () => _node = _page.SelectNode("//div[@id='test']");

            It should_replace_br_with_carriage_return = () => _node.Text.ShouldEqual("Paragraph1<br />Paragraph2");
        }


    }
}
