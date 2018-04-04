using System;

namespace XNA_Jetpac
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (JetPac game = new JetPac())
            {
                game.Run();
            }
        }
    }
}

