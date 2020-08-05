using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Load the PDF document
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument("../../../../../../Data/Invoice.pdf");

            //Search total amount
            string regexPattern = @"(TOTAL)([-+]?[0-9]*\.?[0-9]+)";
            // See the complete regular expressions reference at https://msdn.microsoft.com/en-us/library/az24scfc(v=vs.110).aspx

            // Extract all the text from existing PDF document pages
            foreach (PdfLoadedPage loadedPage in loadedDocument.Pages)
            {
                TextLines lines;
                loadedPage.ExtractText(out lines);
                foreach(TextLine line in lines)
                {
                    Regex re = new Regex(regexPattern, RegexOptions.IgnoreCase);
                   
                    Match match = re.Match(line.Text);
                    if (match.Success)
                    {   
                        //Print the total amount
                        Console.WriteLine("Found Total Amount Number:" + match.Value.Replace("Total", ""));
                    } 
                }
                  
              }

            //Close the document
            loadedDocument.Close(true);

        }
    }
}
