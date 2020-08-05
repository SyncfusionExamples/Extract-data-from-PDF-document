using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layout_based_text_extraction
{
    class Program
    {
        static void Main(string[] args)
        {
            //Load the PDF document
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument("../../../../../../Data/Invoice.pdf");

            //Get the first page of the loaded PDF document
            PdfPageBase page = loadedDocument.Pages[0];

            //Extract text with layout
            string extractedText = page.ExtractText(true);

            //Save text to file
            File.WriteAllText("data.txt", extractedText);
            
            //Close the PDF document
            loadedDocument.Close(true);

        }
    }
}
