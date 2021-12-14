using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using static EasySave_GRP4.Model.Model_Factory;

namespace EasySave_GRP4.Model
{
    class Gestion_Travail
    {
        Create_Travail TV = new Create_Travail();
        public void Gestion_Travail_Sauvegarde(int nbFichiersSD) //function to manage a work of saving
        {
            Butter.LGUE.Gest_Tr_sauvegarde();  /* Calling a function */
            int Gest = Convert.ToInt32(Console.ReadLine()); //Input of the User
            if (Gest == 1)
            {
                {
                    Console.Clear();
                    Butter.LGUE.Affichage(); /* Calling a function */

                    Console.ReadKey();
                    Console.Clear();
                }

            }
            else if (Gest == 2)
            {
                Console.Clear();
                Butter.LGUE.Modifiernb();  /* Calling a function */
                int choice = Convert.ToInt32(Console.ReadLine()); //Input of the User
                for (int i = 1; i <= choice; i++)
                {
                    Console.Clear();
                    Butter.LGUE.ModifierTr();  /* Calling a function */
                    string modif = Console.ReadLine(); //Input of the User
                    string m = @"..\..\..\Config\Travaux_Sauvegarde\" + modif + ".json";
                    try
                    {
                        File.Delete(m);
                    }
                    catch
                    {
                        Console.Clear();
                        Butter.LGUE.Travail_introuvable();  /* Calling a function */
                        Console.ReadKey();
                        return;
                    }
                   //TV.Create_Travail_Sauvegarde();
                }
            }
            else if (Gest == 3)
            {
                Console.Clear();
                Butter.LGUE.Supprimer();  /* Calling a function */

                string suppp = Console.ReadLine(); //Input of the User
                string f = @"..\..\..\Config\Travaux_Sauvegarde\" + suppp + ".json";
                File.Delete(f);
                Butter.LGUE.Supprimer_Terminer();  /* Calling a function */
                Console.ReadKey();
                return;

            }
            else if (Gest == 4)
            {
                Console.Clear();
                return;
            }
            return;
        }

    }
}