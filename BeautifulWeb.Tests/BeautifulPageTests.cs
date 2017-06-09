using System.Collections.Generic;
using Machine.Specifications;

namespace BeautifulWeb.Tests
{
    public class BeautifulPageTests
    {
        [Subject(typeof(BeautifulPage))]
        public class SelectNodes_should_handle_empty_result
        {
            private static IEnumerable<BeautifulNode> _nodes;
            private static BeautifulPage _page;

            Establish context = () =>
            {
                string pageContent = "page content without nodes";
                _page = new BeautifulPage(pageContent);
            };

            Because of = () => _nodes = _page.SelectNodes("//div[@id='itemSizes']/ul[@id='itemSizes']/li[@class='sizeBoxIn']");

            It should_return_empty_nodes = () => _nodes.ShouldBeEmpty();
        }
    }
}
