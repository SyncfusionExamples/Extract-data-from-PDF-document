using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extrac_form
{
    class Program
    {
        static void Main(string[] args)
        {
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(@"../../../../../../Data/FormFill.pdf");
            //Load an existing form
            PdfLoadedForm loadedForm = loadedDocument.Form;
            //Export the existing PDF form data to xml file
            loadedForm.ExportData("Export.xml", DataFormat.Xml, @"AcroForm1");
            //Close the document
            loadedDocument.Close(true);

            PdfDocument.ClearFontCache();
        }
    }
}
