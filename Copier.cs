using System;
using System.Collections.Generic;
using System.Text;
using ver1;

namespace Kserokopiarka
{
    public class Copier : BaseDevice, IPrinter, IScanner
    {
        public int PrintCounter { get; private set; }
        public int ScanCounter { get; private set; }
        public Copier()
        {
            PrintCounter = 0;
            ScanCounter = 0;
        }

        public void Print(in IDocument document)
        {
            Console.WriteLine(DateTime.Now + "Print: " + "aaa.pdf");
            PrintCounter++;
        }
        public void Scan(out IDocument document, IDocument.FormatType formatType = IDocument.FormatType.JPG)
        {
            if(formatType == IDocument.FormatType.PDF)
            {
                document = new PDFDocument("PDFScan" + ScanCounter.ToString() +  ".pdf");
            }
            else if (formatType == IDocument.FormatType.TXT)
            {
                document = new TextDocument("TextScan" + ScanCounter.ToString() + ".jpg");
            }
            else
            {
                document = new ImageDocument("ImageScan" + ScanCounter.ToString() + ".txt");
            }
            ScanCounter++;
        }
        public void ScanAndPrint()
        {
            Scan(out IDocument doc, IDocument.FormatType.JPG);
            Print(doc);
        }
    }
}
