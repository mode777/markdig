// Copyright (c) Alexandre Mutel. All rights reserved.
// This file is licensed under the BSD-Clause 2 license. 
// See the license.txt file in the project root for more information.
using Markdig.Syntax;

namespace Markdig.Renderers.Latex
{
    /// <summary>
    /// A base class for Latex rendering <see cref="Block"/> and <see cref="Markdig.Syntax.Inlines.Inline"/> Markdown objects.
    /// </summary>
    /// <typeparam name="TObject">The type of the object.</typeparam>
    /// <seealso cref="Markdig.Renderers.IMarkdownObjectRenderer" />
    public abstract class LatexObjectRenderer<TObject> : MarkdownObjectRenderer<LatexRenderer, TObject> where TObject : MarkdownObject
    {
    }
}