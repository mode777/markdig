// Copyright (c) Alexandre Mutel. All rights reserved.
// This file is licensed under the BSD-Clause 2 license. 
// See the license.txt file in the project root for more information.
using Markdig.Syntax.Inlines;

namespace Markdig.Renderers.Latex.Inlines
{
    /// <summary>
    /// A Latex renderer for a <see cref="LatexInline"/>.
    /// </summary>
    /// <seealso cref="Markdig.Renderers.Latex.LatexObjectRenderer{Markdig.Syntax.Inlines.LatexInline}" />
    public class LatexInlineRenderer : LatexObjectRenderer<HtmlInline>
    {
        protected override void Write(LatexRenderer renderer, HtmlInline obj)
        {
            if (renderer.EnableLatexForInline)
            {
                renderer.Write(obj.Tag);
            }
        }
    }
}