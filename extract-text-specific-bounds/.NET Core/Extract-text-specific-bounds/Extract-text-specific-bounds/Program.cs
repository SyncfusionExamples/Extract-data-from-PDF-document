using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using System;
using System.Drawing;
using System.IO;

namespace Extract_text_specific_bounds
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream inputStream = new FileStream("../../../../../../../Data/Invoice.pdf", FileMode.Open);

            //Load the PDF document
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(inputStream);

            // Get the first page of the loaded PDF document
            PdfPageBase page = loadedDocument.Pages[0];

            TextLineCollection lineCollection = new TextLineCollection();

            // Extract text from the first page with bounds
            page.ExtractText(out lineCollection);

            RectangleF textBounds = new RectangleF(474, 161, 50, 9);

            string invoiceNumer = "";

            //Get the text provided in the bounds
            foreach (TextLine txtLine in lineCollection.TextLine)
            {
                foreach (TextWord word in txtLine.WordCollection)
                {
                    if (textBounds.IntersectsWith(new RectangleF(word.Bounds.X, word.Bounds.Y, word.Bounds.Width, word.Bounds.Height)))
                    {
                        invoiceNumer += word.Text;
                       
                    }
                }
            }

            //Close the PDF document
            loadedDocument.Close(true);

            File.WriteAllText("data.txt", invoiceNumer);
        }
    }
}
