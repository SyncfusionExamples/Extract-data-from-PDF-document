using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extract_text_specific_bounds
{
    class Program
    {
        static void Main(string[] args)
        {
            //Load the PDF document
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument("../../../../../../Data/Invoice.pdf");

            // Get the first page of the loaded PDF document
            PdfPageBase page = loadedDocument.Pages[0];

            TextLines lineCollection = new TextLines();

            // Extract text from the first page with bounds
            page.ExtractText(out lineCollection);

            RectangleF textBounds = new RectangleF(474, 161, 50, 9);

            string invoiceNumer = "";

            //Get the text provided in the bounds
            foreach (TextLine txtLine in lineCollection)
            {
                foreach (TextWord word in txtLine.WordCollection)
                {
                    if (textBounds.IntersectsWith(word.Bounds))
                    {
                        invoiceNumer = word.Text;
                        break;
                    }
                }
            }

            //Close the PDF document
            loadedDocument.Close(true);

            File.WriteAllText("data.txt", invoiceNumer);

        }
    }
}
