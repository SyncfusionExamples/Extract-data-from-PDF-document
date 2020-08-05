using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;


namespace Find_text
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load an existing PDF
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument("../../../../../../Data/Invoice.pdf");

            TextSearchResultCollection searchCollection;

            TextSearchItem text = new TextSearchItem("Invoice Number", TextSearchOptions.None);

            //Search the text from PDF dcoument
            loadedDocument.FindText(new List<TextSearchItem> { text },out searchCollection);

            //Iterate serach collection to get serach results
            foreach(KeyValuePair<int,MatchedItemCollection> textCollection in searchCollection )
            {   
                //Get age number
                Console.WriteLine("Page Number : " + textCollection.Key);

                foreach(MatchedItem textItem in textCollection.Value)
                {   
                    //Get actual text and bounds
                    Console.WriteLine("Text :" + textItem.Text);
                    Console.WriteLine("Text bounds :" + textItem.Bounds);
                }

            }

            //Close the document
            loadedDocument.Close(true);
        }
    }
}
