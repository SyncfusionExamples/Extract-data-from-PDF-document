using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using System;
using System.IO;

namespace Layout_based_text_extraction
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream stream = new FileStream("../../../../../../../Data/Invoice.pdf", FileMode.Open);
            //Load the PDF document
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(stream);

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
