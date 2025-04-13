using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Corretor
{
    public partial class UserControlListarAlunos : UserControl
    {
        public UserControlListarAlunos()
        {
            InitializeComponent();
        }

        private void UserControlListarAlunos_Load(object sender, EventArgs e)
        {
            CarregarSeriesNoComboBox();
        }
        private void dropdownSeries_SelectedIndexChanged(object sender, EventArgs e)
        {
            string serieSelecionada = dropdownSeries.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(serieSelecionada))
            {
                return;
            }

            string connectionString = "Data Source=banco.db";
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM ALUNOS WHERE SERIE = @serie";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@serie", serieSelecionada);
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
        }
    }
}
