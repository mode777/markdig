using Markdig;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace md2tex
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"md2tex {Assembly.GetEntryAssembly().GetName().Version} - (c) 2017 Alexander Klingenbeck");

            var files = CollectFiles(new DirectoryInfo(Directory.GetCurrentDirectory()), new List<FileInfo>());

            files.ForEach(x =>
            {
                try
                {
                    var markdown = File.ReadAllText(x.FullName);
                    var latex = Markdown.ToLatex(markdown);
                    var targetFile = Path.Combine(x.Directory.FullName, Path.GetFileNameWithoutExtension(x.FullName)) + ".tex";
                    File.WriteAllText(targetFile, latex);
                    Console.WriteLine($"Generated {targetFile}");
                }
                catch(Exception e)
                {
                    Console.WriteLine($"Error processing file {x.FullName}: {e.Message}");
                }
            });

            //Console.ReadLine();
        }

        static List<FileInfo> CollectFiles(DirectoryInfo dir, List<FileInfo> collection)
        {
            collection
                .AddRange(dir.EnumerateFiles()
                .Where(x => x.Extension == ".md"));
            dir
                .GetDirectories()
                .ToList()
                .ForEach(x => CollectFiles(x, collection));

            return collection;
        }
    }
}