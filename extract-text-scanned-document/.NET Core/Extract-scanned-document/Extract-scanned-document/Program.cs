using Syncfusion.OCRProcessor;
using Syncfusion.Pdf.Parsing;
using System;
using System.IO;

namespace Extract_scanned_document
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialize OCR processor
            OCRProcessor processor = new OCRProcessor(@"../../../../../../../Data/TesseractBinaries/Windows/");

            FileStream stream = new FileStream("../../../../../../../Data/Invoice_scanned.pdf", FileMode.Open);

            //Load a PDF document
            PdfLoadedDocument lDoc = new PdfLoadedDocument(stream);

            //Set OCR language to process

            processor.Settings.Language = Languages.English;

            OCRLayoutResult hocrBounds;

            processor.PerformOCR(lDoc, @"../../../../../../../Data/Tessdata/", out hocrBounds);

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
