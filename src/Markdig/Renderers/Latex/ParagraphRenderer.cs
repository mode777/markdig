// Copyright (c) Alexandre Mutel. All rights reserved.
// This file is licensed under the BSD-Clause 2 license. 
// See the license.txt file in the project root for more information.
using Markdig.Syntax;

namespace Markdig.Renderers.Latex
{
    /// <summary>
    /// A Latex renderer for a <see cref="ParagraphBlock"/>.
    /// </summary>
    /// <seealso cref="Markdig.Renderers.Latex.LatexObjectRenderer{Markdig.Syntax.ParagraphBlock}" />
    public class ParagraphRenderer : LatexObjectRenderer<ParagraphBlock>
    {
        protected override void Write(LatexRenderer renderer, ParagraphBlock obj)
        {
            if (!renderer.ImplicitParagraph)
            {
                if (!renderer.IsFirstInContainer)
                {
                    renderer.EnsureLine();
                }
                //renderer.Write("\n")/*.WriteAttributes(obj).Write(">")*/;
            }
            renderer.WriteLeafInline(obj);
            if (!renderer.ImplicitParagraph)
            {
                //renderer.WriteLine("</p>");
            }
        }
    }
}