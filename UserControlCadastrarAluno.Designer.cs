namespace Corretor
{
    partial class UserControlCadastrarAluno
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            txt_nomeAluno = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txt_SerieAluno = new TextBox();
            label3 = new Label();
            label4 = new Label();
            txt_MatriculaAluno = new TextBox();
            btn_InsertDB = new Button();
            SuspendLayout();
            // 
            // txt_nomeAluno
            // 
            txt_nomeAluno.Location = new Point(18, 89);
            txt_nomeAluno.Name = "txt_nomeAluno";
            txt_nomeAluno.Size = new Size(343, 23);
            txt_nomeAluno.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 71);
            label1.Name = "label1";
            label1.Size = new Size(90, 15);
            label1.TabIndex = 1;
            label1.Text = "Nome do aluno";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16F);
            label2.Location = new Point(18, 11);
            label2.Name = "label2";
            label2.Size = new Size(189, 30);
            label2.TabIndex = 2;
            label2.Text = "Cadastro de aluno";
            // 
            // txt_SerieAluno
            // 
            txt_SerieAluno.Location = new Point(18, 141);
            txt_SerieAluno.Name = "txt_SerieAluno";
            txt_SerieAluno.Size = new Size(343, 23);
            txt_SerieAluno.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 123);
            label3.Name = "label3";
            label3.Size = new Size(32, 15);
            label3.TabIndex = 4;
            label3.Text = "Série";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(18, 176);
            label4.Name = "label4";
            label4.Size = new Size(57, 15);
            label4.TabIndex = 5;
            label4.Text = "Matrícula";
            // 
            // txt_MatriculaAluno
            // 
            txt_MatriculaAluno.Location = new Point(18, 194);
            txt_MatriculaAluno.Name = "txt_MatriculaAluno";
            txt_MatriculaAluno.Size = new Size(343, 23);
            txt_MatriculaAluno.TabIndex = 6;
            // 
            // btn_InsertDB
            // 
            btn_InsertDB.Location = new Point(18, 232);
            btn_InsertDB.Name = "btn_InsertDB";
            btn_InsertDB.Size = new Size(90, 36);
            btn_InsertDB.TabIndex = 7;
            btn_InsertDB.Text = "Cadastrar";
            btn_InsertDB.UseVisualStyleBackColor = true;
            btn_InsertDB.Click += btn_InsertDB_Click;
            // 
            // UserControlCadastrarAluno
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btn_InsertDB);
            Controls.Add(txt_MatriculaAluno);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txt_SerieAluno);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txt_nomeAluno);
            Name = "UserControlCadastrarAluno";
            Size = new Size(612, 450);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt_nomeAluno;
        private Label label1;
        private Label label2;
        private TextBox txt_SerieAluno;
        private Label label3;
        private Label label4;
        private TextBox txt_MatriculaAluno;
        private Button btn_InsertDB;
    }
}
