using System;
using System.IO;
using System.Reflection;
using System.Text;
using RtfPipe;

namespace RtfToHtml
{
    class Program
    {
        static void Main(string[] args)
        {
            // Add a reference to the NuGet package System.Text.Encoding.CodePages for .Net core only
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var location = Assembly.GetExecutingAssembly().Location;
            var contentRoot = Path.GetDirectoryName(location);
            var input = Path.Combine(contentRoot, "input.rtf");
            var output = Path.Combine(contentRoot, "output.html");

            var html = Rtf.ToHtml(File.ReadAllText(input));
            File.WriteAllText(output, html);

            Console.WriteLine($"Done. Output file: {output}");
        }
    }
}
