using Corretor.DB;
using DotNetEnv;

namespace Corretor
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            SqLite banco = new SqLite();
            banco.CriarBancoSeNaoExistir();
            ApplicationConfiguration.Initialize();
            Env.Load();
            Application.Run(new Form1());
        }
    }
}