// Copyright (c) Alexandre Mutel. All rights reserved.
// This file is licensed under the BSD-Clause 2 license. 
// See the license.txt file in the project root for more information.
using Markdig.Syntax.Inlines;

namespace Markdig.Renderers.Latex.Inlines
{
    /// <summary>
    /// A Latex renderer for a <see cref="LiteralInline"/>.
    /// </summary>
    /// <seealso cref="Markdig.Renderers.Latex.LatexObjectRenderer{Markdig.Syntax.Inlines.LiteralInline}" />
    public class LiteralInlineRenderer : LatexObjectRenderer<LiteralInline>
    {
        protected override void Write(LatexRenderer renderer, LiteralInline obj)
        {
            renderer.WriteEscape(ref obj.Content);
        }
    }
}