using Corretor.ApiCalls;
using Corretor.PdfTreatment;
using Microsoft.VisualBasic.ApplicationServices;
using PdfiumViewer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Corretor
{
    public partial class UserControlCorrigirAtividades : UserControl
    {
        public UserControlCorrigirAtividades()
        {
            InitializeComponent();
        }

        private OpenAi openAi = new OpenAi();
        private List<string> files = new();
        private PdfDocument? questionsFile = null;
        private string[] SelecionarArquivos()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Selecione os arquivos";
                openFileDialog.Filter = "Arquivos PDF (*.pdf)|*.pdf";
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return openFileDialog.FileNames;
                }
                else
                {
                    return Array.Empty<string>();
                }
            }
        }

        private void btn_Answers_Click(object sender, EventArgs e)
        {
            string[] arquivosPDF = SelecionarArquivos();
            flowArquivos.Controls.Clear();

            foreach (var arquivo in arquivosPDF)
            {
                Label lbl = new Label();
                lbl.Text = Path.GetFileName(arquivo);
                lbl.AutoSize = true;
                lbl.Padding = new Padding(5);
                lbl.BackColor = Color.LightGray;
                lbl.Margin = new Padding(5);

                flowArquivos.Controls.Add(lbl);
                files.Add(arquivo);
            }
        }

        private void btn_Questions_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Selecione o arquivo de perguntas";
            openFileDialog.Filter = "Arquivos PDF (*.pdf)|*.pdf";
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string arquivoPDF = openFileDialog.FileName;
                PdfDocument doc = PdfDocument.Load(arquivoPDF);
                Label lbl = new Label();
                lbl.Text = Path.GetFileName(arquivoPDF);
                lbl.AutoSize = true;
                lbl.Padding = new Padding(5);
                lbl.BackColor = Color.LightGray;
                lbl.Margin = new Padding(5);
                flowQuestions.Controls.Add(lbl);

                questionsFile = doc;
            }
        }

        private async void btn_Corrigir_Click(object sender, EventArgs e)
        {

            
            var gabaritoOCR = new GabaritoProcessor();
            PdfToImage converter = new PdfToImage();
            
            
            string respostasCorretas = "";
            //TRANSFORMAR QUESTOES EM STRING E CHAMAR API PARA TER AS RESPOSTAS CORRETAS:
            if (questionsFile != null && files.Count > 0)
                respostasCorretas = await openAi.ObtemRespostasCorretas(GetPdfText.GetTextFromPdf(questionsFile));
            else
            {
                MessageBox.Show("ATENÇÃO!\nÉ necessário selecionar os arquivos de perguntas e os gabaritos!","ATENÇÃO",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            List<string> respostasAluno= new();
            //FAZER CORREÇÃO DE CADA GABARITO:
            foreach (var arquivo in files)
            {
                var img = converter.ConvertPdfToImage(arquivo);
                //Obter respostas aluno:
                respostasAluno = gabaritoOCR.ProcessarAlternativas(img);
                //Chamar metodo para fazer correção
                var respostasCorretasAluno = ExtrairAlternativa(respostasCorretas);

                int acertos = 0;

                for (int i = 0; i < respostasAluno.Count; i++)
                {
                    if (respostasAluno[i].Equals(respostasCorretas[i]))
                    {
                        acertos++;
                    }
                }
                //Exibir resultado
                MessageBox.Show($"O aluno acertou {acertos} de {respostasAluno.Count} questões.\n\nRespostas corretas: {string.Join(", ", respostasCorretasAluno)}\nRespostas do aluno: {string.Join(", ", respostasAluno)}", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private List<string> ExtrairAlternativa(string resposta)
        {
            var pares = resposta.Split(',');
            var alternativas = new List<string>();

            foreach (var par in pares)
            {
                string trimmed = par.Trim();
                if (!string.IsNullOrEmpty(trimmed))
                {
                    string alternativa = trimmed[^1].ToString().ToUpper();
                    alternativas.Add(alternativa);
                }
            }
            return alternativas;
        }
    }
}
