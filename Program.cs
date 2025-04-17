using Corretor.DB;
using DotNetEnv;

namespace Corretor
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Env.TraversePath().Load();
            SqLite banco = new SqLite();
            banco.CriarBancoSeNaoExistir();
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}