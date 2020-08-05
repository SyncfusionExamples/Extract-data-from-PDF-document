using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extract_document_info
{
    class Program
    {
        static void Main(string[] args)
        {
            //Load the PDF document
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument("../../../../../../Data/Invoice.pdf");

            //Get all the document information
            Console.WriteLine("Author:       " + loadedDocument.DocumentInformation.Author);
            Console.WriteLine("Creator:      " + loadedDocument.DocumentInformation.Creator);
            Console.WriteLine("Producer:     " + loadedDocument.DocumentInformation.Producer);
            Console.WriteLine("Subject:      " + loadedDocument.DocumentInformation.Subject);
            Console.WriteLine("Title:        " + loadedDocument.DocumentInformation.Title);
            Console.WriteLine("CreationDate: " + loadedDocument.DocumentInformation.CreationDate);
            Console.WriteLine("Keywords:     " + loadedDocument.DocumentInformation.Keywords);
            Console.WriteLine("Encrypted:    " + loadedDocument.IsEncrypted);


            //Close the document
            loadedDocument.Close(true);
        }
    }
}
