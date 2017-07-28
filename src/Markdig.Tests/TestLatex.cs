using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markdig.Tests
{
    [TestFixture]
    public class TestLatex
    {
        const string INPUT = @"
# MyHeader
## My subheader
### MySubparagraph
#### Subsubpara
myparagraph djnfjkd dnfjknjkf djknf
dfndjkf djknfdjkf dfknjk
* MyBullet
* My Bullet 2
* My Bullet 3
";

        [Test]
        public void TestCommon()
        {
            var latex = Markdig.Markdown.ToLatex(INPUT);
        }

    }
}
