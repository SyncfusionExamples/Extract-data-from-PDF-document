using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extract_attachments
{
    class Program
    {
        static void Main(string[] args)
        {
            //Load the PDF document
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument("../../../../../../Data/Attachment.pdf");
           
            //Get first page from document
            PdfLoadedPage page = loadedDocument.Pages[0] as PdfLoadedPage;
            //Get the annotation collection from pages
            PdfLoadedAnnotationCollection annotations = page.Annotations;
            //Iterates the annotations
            foreach (PdfLoadedAnnotation annot in annotations)
            {
                //Check for the attachment annotation
                if (annot is PdfLoadedAttachmentAnnotation)
                {
                    PdfLoadedAttachmentAnnotation file = annot as PdfLoadedAttachmentAnnotation;
                    //Extracts the attachment and saves it to the disk
                    FileStream stream = new FileStream(file.FileName, FileMode.Create);
                    stream.Write(file.Data, 0, file.Data.Length);
                    stream.Dispose();
                }
            }
            //Iterates through the attachments
            if (loadedDocument.Attachments.Count != 0)
            {
                foreach (PdfAttachment attachment in loadedDocument.Attachments)
                {
                    //Extracts the attachment and saves it to the disk
                    FileStream stream = new FileStream(attachment.FileName, FileMode.Create);
                    stream.Write(attachment.Data, 0, attachment.Data.Length);
                    stream.Dispose();
                }
            }
            //Close the document
            loadedDocument.Close(true);
        }
    }
}
