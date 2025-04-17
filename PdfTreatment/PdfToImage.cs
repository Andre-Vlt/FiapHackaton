using PdfiumViewer;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corretor.PdfTreatment
{
    public class PdfToImage
    {
       public Bitmap ConvertPdfToImage(string pdfPath, int pageNumber = 0)
        {
            using var document = PdfDocument.Load(pdfPath);

            using var image = document.Render(pageNumber, 300, 300, true);

            return new Bitmap(image);

        }
    }
}
