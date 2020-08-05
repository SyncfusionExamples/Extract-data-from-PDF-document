using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using System;
using System.IO;
using System.Text;

namespace Extract_text_from_all_pages
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream inputStream = new FileStream("../../../../../../../Data/Invoice.pdf",FileMode.Open);

            //Load the PDF document
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(inputStream);

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
