using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract;

namespace Corretor.PdfTreatment
{
    public class GabaritoProcessor
    {
        private TesseractWrapper _tesseractWrapper;

        private readonly List<int> coordenadasX = new List<int> { 104, 126, 142, 159, 175 }; //A, B, C, D, E
        private readonly List<int> coordenadasY = new List<int> { 174, 198, 223, 245, 269, 293, 317, 340, 364, 388, 412, 435, 459, 483, 507, 531, 554, 579, 601, 625, 649, 673 }; //1, 2, 3, 4, 5...

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
            var alternativas = new List<string>();

            for (int i =0; i< coordenadasX.Count; i++)
            {
                var regiao = new Rectangle(coordenadasX[i], y, 20, 20);
                var alternativaBitmap = _tesseractWrapper.RecortarAlternativa(imagem, regiao);

                string resultado = _tesseractWrapper.ProcessBitmap(alternativaBitmap).Trim();

                if (string.IsNullOrEmpty(resultado))
                {
                    alternativas.Add("Não lido");
                }
                else
                {
                    alternativas.Add(resultado);
                }

                foreach(var alternativa in alternativas)
                {
                    if (!string.IsNullOrEmpty(alternativa) && alternativa.Length == 1)
                    {
                        return alternativa;
                    }
                }
            }
                return "Não marcada";
        }
    }
}
