using System;
using System.IO;
//using Newtonsoft.Json;

namespace test
{
    class Program
    {
        static string path = @"..\..\..\Config\Travaux_Sauvegarde\"; //Folder where the works are
        public class Butter
        {
            public static int v;
            static public Langue LGUE = new Langue(); // Instance to use class Langue
            static public States ST = new States(); // Instance to use class States
            static public Log LG = new Log(); // Instance to use class Log
            static public Type_Save SV = new Type_Save(); // Instance to use class Type_Save
        }

        static void Main(string[] args) // the main function
        {
            Console.Clear();
            Console.WriteLine("Choisisez la langue / Choose your language"); //Choosing the language of the application
            Console.WriteLine("1.Anglais/English                 2.Français/French");
            Butter.v = Convert.ToInt32(Console.ReadLine()); // Input of the User

            while (true)
            {
                Console.Clear();
                int nbFichiersSD = Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly).Length;
                Sauvegarde SV = new Sauvegarde(); //Instance to use class sauvegarde
                Butter.LGUE.Welcome(); /* Calling a function */
                int Input = Convert.ToInt32(Console.ReadLine()); //Input of the User

                if (Input == 1) //choice of the creation
                {
                    Console.Clear();
                    Butter.LGUE.Traveaux();  /* Calling a function */
                    int choice = Convert.ToInt32(Console.ReadLine()); // Input of the User
                    if (choice + nbFichiersSD <= 5)
                    {
                        SV.Create_Travail_Sauvegarde(choice, nbFichiersSD); //function of creation 
                    }
                    else
                    {
                        Butter.LGUE.nbslots();  /* Calling a function */
                        Environment.Exit(0);
                    }

                }
                else if (Input == 2) //choice of the execution
                {
                    Console.Clear();
                    SV.Execute_Travail_Sauvegarde(); //function of execution
                }
                else if (Input == 3) //choice of gestion
                {
                    Console.Clear();
                    SV.Gestion_Travail_Sauvegarde(nbFichiersSD); //function of gestion
                }
                else if (Input == 4) //Close the application
                {
                    Console.Clear();
                    Console.WriteLine("BYE BYE");
                    Environment.Exit(0);
                }
                else
                {
                    Butter.LGUE.Choix();  /* Calling a function */
                    Environment.Exit(0);
                }
            }
        }
    }
}