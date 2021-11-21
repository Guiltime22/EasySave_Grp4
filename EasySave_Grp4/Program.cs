using System;

namespace sauvegarde
{
    class Program
    {
        static string src;
        static string dest;
        static int i;
        static void Main(string[] args)
        {
            
            Console.WriteLine($"Bienvenue dans l'interface EasySave {Environment.NewLine}");

            Console.WriteLine($"1. Création Travail de sauvegarde {Environment.NewLine} 2. Execution Travail de sauvegarde {Environment.NewLine} 3. Exit");
            
            Console.WriteLine("Votre saisie:");
            int Input = Convert.ToInt32(Console.ReadLine());

            if(Input == 1)
            {
                Console.Clear();
                Console.WriteLine("Combien de travaux voulez-vous réaliser ?");
                int choice = Convert.ToInt32(Console.ReadLine());

                Sauvegarde SV = new Sauvegarde();
                SV.Travail_Sauvegarde(choice);
                /*
                Console.WriteLine("Veuillez saisir votre dossier source");
                src = Console.ReadLine();
                Console.WriteLine("Veuillez saisir votre dossier destination");
                dest = Console.ReadLine();

                Sauvegarde SV = new Sauvegarde();
                SV.CopyRepertoire(src, dest);
                */
            }
            else if(Input == 2)
            {
                Console.Clear();
            }
            else if(Input == 3)
            {
                Console.Clear();
                Environment.Exit(0);
            }else
            {
                Console.WriteLine("Choix incorrecte, fermeture de la console");
                Environment.Exit(0);
            }
            
        }
    }
}
