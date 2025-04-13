using Corretor.DB;

namespace Corretor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCorrecao_Click(object sender, EventArgs e)
        {
            panelContent.Controls.Clear();
            UserControlCorrigirAtividades telaCorrigir = new UserControlCorrigirAtividades();
            panelContent.Controls.Add(telaCorrigir);
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            panelContent.Controls.Clear();
            UserControlCadastrarAluno telaCadastro = new UserControlCadastrarAluno();
            panelContent.Controls.Add(telaCadastro);
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            panelContent.Controls.Clear();
            UserControlListarAlunos telaListar = new UserControlListarAlunos();
            panelContent.Controls.Add(telaListar);
        }
    }
}
