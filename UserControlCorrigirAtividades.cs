using Corretor.PdfTreatment;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Corretor
{
    public partial class UserControlCorrigirAtividades : UserControl
    {
        public UserControlCorrigirAtividades()
        {
            InitializeComponent();
        }

        private List<string> files;
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
                Label lbl = new Label();
                lbl.Text = Path.GetFileName(arquivoPDF);
                lbl.AutoSize = true;
                lbl.Padding = new Padding(5);
                lbl.BackColor = Color.LightGray;
                lbl.Margin = new Padding(5);
                flowQuestions.Controls.Add(lbl);
            }
        }

        private void btn_Corrigir_Click(object sender, EventArgs e)
        {
            PdfToImage converter = new PdfToImage();
            foreach (var arquivo in files)
            {
                converter.ConvertPdfToImage(arquivo);
                //Chamar metodo para fazer correção
            }
        }
    }
}
