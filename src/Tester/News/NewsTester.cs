using System.ComponentModel;
using Xunit;

namespace Tester.News
{
    public class NewsTester
    {
        [Category("新闻")]
        [Fact(DisplayName="新增新闻")]
        public void Add()
        {
            int a = 10;
            Assert.Equal<int>(10, a);
        }
    }
}
