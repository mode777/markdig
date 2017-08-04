// Copyright (c) Alexandre Mutel. All rights reserved.
// This file is licensed under the BSD-Clause 2 license. 
// See the license.txt file in the project root for more information.
using Markdig.Syntax.Inlines;
using System.IO;

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
        //public bool IsCitation { get; set; }

        protected override void Write(LatexRenderer renderer, LinkInline link)
        {

            if (link.IsImage)
            {
                var descFrags = GetImgDesc(link).Split(':');
                var linkFrags = link.Url.Split(':');

                var id = descFrags[0];
                var desc = descFrags.Length > 1 ? descFrags[1] : string.Empty;
                var path = linkFrags[0];
                var size = linkFrags.Length > 1 ? linkFrags[1] : "0.5";

                renderer.Write("\\begin{figure}\n    \\centering\n    \\includegraphics[width=");
                renderer.Write(size);
                renderer.Write("\\textwidth]{");
                renderer.Write(path);
                renderer.Write("}\n    \\caption{\\label{");
                renderer.Write(id);
                renderer.Write("}");
                renderer.Write(desc);
                renderer.Write("}\n\\end{figure}");
            }
            else
            {
                bool isCitation = false;

                if (link.Url.StartsWith("c:"))
                {
                    isCitation = true;
                    link.Url = link.Url.Substring(2);
                }

                renderer.Write(isCitation ? @"\cite[" : @"\ref");
                renderer.WriteChildren(link);
                renderer.Write(isCitation ? "]{" : "{");
                renderer.Write(link.Url);
                renderer.Write("}");
            }            
        }

        private string GetImgDesc(LinkInline link)
        {
            var writer = new StringWriter();
            new LatexRenderer(writer).WriteChildren(link);
            return writer.ToString();
        }
    }
}