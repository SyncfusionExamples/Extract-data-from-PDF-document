using Syncfusion.OCRProcessor;
using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extract_scanned_document
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialize OCR processor
            OCRProcessor processor = new OCRProcessor(@"../../../../../../Data/TesseractBinaries/3.02/");

            //Load a PDF document
            PdfLoadedDocument lDoc = new PdfLoadedDocument("../../../../../../Data/Invoice_scanned.pdf");

            //Set OCR language to process

            processor.Settings.Language = Languages.English;

            OCRLayoutResult hocrBounds;

            processor.PerformOCR(lDoc, @"../../../../../../Data/Tessdata/", out hocrBounds);

            StreamWriter writer = new StreamWriter("data.txt");

            foreach (Page pages in hocrBounds.Pages)
            {
                foreach (Line line in pages.Lines)
                {
                    writer.WriteLine(line.Text);
                }
            }

            writer.Close();

            lDoc.Close(true);

            processor.Dispose();

        }
    }
}
