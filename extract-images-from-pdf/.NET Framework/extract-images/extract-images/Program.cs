using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace extract_images
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load an existing PDF
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument("../../../../../../Data/Template.pdf");

            foreach(PdfPageBase page in loadedDocument.Pages)
            {
                //Extract images from first page
                Image[] extractedImages=page.ExtractImages();

               foreach(Image image in extractedImages)
                {
                    //Save each images to file
                    image.Save(Guid.NewGuid().ToString() + ".jpg",ImageFormat.Jpeg);
                }
            }
     
            //Close the document
            loadedDocument.Close(true);
        }
    }
}
