// Copyright (c) Alexandre Mutel. All rights reserved.
// This file is licensed under the BSD-Clause 2 license. 
// See the license.txt file in the project root for more information.
using Markdig.Syntax;

namespace Markdig.Renderers.Latex
{
    /// <summary>
    /// A Latex renderer for a <see cref="ThematicBreakBlock"/>.
    /// </summary>
    /// <seealso cref="Markdig.Renderers.Latex.LatexObjectRenderer{Markdig.Syntax.ThematicBreakBlock}" />
    public class ThematicBreakRenderer : LatexObjectRenderer<ThematicBreakBlock>
    {
        protected override void Write(LatexRenderer renderer, ThematicBreakBlock obj)
        {
            renderer.Write(@"\noindent\rule{\paperwidth}{0.4pt}")/*.WriteAttributes(obj).WriteLine(" />")*/;
        }
    }
}