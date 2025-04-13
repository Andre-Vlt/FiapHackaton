using Corretor.DB;
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
    public partial class UserControlCadastrarAluno : UserControl
    {
        public UserControlCadastrarAluno()
        {
            InitializeComponent();
        }

        private void btn_InsertDB_Click(object sender, EventArgs e)
        {
            if(txt_MatriculaAluno.Text == "" || txt_nomeAluno.Text == "" || txt_SerieAluno.Text == "")
            {
                MessageBox.Show("Preencha todos os campos obrigatórios.");
            }
            else
            {
                try
                {
                    SqLite db = new SqLite();
                    db.InserirAluno(txt_nomeAluno.Text, txt_SerieAluno.Text, txt_MatriculaAluno.Text);
                    MessageBox.Show("Aluno cadastrado com sucesso!");
                    txt_MatriculaAluno.Clear();
                    txt_nomeAluno.Clear();
                    txt_SerieAluno.Clear();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Erro ao cadastrar aluno: " + ex.Message);
                }
            }
        }
    }
}
