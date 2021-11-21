using System;
using System.IO;
//using Newtonsoft.Json;
using System.Text.Json;

namespace test
{
    class Program
    {
        static string path = @"C:\Users\ghile\Desktop\POO\JSON\";
        
        static void Main(string[] args)
        {
            int nbFichiersSD = Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly).Length;

            Sauvegarde SV = new Sauvegarde();
            
            Console.WriteLine($"Bienvenue dans l'interface EasySave => vous avez "+nbFichiersSD+ $"/5 slots de sauvegardes. {Environment.NewLine}");

            Console.WriteLine($"1. Création Travail de sauvegarde                  2. Execution Travail de sauvegarde {Environment.NewLine} {Environment.NewLine}3. Exit");
            
            Console.WriteLine("Votre saisie:");
            int Input = Convert.ToInt32(Console.ReadLine());

            if(Input == 1)
            {
                Console.Clear();
                Console.WriteLine("Combien de travaux voulez-vous réaliser ?");
                int choice = Convert.ToInt32(Console.ReadLine());
                if(choice+nbFichiersSD < 5)
                {
                    SV.Create_Travail_Sauvegarde(choice,nbFichiersSD);
                }
                else
                {
                    Console.WriteLine("Nombre de slots insuffisant, veuillez réessayer ultérieurement");
                    Environment.Exit(0);
                }
                
            }
            else if(Input == 2)
            {
                Console.Clear();
                SV.Execute_Travail_Sauvegarde();
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
