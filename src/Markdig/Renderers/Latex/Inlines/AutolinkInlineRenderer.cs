// Copyright (c) Alexandre Mutel. All rights reserved.
// This file is licensed under the BSD-Clause 2 license. 
// See the license.txt file in the project root for more information.
using Markdig.Syntax.Inlines;

namespace Markdig.Renderers.Latex.Inlines
{
    /// <summary>
    /// A Latex renderer for an <see cref="AutolinkInline"/>.
    /// </summary>
    /// <seealso cref="Markdig.Renderers.Latex.LatexObjectRenderer{Markdig.Syntax.Inlines.AutolinkInline}" />
    public class AutolinkInlineRenderer : LatexObjectRenderer<AutolinkInline>
    {
        /// <summary>
        /// Gets or sets a value indicating whether to always add rel="nofollow" for links or not.
        /// </summary>
        public bool AutoRelNoFollow { get; set; }

        protected override void Write(LatexRenderer renderer, AutolinkInline obj)
        {
            if (renderer.EnableLatexForInline)
            {
                renderer.Write("<a href=\"");
                if (obj.IsEmail)
                {
                    renderer.Write("mailto:");
                }
                renderer.Write(obj.Url);
                renderer.WriteAttributes(obj);

                if (!obj.IsEmail && AutoRelNoFollow)
                {
                    renderer.Write(" rel=\"nofollow\"");
                }

                renderer.Write("\">");
            }

            renderer.WriteEscape(obj.Url);

            if (renderer.EnableLatexForInline)
            {
                renderer.Write("</a>");
            }
        }
    }
}