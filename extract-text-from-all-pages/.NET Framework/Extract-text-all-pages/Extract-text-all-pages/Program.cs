using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extract_text_all_pages
{
    class Program
    {
        static void Main(string[] args)
        {
            //Load the PDF document
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument("../../../../../../Data/Invoice.pdf");

            StringBuilder extractedText = new StringBuilder();

            // Extract all the text from existing PDF document pages
            foreach (PdfLoadedPage loadedPage in loadedDocument.Pages)
            {
                extractedText.Append(loadedPage.ExtractText());
            }

            //Close the document
            loadedDocument.Close(true);

            //Save the text to file
            File.WriteAllText("data.txt", extractedText.ToString());

        }
    }
}
