// Copyright (c) Alexandre Mutel. All rights reserved.
// This file is licensed under the BSD-Clause 2 license. 
// See the license.txt file in the project root for more information.

using System;
using System.Collections.Generic;
using Markdig.Parsers;
using Markdig.Syntax;

namespace Markdig.Renderers.Latex
{
    /// <summary>
    /// An HTML renderer for a <see cref="CodeBlock"/> and <see cref="FencedCodeBlock"/>.
    /// </summary>
    /// <seealso cref="Markdig.Renderers.Latex.LatexObjectRenderer{Markdig.Syntax.CodeBlock}" />
    public class CodeBlockRenderer : LatexObjectRenderer<CodeBlock>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CodeBlockRenderer"/> class.
        /// </summary>
        public CodeBlockRenderer()
        {
            BlocksAsDiv = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        }

        public bool OutputAttributesOnPre { get; set; }

        /// <summary>
        /// Gets a map of fenced code block infos that should be rendered as div blocks instead of pre/code blocks.
        /// </summary>
        public HashSet<string> BlocksAsDiv { get; }

        protected override void Write(LatexRenderer renderer, CodeBlock obj)
        {
            renderer.EnsureLine();
            var fencedCodeBlock = obj as FencedCodeBlock;

            if(fencedCodeBlock != null)
            {
                var info = fencedCodeBlock.Info ?? string.Empty;
                var langFrag = info.Split(':');

                var language = langFrag[0];
                var label = langFrag.Length > 0 ? langFrag[1] : null;
                var caption = langFrag.Length > 1 ? langFrag[2] : null;

                renderer.Write("\\begin{lstlisting}[language=");
                renderer.Write(language);
                if(label != null)
                {
                    renderer.Write(",label=");
                    renderer.Write(label);
                }
                if(caption != null)
                {
                    renderer.Write(",caption=");
                    renderer.Write(caption);
                }
                renderer.Write("]\n");

                renderer.WriteLeafRawLines(obj, true, true, true);

                renderer.Write("\\end{lstlisting}");
            }

            //if (fencedCodeBlock?.Info != null && BlocksAsDiv.Contains(fencedCodeBlock.Info))
            //{
            //    var infoPrefix = (obj.Parser as FencedCodeBlockParser)?.InfoPrefix ??
            //                     FencedCodeBlockParser.DefaultInfoPrefix;

            //    // We are replacing the HTML attribute `language-mylang` by `mylang` only for a div block
            //    // NOTE that we are allocating a closure here
            //    renderer.Write("<div")
            //        .WriteAttributes(obj.TryGetAttributes(),
            //            cls => cls.StartsWith(infoPrefix) ? cls.Substring(infoPrefix.Length) : cls)
            //        .Write(">");
            //    renderer.WriteLeafRawLines(obj, true, true, true);
            //    renderer.WriteLine("</div>");

            //}
            //else
            //{
            //    renderer.Write("<pre");
            //    if (OutputAttributesOnPre)
            //    {
            //        renderer.WriteAttributes(obj);
            //    }
            //    renderer.Write("><code");
            //    if (!OutputAttributesOnPre)
            //    {
            //        renderer.WriteAttributes(obj);
            //    }
            //    renderer.Write(">");
            //    renderer.WriteLeafRawLines(obj, true, true);
            //    renderer.WriteLine("</code></pre>");
            //}
        }
    }
}