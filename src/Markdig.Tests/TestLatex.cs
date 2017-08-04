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
        [Test]
        public void TestHeading()
        {
            var latex = Markdown.ToLatex("# Head\n## Head2\n### Head3\n#### Head4\n##### Head5");
            Assert.AreEqual(latex, "\\section{Head}\n\\subsection{Head2}\n\\subsubsection{Head3}\n\\paragraph{Head4}\n\\subparagraph{Head5}\n");
        }

        [Test]
        public void TestEmphBold1()
        {
            var latex = Markdown.ToLatex("**bold**");
            Assert.AreEqual(latex, "\\textbf{bold}");
        }

        [Test]
        public void TestEmphBold2()
        {
            var latex = Markdown.ToLatex("__bold__");
            Assert.AreEqual(latex, "\\textbf{bold}");
        }

        [Test]
        public void TestEmphItalic1()
        {
            var latex = Markdown.ToLatex("*italic*");
            Assert.AreEqual(latex, "\\textit{italic}");
        }

        [Test]
        public void TestEmphItalic2()
        {
            var latex = Markdown.ToLatex("_italic_");
            Assert.AreEqual(latex, "\\textit{italic}");
        }

        [Test]
        public void TestUnsortedList1()
        {
            var latex = Markdown.ToLatex("- Bullet1\n- Bullet2");
            Assert.AreEqual(latex, "\\begin{itemize}\n    \\item Bullet1\n    \\item Bullet2\n\\end{itemize}\n");
        }

        [Test]
        public void TestUnsortedList2()
        {
            var latex = Markdown.ToLatex("* Bullet1\n* Bullet2");
            Assert.AreEqual(latex, "\\begin{itemize}\n    \\item Bullet1\n    \\item Bullet2\n\\end{itemize}\n");
        }

        [Test]
        public void TestSortedList()
        {
            var latex = Markdown.ToLatex("1. Bullet1\n2. Bullet2");
            Assert.AreEqual(latex, "\\begin{enumerate}\n    \\item Bullet1\n    \\item Bullet2\n\\end{enumerate}\n");
        }

        [Test]
        public void TestVerbatim()
        {
            var latex = Markdown.ToLatex("`code`");
            Assert.AreEqual(latex, "\\verb|code|");
        }

        [Test]
        public void TestCite()
        {
            var latex = Markdown.ToLatex(@"[S.132](c:id)");
            Assert.AreEqual(latex, @"\cite[S.132]{id}");
        }

        [Test]
        public void TestRef()
        {
            var latex = Markdown.ToLatex(@"[](id)");
            Assert.AreEqual(latex, @"\ref{id}");
        }

        [Test]
        public void TestImage()
        {
            var latex = Markdown.ToLatex(@"![id:My Caption](my/path.png:0.5)");
            Assert.AreEqual(latex, "\\begin{figure}\n    \\centering\n    \\includegraphics[width=0.5\\textwidth]{my/path.png}\n    \\caption{\\label{id}My Caption}\n\\end{figure}");
        }

        [Test]
        public void TestCode()
        {
            var latex = Markdown.ToLatex("```csharp:mylabel:mycapt\ncode\n```");
            Assert.AreEqual(latex, "\\begin{lstlisting}[language=csharp,label=mylabel,caption=mycapt]\ncode\n\\end{lstlisting}");
        }

    }
}
