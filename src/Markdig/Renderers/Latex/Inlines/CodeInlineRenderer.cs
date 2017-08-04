// Copyright (c) Alexandre Mutel. All rights reserved.
// This file is licensed under the BSD-Clause 2 license. 
// See the license.txt file in the project root for more information.
using Markdig.Syntax.Inlines;

namespace Markdig.Renderers.Latex.Inlines
{
    /// <summary>
    /// A HTML renderer for a <see cref="CodeInline"/>.
    /// </summary>
    /// <seealso cref="Markdig.Renderers.Latex.LatexObjectRenderer{Markdig.Syntax.Inlines.CodeInline}" />
    public class CodeInlineRenderer : LatexObjectRenderer<CodeInline>
    {
        protected override void Write(LatexRenderer renderer, CodeInline obj)
        {
            if (renderer.EnableLatexForInline)
            {
                renderer.Write("\\verb|")/*.WriteAttributes(obj).Write(">")*/;
            }
            renderer.WriteEscape(obj.Content);
            if (renderer.EnableLatexForInline)
            {
                renderer.Write("|");
            }
        }
    }
}