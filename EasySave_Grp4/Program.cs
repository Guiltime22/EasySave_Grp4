using System;
using System.IO;
//using Newtonsoft.Json;

namespace test
{
    class Program
    {
        static string path = @"..\..\..\Config\Travaux_Sauvegarde\";

        public class Butter
        {
            public static int v;
        }


        static void Main(string[] args)
        {
            Console.Clear();

            Console.WriteLine("Choisisez la langue.");
            Console.WriteLine("1.Anglais                 2.Francais");
            Butter.v = Convert.ToInt32(Console.ReadLine());



            while (true)
            {

                Console.Clear();

                int nbFichiersSD = Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly).Length;

                Sauvegarde SV = new Sauvegarde();



                Langue lan = new Langue();
                lan.Welcome(); /* appel  fonction */


                int Input = Convert.ToInt32(Console.ReadLine());

                if (Input == 1)
                {
                    Console.Clear();


                    Langue tra = new Langue();
                    tra.Traveaux();  /* appel  fonction */

                    int choice = Convert.ToInt32(Console.ReadLine());
                    if (choice + nbFichiersSD <= 5)
                    {
                        SV.Create_Travail_Sauvegarde(choice, nbFichiersSD);
                    }
                    else
                    {
                        Langue slot = new Langue();
                        slot.nbslots();  /* appel  fonction */
                        Environment.Exit(0);
                    }

                }
                else if (Input == 2)
                {
                    Console.Clear();
                    SV.Execute_Travail_Sauvegarde();
                }
                else if (Input == 3)
                {
                    Console.Clear();
                    SV.Gestion_Travail_Sauvegarde(nbFichiersSD);
                }
                else if (Input == 4)
                {
                    Console.Clear();
                    Console.WriteLine("BYE BYE");
                    Environment.Exit(0);
                }
                else
                {
                    Langue choix = new Langue();
                    choix.Choix();  /* appel  fonction */
                    Environment.Exit(0);
                }
            }
        }
    }
}