using Tesseract;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing;


namespace Corretor.PdfTreatment
{
    public class TesseractWrapper
    {
        private TesseractEngine _ocrEngine;
        public void StartTesseract(string tessDataPath)
        {
            _ocrEngine = new TesseractEngine(tessDataPath, "por", EngineMode.Default);
        }

        public string ProcessBitmap(Bitmap bitmap)
        {
            if (_ocrEngine == null)
            {
                throw new InvalidOperationException("Tesseract engine not initialized. Call StartTesseract first.");
            }

            using (var stream = new MemoryStream())
            {
                bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                stream.Position = 0;
                using (var pix = Pix.LoadFromMemory(stream.ToArray()))
                {
                    using (var page = _ocrEngine.Process(pix))
                    {
                        return page.GetText();
                    }
                }
            }
        }

        public Bitmap RecortarAlternativa(Bitmap imgCompleta, Rectangle regiao)
        {
            return imgCompleta.Clone(regiao, imgCompleta.PixelFormat);
        }
    }
}
