using System;

namespace sauvegarde
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Veuillez saisir votre dossier source");
            string src = Console.ReadLine();
            Console.WriteLine("Veuillez saisir votre dossier destination");
            string dest = Console.ReadLine();

            Sauvegarde SV = new Sauvegarde();
            SV.CopyRepertoire(src, dest);
        }
    }
}
