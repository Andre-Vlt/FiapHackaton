using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Corretor.DB
{
    public class SqLite
    {
        public void CriarBancoSeNaoExistir()
        {
            string caminhoDB = "banco.db";

            if (!File.Exists(caminhoDB))
            {
                SQLiteConnection.CreateFile(caminhoDB);

                using (var connection = new SQLiteConnection($"Data Source={caminhoDB};Version=3;"))
                {
                    connection.Open();
                    string sql = @"CREATE TABLE IF NOT EXISTS Alunos (Id INTEGER PRIMARY KEY AUTOINCREMENT,
                      Nome TEXT NOT NULL,
                      Serie TEXT NOT NULL,
                      Matricula TEXT NOT NULL);";
                    using (var command = new SQLiteCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public void InserirAluno(string nome, string serie, string matricula)
        {
            string caminhoDB = "banco.db";
            using (var connection = new SQLiteConnection($"Data Source={caminhoDB};Version=3;"))
            {
                connection.Open();
                string sql = "INSERT INTO Alunos (Nome, Serie, Matricula) VALUES (@Nome, @Serie, @Matricula)";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Nome", nome);
                    command.Parameters.AddWithValue("@Serie", serie);
                    command.Parameters.AddWithValue("@Matricula", matricula);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
