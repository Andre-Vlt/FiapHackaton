using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfiumViewer;

namespace Corretor.PdfTreatment
{
    public static class GetPdfText
    {
        public static string GetTextFromPdf(PdfDocument pdf)
        {
            using (pdf)
            {
                var text = new StringBuilder();
                for (int i = 0; i < pdf.PageCount; i++)
                {
                    text.AppendLine(pdf.GetPdfText(i));
                }
                return text.ToString();
            }
        }
    }
}
