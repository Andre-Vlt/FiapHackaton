using System.Data.SQLite;

namespace Corretor
{
    partial class UserControlListarAlunos
    {

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void CarregarSeriesNoComboBox()
        {
            string connectionString = "Data Source=banco.db";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT DISTINCT Serie FROM Alunos";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        dropdownSeries.Items.Clear(); // Limpa antes de carregar novamente

                        while (reader.Read())
                        {
                            string serie = reader["Serie"].ToString();
                            dropdownSeries.Items.Add(serie);
                        }
                    }
                }
            }
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            dropdownSeries = new ComboBox();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F);
            label1.Location = new Point(9, 6);
            label1.Name = "label1";
            label1.Size = new Size(134, 30);
            label1.TabIndex = 0;
            label1.Text = "Listar Alunos";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 51);
            label2.Name = "label2";
            label2.Size = new Size(32, 15);
            label2.TabIndex = 1;
            label2.Text = "Série";
            // 
            // dropdownSeries
            // 
            dropdownSeries.FormattingEnabled = true;
            dropdownSeries.Location = new Point(47, 48);
            dropdownSeries.Name = "dropdownSeries";
            dropdownSeries.Size = new Size(121, 23);
            dropdownSeries.TabIndex = 2;
            dropdownSeries.SelectedIndexChanged += dropdownSeries_SelectedIndexChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(9, 90);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(591, 335);
            dataGridView1.TabIndex = 3;
            // 
            // UserControlListarAlunos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridView1);
            Controls.Add(dropdownSeries);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "UserControlListarAlunos";
            Size = new Size(612, 450);
            Load += UserControlListarAlunos_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox dropdownSeries;
        private DataGridView dataGridView1;
    }
}
