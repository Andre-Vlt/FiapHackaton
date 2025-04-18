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
        private readonly List<int> coordenadasX = new List<int> { 109, 126, 142, 159, 175 }; //A, B, C, D, E
        private readonly List<int> coordenadasY = new List<int> { 174, 198, 223, 245, 269, 293, 317, 340, 364, 387, 411, 434, 458, 481, 505, 529, 552, 576, 599, 623, 647, 673 }; //1 a 22

        /*Percorre todas questões e corrige uma a uma:*/
        public List<String> ProcessarAlternativas(Bitmap imagem)
        {
            var respostas = new List<string>();

            var imagemProcessada = PreProcessarImagem(imagem);

            foreach (var y in coordenadasY)
            {
                string alternativaMarcada = ProcessarAlternativaPorQuestao(imagemProcessada, y);
                respostas.Add(alternativaMarcada);
            }
            return respostas;
        }

        private Bitmap PreProcessarImagem(Bitmap original)
        {
            var processed = new Bitmap(original.Width, original.Height);

            for(int x= 0; x < original.Width; x++)
            {
                for(int y = 0; y <original.Height; y++)
                {
                    Color pixel = original.GetPixel(x, y);
                    int grayValue = (int)(pixel.R * 0.3 + pixel.G * 0.59 + pixel.B * 0.11);
                    processed.SetPixel(x, y, Color.FromArgb(grayValue, grayValue, grayValue));
                }
            }
            return processed;
        }

        /*Recorta a imagem e faz OCR pra ver qual foi marcada*/
        private string ProcessarAlternativaPorQuestao(Bitmap imagem, int y)
        {
            var alternativas = new List<string>() { "A", "B", "C", "D", "E" };
            var intensidadePorAlternativa = new Dictionary<string, int>();

            int larguraRegiao = 25;
            int alturaRegiao = 25;

            for (int i = 0; i < coordenadasX.Count; i++)
            {
                int x = coordenadasX[i];
                int contadorPixelsEscuros = 0;

                for (int xi = x - larguraRegiao / 2; xi < x + larguraRegiao / 2; xi++)
                {
                    for (int yi = y - alturaRegiao / 2; yi < y + alturaRegiao / 2; yi++)
                    {
                        if (xi < 0 || yi < 0 || xi >= imagem.Width || yi >= imagem.Height)
                        { continue; }
                        Color pixel = imagem.GetPixel(xi, yi);

                        if (pixel.R < 50)
                            contadorPixelsEscuros++;
                    }
                }
                intensidadePorAlternativa[alternativas[i]] = contadorPixelsEscuros;
            }

            var alternativaMarcada = intensidadePorAlternativa.OrderByDescending(x => x.Value).First();
                
            if (alternativaMarcada.Value < 30) { return "Não marcada"; }

            return alternativaMarcada.Key;
            

            }
        }
}

