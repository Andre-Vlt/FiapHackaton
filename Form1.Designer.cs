namespace Corretor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnCadastrar = new Button();
            btnListar = new Button();
            btnCorrecao = new Button();
            panelMenu = new Panel();
            panelContent = new Panel();
            panelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // btnCadastrar
            // 
            btnCadastrar.Location = new Point(32, 308);
            btnCadastrar.Name = "btnCadastrar";
            btnCadastrar.Size = new Size(126, 52);
            btnCadastrar.TabIndex = 0;
            btnCadastrar.Text = "Cadastrar Aluno";
            btnCadastrar.UseVisualStyleBackColor = true;
            btnCadastrar.Click += btnCadastrar_Click;
            // 
            // btnListar
            // 
            btnListar.Location = new Point(32, 250);
            btnListar.Name = "btnListar";
            btnListar.Size = new Size(127, 52);
            btnListar.TabIndex = 1;
            btnListar.Text = "Listar Alunos";
            btnListar.UseVisualStyleBackColor = true;
            btnListar.Click += btnListar_Click;
            // 
            // btnCorrecao
            // 
            btnCorrecao.Location = new Point(31, 366);
            btnCorrecao.Name = "btnCorrecao";
            btnCorrecao.Size = new Size(126, 52);
            btnCorrecao.TabIndex = 2;
            btnCorrecao.Text = "Correção de atividades";
            btnCorrecao.UseVisualStyleBackColor = true;
            btnCorrecao.Click += btnCorrecao_Click;
            // 
            // panelMenu
            // 
            panelMenu.Controls.Add(btnListar);
            panelMenu.Controls.Add(btnCorrecao);
            panelMenu.Controls.Add(btnCadastrar);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(188, 450);
            panelMenu.TabIndex = 3;
            // 
            // panelContent
            // 
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(188, 0);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(612, 450);
            panelContent.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelContent);
            Controls.Add(panelMenu);
            MaximizeBox = false;
            Name = "Form1";
            Text = "Form1";
            panelMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnCadastrar;
        private Button btnListar;
        private Button btnCorrecao;
        private Panel panelMenu;
        private Panel panelContent;
    }
}
