// Copyright (c) Alexandre Mutel. All rights reserved.
// This file is licensed under the BSD-Clause 2 license. 
// See the license.txt file in the project root for more information.
using Markdig.Syntax.Inlines;

namespace Markdig.Renderers.Latex.Inlines
{
    /// <summary>
    /// A Latex renderer for a <see cref="LatexEntityInline"/>.
    /// </summary>
    /// <seealso cref="Markdig.Renderers.Latex.LatexObjectRenderer{Markdig.Syntax.Inlines.LatexEntityInline}" />
    public class LatexEntityInlineRenderer : LatexObjectRenderer<HtmlEntityInline>
    {
        protected override void Write(LatexRenderer renderer, HtmlEntityInline obj)
        {
            renderer.WriteEscape(obj.Transcoded);
        }
    }
}