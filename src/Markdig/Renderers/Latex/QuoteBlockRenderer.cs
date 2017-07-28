// Copyright (c) Alexandre Mutel. All rights reserved.
// This file is licensed under the BSD-Clause 2 license. 
// See the license.txt file in the project root for more information.
using Markdig.Syntax;

namespace Markdig.Renderers.Latex
{
    /// <summary>
    /// A Latex renderer for a <see cref="QuoteBlock"/>.
    /// </summary>
    /// <seealso cref="Markdig.Renderers.Latex.LatexObjectRenderer{Markdig.Syntax.QuoteBlock}" />
    public class QuoteBlockRenderer : LatexObjectRenderer<QuoteBlock>
    {
        protected override void Write(LatexRenderer renderer, QuoteBlock obj)
        {
            renderer.EnsureLine();
            renderer.Write(@"\begin{quote}")/*.WriteAttributes(obj).WriteLine(">")*/;
            var savedImplicitParagraph = renderer.ImplicitParagraph;
            renderer.ImplicitParagraph = false;
            renderer.WriteChildren(obj);
            renderer.ImplicitParagraph = savedImplicitParagraph;
            renderer.WriteLine(@"\end{quote}");
        }
    }
}