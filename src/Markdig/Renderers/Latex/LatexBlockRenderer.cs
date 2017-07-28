// Copyright (c) Alexandre Mutel. All rights reserved.
// This file is licensed under the BSD-Clause 2 license. 
// See the license.txt file in the project root for more information.
using Markdig.Syntax;

namespace Markdig.Renderers.Latex
{
    /// <summary>
    /// A Latex renderer for a <see cref="LatexBlock"/>.
    /// </summary>
    /// <seealso cref="Markdig.Renderers.Latex.LatexObjectRenderer{Markdig.Syntax.LatexBlock}" />
    public class LatexBlockRenderer : LatexObjectRenderer<HtmlBlock>
    {
        protected override void Write(LatexRenderer renderer, HtmlBlock obj)
        {
            renderer.WriteLeafRawLines(obj, true, false);
        }
    }
}