// Copyright (c) Alexandre Mutel. All rights reserved.
// This file is licensed under the BSD-Clause 2 license. 
// See the license.txt file in the project root for more information.
using System.Globalization;
using Markdig.Syntax;

namespace Markdig.Renderers.Latex
{
    /// <summary>
    /// A Latex renderer for a <see cref="ListBlock"/>.
    /// </summary>
    /// <seealso cref="Markdig.Renderers.Latex.LatexObjectRenderer{Markdig.Syntax.ListBlock}" />
    public class ListRenderer : LatexObjectRenderer<ListBlock>
    {
        protected override void Write(LatexRenderer renderer, ListBlock listBlock)
        {
            renderer.EnsureLine();
            if (listBlock.IsOrdered)
            {
                renderer.Write("\\begin{enumerate}\n");
                //if (listBlock.BulletType != '1')
                //{
                //    renderer.Write(" type=\"").Write(listBlock.BulletType).Write("\"");
                //}

                //if (listBlock.OrderedStart != null && (listBlock.OrderedStart != "1"))
                //{
                //    renderer.Write(" start=\"").Write(listBlock.OrderedStart).Write("\"");
                //}
                //renderer.WriteAttributes(listBlock);
                //renderer.WriteLine(">");
            }
            else
            {
                renderer.Write("\\begin{itemize}\n");
                //renderer.WriteAttributes(listBlock);
                //renderer.WriteLine(">");
            }
            foreach (var item in listBlock)
            {
                var listItem = (ListItemBlock)item;
                var previousImplicit = renderer.ImplicitParagraph;
                renderer.ImplicitParagraph = !listBlock.IsLoose;

                //renderer.EnsureLine();
                renderer.Write(@"\item ")/*.WriteAttributes(listItem).Write("]")*/;
                renderer.WriteChildren(listItem);
                renderer.WriteLine();

                renderer.ImplicitParagraph = previousImplicit;
            }
            renderer.WriteLine(listBlock.IsOrdered ? "\\end{enumerate}\n" : "\\end{itemize}\n");
        }
    }
}