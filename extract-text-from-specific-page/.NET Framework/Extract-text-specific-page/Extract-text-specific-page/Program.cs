using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extract_text_specific_page
{
    class Program
    {
        static void Main(string[] args)
        {
            //Load the PDF document
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument("../../../../../../Data/Invoice.pdf");

            // Get the first page of the loaded PDF document
            PdfPageBase page = loadedDocument.Pages[0];

            // Extract text from the first page with bounds
            string extractedText = page.ExtractText();

            //Close the document
            loadedDocument.Close(true);

            //Save the text to file
            File.WriteAllText("data.txt", extractedText);

        }
    }
}
