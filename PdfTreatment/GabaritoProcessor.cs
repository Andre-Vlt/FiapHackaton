using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Tesseract;

namespace Corretor.PdfTreatment
{
    public class GabaritoProcessor
    {
        private TesseractWrapper _tesseractWrapper;

        private readonly List<int> coordenadasX = new List<int> { 109, 126, 142, 159, 175 }; //A, B, C, D, E
        private readonly List<int> coordenadasY = new List<int> { 174, 198, 223, 245, 269, 293, 317, 340, 364, 387, 411, 434, 458, 481, 505, 529, 552, 576, 599, 623, 647, 673 }; //1 a 22

        public GabaritoProcessor(string tessDataPath)
        {
            _tesseractWrapper = new TesseractWrapper();
            _tesseractWrapper.StartTesseract(tessDataPath);
        }
        /*Percorre todas questões e corrige uma a uma:*/
        public List<String> ProcessarAlternativas(Bitmap imagem)
        {
            var respostas = new List<string>();

            foreach (var y in coordenadasY)
            {
                string alternativaMarcada = ProcessarAlternativaPorQuestao(imagem, y);
                respostas.Add(alternativaMarcada);
            }
            return respostas;
        }

        /*Recorta a imagem e faz OCR pra ver qual foi marcada*/
        private string ProcessarAlternativaPorQuestao(Bitmap imagem, int y)
        {
            var alternativas = new List<string>() { "A", "B", "C", "D", "E" };
            var intensidadePorAlternativa = new Dictionary<string, int>();
            float escala = 300f / 96f;
            int larguraRegiao = (int)(20 * escala);
            int alturaRegiao = (int)(20 * escala);
            for (int i = 0; i < coordenadasX.Count; i++)
            {
                int x = (int)(coordenadasX[i] * escala);
                int yConvertido = (int)(y * escala);

                int contador = 0;
                for (int xi = x; xi < x + larguraRegiao; xi++)
                {
                    for (int yi = yConvertido; yi < yConvertido + alturaRegiao; yi++)
                    {
                        if (xi >= imagem.Width || yi >= imagem.Height)
                            continue;
                        Color pixel = imagem.GetPixel(xi, yi);
                        int media = (pixel.R + pixel.G + pixel.B) / 3;

                        if (media < 100)
                            contador++;
                    }
                }

                intensidadePorAlternativa[alternativas[i]] = contador;

            }

            var maisEscura = intensidadePorAlternativa.OrderByDescending(x => x.Value).First();

            if (maisEscura.Value < 50)
                return "Não marcada";

            Debug.WriteLine($"Alternativa marcada: {maisEscura}");
            return maisEscura.Key;
        }
    }
}
