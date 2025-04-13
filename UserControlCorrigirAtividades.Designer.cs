namespace Corretor
{
    partial class UserControlCorrigirAtividades
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
            label1 = new Label();
            btn_Questions = new Button();
            txt_selectedQuestions = new Label();
            label2 = new Label();
            btn_Answers = new Button();
            flowArquivos = new FlowLayoutPanel();
            flowQuestions = new FlowLayoutPanel();
            btn_Corrigir = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 25);
            label1.Name = "label1";
            label1.Size = new Size(182, 15);
            label1.TabIndex = 0;
            label1.Text = "Selecione o PDF com as questões";
            // 
            // btn_Questions
            // 
            btn_Questions.Location = new Point(28, 43);
            btn_Questions.Name = "btn_Questions";
            btn_Questions.Size = new Size(75, 23);
            btn_Questions.TabIndex = 1;
            btn_Questions.Text = "Selecionar";
            btn_Questions.UseVisualStyleBackColor = true;
            btn_Questions.Click += btn_Questions_Click;
            // 
            // txt_selectedQuestions
            // 
            txt_selectedQuestions.AutoSize = true;
            txt_selectedQuestions.Location = new Point(107, 46);
            txt_selectedQuestions.Name = "txt_selectedQuestions";
            txt_selectedQuestions.Size = new Size(0, 15);
            txt_selectedQuestions.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(31, 81);
            label2.Name = "label2";
            label2.Size = new Size(124, 15);
            label2.TabIndex = 3;
            label2.Text = "Selecione os gabaritos";
            // 
            // btn_Answers
            // 
            btn_Answers.Location = new Point(28, 99);
            btn_Answers.Name = "btn_Answers";
            btn_Answers.Size = new Size(75, 23);
            btn_Answers.TabIndex = 4;
            btn_Answers.Text = "Selecionar";
            btn_Answers.UseVisualStyleBackColor = true;
            btn_Answers.Click += btn_Answers_Click;
            // 
            // flowArquivos
            // 
            flowArquivos.Location = new Point(31, 128);
            flowArquivos.Name = "flowArquivos";
            flowArquivos.Size = new Size(550, 264);
            flowArquivos.TabIndex = 5;
            // 
            // flowQuestions
            // 
            flowQuestions.Location = new Point(106, 43);
            flowQuestions.Name = "flowQuestions";
            flowQuestions.Size = new Size(396, 32);
            flowQuestions.TabIndex = 6;
            // 
            // btn_Corrigir
            // 
            btn_Corrigir.Location = new Point(28, 398);
            btn_Corrigir.Name = "btn_Corrigir";
            btn_Corrigir.Size = new Size(127, 32);
            btn_Corrigir.TabIndex = 7;
            btn_Corrigir.Text = "Corrigir";
            btn_Corrigir.UseVisualStyleBackColor = true;
            btn_Corrigir.Click += btn_Corrigir_Click;
            // 
            // UserControlCorrigirAtividades
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btn_Corrigir);
            Controls.Add(flowQuestions);
            Controls.Add(flowArquivos);
            Controls.Add(btn_Answers);
            Controls.Add(label2);
            Controls.Add(txt_selectedQuestions);
            Controls.Add(btn_Questions);
            Controls.Add(label1);
            Name = "UserControlCorrigirAtividades";
            Size = new Size(612, 450);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btn_Questions;
        private Label txt_selectedQuestions;
        private Label label2;
        private Button btn_Answers;
        private FlowLayoutPanel flowArquivos;
        private FlowLayoutPanel flowQuestions;
        private Button btn_Corrigir;
    }
}
