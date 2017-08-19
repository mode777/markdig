// Copyright (c) Alexandre Mutel. All rights reserved.
// This file is licensed under the BSD-Clause 2 license. 
// See the license.txt file in the project root for more information.
using System.Globalization;
using Markdig.Syntax;

namespace Markdig.Renderers.Latex
{
    /// <summary>
    /// An Latex renderer for a <see cref="HeadingBlock"/>.
    /// </summary>
    /// <seealso cref="Markdig.Renderers.Latex.LatexObjectRenderer{Markdig.Syntax.HeadingBlock}" />
    public class HeadingRenderer : LatexObjectRenderer<HeadingBlock>
    {
        private static readonly string[] HeadingTexts = {
            "section",
            "subsection",
            "subsubsection",
            "paragraph",
            "subparagraph",
        };

        protected override void Write(LatexRenderer renderer, HeadingBlock obj)
        {
            var headingText = obj.Level > 0 && obj.Level <= HeadingTexts.Length
                ? HeadingTexts[obj.Level - 1]
                : obj.Level.ToString(CultureInfo.InvariantCulture);

            renderer.Write("\n\\").Write(headingText)/*.WriteAttributes(obj)*/.Write("{");
            renderer.WriteLeafInline(obj);
            renderer.Write("}\n")/*.Write(headingText).WriteLine(">")*/;
        }
    }
}