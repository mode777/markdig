// Copyright (c) Alexandre Mutel. All rights reserved.
// This file is licensed under the BSD-Clause 2 license. 
// See the license.txt file in the project root for more information.
using Markdig.Syntax.Inlines;

namespace Markdig.Renderers.Latex.Inlines
{
    /// <summary>
    /// A Latex renderer for a <see cref="LinkInline"/>.
    /// </summary>
    /// <seealso cref="Markdig.Renderers.Latex.LatexObjectRenderer{Markdig.Syntax.Inlines.LinkInline}" />
    public class LinkInlineRenderer : LatexObjectRenderer<LinkInline>
    {
        /// <summary>
        /// Gets or sets a value indicating whether to always add rel="nofollow" for links or not.
        /// </summary>
        public bool AutoRelNoFollow { get; set; }
        public bool IsCitation { get; set; }

        protected override void Write(LatexRenderer renderer, LinkInline link)
        {
            if (link.Url.StartsWith("c:"))
            {
                IsCitation = true;
                link.Url = link.Url.Substring(2);
            }

            if (renderer.EnableLatexForInline)
            {
                renderer.Write(IsCitation ? @"\cite[" : @"\ref");
                renderer.WriteChildren(link);
                //renderer.WriteEscapeUrl(link.GetDynamicUrl != null ? link.GetDynamicUrl() ?? link.Url : link.Url);
                //renderer.Write("\"");
                renderer.WriteAttributes(link);
            }
            if (link.IsImage)
            {
                if (renderer.EnableLatexForInline)
                {
                    renderer.Write(" alt=\"");
                }
                var wasEnableLatexForInline = renderer.EnableLatexForInline;
                renderer.EnableLatexForInline = false;
                renderer.WriteChildren(link);
                renderer.EnableLatexForInline = wasEnableLatexForInline;
                if (renderer.EnableLatexForInline)
                {
                    renderer.Write("\"");
                }
            }

            if (renderer.EnableLatexForInline && !string.IsNullOrEmpty(link.Title))
            {
                renderer.Write(" title=\"");
                renderer.WriteEscape(link.Title);
                renderer.Write("\"");
            }

            if (link.IsImage)
            {
                if (renderer.EnableLatexForInline)
                {
                    renderer.Write(" />");
                }
            }
            else
            {
                if (renderer.EnableLatexForInline)
                {
                    if (AutoRelNoFollow)
                    {
                        renderer.Write(" rel=\"nofollow\"");
                    }
                    renderer.Write(IsCitation ? "]{" : "{");
                }
                
                renderer.Write(link.Url);
                if (renderer.EnableLatexForInline)
                {
                    renderer.Write("}");
                }
            }
        }
    }
}