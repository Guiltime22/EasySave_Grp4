using Newtonsoft.Json;
using System;
using System.IO;
//using Newtonsoft.Json;
using static test.Program;

namespace test
{
    class Langue
    {






        public void Welcome()
        {
            string path = @"..\..\..\Config\Travaux_Sauvegarde\";


            int nbFichiersSD = Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly).Length;




            if (Butter.v == 1)
            {
                Console.WriteLine($"Welcome to  EasySave => You have  " + nbFichiersSD + $"/5 Safeguard slots. {Environment.NewLine}");


                Console.WriteLine($"1. Create Backup work             2. Execution Backup work {Environment.NewLine} {Environment.NewLine}" +
                                  $"3. Managing backup works            4. Exit {Environment.NewLine}");

                Console.WriteLine("Your entry :");
            }
            else if (Butter.v == 2)
            {

                Console.WriteLine($"Bienvenue dans l'interface EasySave => vous avez " + nbFichiersSD + $"/5 slots de sauvegardes. {Environment.NewLine}");
                Console.WriteLine($"1. Création Travail de sauvegarde                  2. Execution Travail de sauvegarde {Environment.NewLine} {Environment.NewLine}" +
                                  $"3. Gestion des travaux de sauvegarde               4. Sortir {Environment.NewLine}");

                Console.WriteLine("Votre saisie:");
            }
            else
            {
                Console.WriteLine("Valeur incorrect");
                Environment.Exit(0);

            }

        }




        public void Traveaux()
        {
            if (Butter.v == 1)
            {
                Console.WriteLine("How many works do you want to do? ");
            }
            else if (Butter.v == 2)
            {
                Console.WriteLine("Combien de travaux voulez-vous réaliser ?");

            }
        }

        public void nbslots()
        {
            if (Butter.v == 1)
            {
                Console.WriteLine("Insufficient number of slots, please try again ");
            }
            else if (Butter.v == 2)
            {
                Console.WriteLine("Nombre de slots insuffisant, veuillez réessayer ");

            }


        }

        public void Choix()
        {
            if (Butter.v == 1)
            {
                Console.WriteLine("Incorrect choice, closing the console ");
            }
            else if (Butter.v == 2)
            {
                Console.WriteLine("Choix incorrecte, fermeture de la console ");

            }


        }

        public void Mode()
        {
            if (Butter.v == 1)

            {
                Console.WriteLine("Choose the execution mode");

                Console.WriteLine($"1. Unique                                2. Sequential {Environment.NewLine}" +
                  $"3. Exit");
            }
            else if (Butter.v == 2)

            {
                Console.WriteLine("Choisissez le mode d'execution");
                Console.WriteLine($"1. Unique                                2. Sequentielle {Environment.NewLine}" +
                                  $"3. Sortir");

            }
        }

        public void Nom_t()
        {
            if (Butter.v == 1)

            {
                Console.WriteLine("Please enter the name of the backup work");
            }
            else if (Butter.v == 2)

            {
                Console.WriteLine("Veuillez saisir le nom du travail de sauvegarde");

            }
        }

        public void Seuil()
        {
            if (Butter.v == 1)

            {
                Console.WriteLine("You have exceeded the work threshold, please try again ");

            }
            else if (Butter.v == 2)

            {
                Console.WriteLine("Vous avez depassé le seuil de travaux, veuillez réessayer ultérieurement");


            }
        }

        public void Saisir()
        {
            if (Butter.v == 1)

            {
                Console.WriteLine("Please enter the works name");



            }
            else if (Butter.v == 2)

            {
                Console.WriteLine("Veuillez saisir le nom du travail");




            }
        }


        public void Source()
        {
            if (Butter.v == 1)

            {
                Console.WriteLine("Please enter the source folder");


            }
            else if (Butter.v == 2)

            {

                Console.WriteLine("Veuillez saisir le dossier source");

            }
        }


        public void Dossier_introuvable()
        {
            if (Butter.v == 1)

            {
                Console.WriteLine("Folder not found, please try again");


            }

            else if (Butter.v == 2)

            {

                Console.WriteLine("Dossier introuvable, veuillez réessayer");

            }
;
        }



        public void Destination()
        {
            if (Butter.v == 1)

            {
                Console.WriteLine("Please enter the destination folder");

            }
            else if (Butter.v == 2)

            {

                Console.WriteLine("Veuillez saisir le dossier destination");

            }
        }

        public void Type_sauvegarde()
        {
            if (Butter.v == 1)

            {
                Console.WriteLine("Please enter the type of backup: Full / Differential");

            }
            else if (Butter.v == 2)

            {
                Console.WriteLine("Veuillez saisir le type de sauvegarde : Complet / Differentiel");

            }
        }

        public void Travail_enregistre()
        {
            if (Butter.v == 1)

            {
                Console.WriteLine("Backup job saved successfully!");

            }
            else if (Butter.v == 2)

            {
                Console.WriteLine("Travail de sauvegarde enrengistré avec succès !");

            }
        }

        public void Limite()
        {
            if (Butter.v == 1)

            {
                Console.WriteLine("Limit of number of jobs reached, please free some space");


            }
            else if (Butter.v == 2)

            {
                Console.WriteLine("Limite de nombres de travaux atteints, veuillez libérer de l'espace");

            }
        }

        public void Copie()
        {
            if (Butter.v == 1)

            {
                Console.WriteLine("Copy successfully completed!");

            }
            else if (Butter.v == 2)

            {
                Console.WriteLine("Copie effectué avec succès !");

            }
        }


        public void Travail_introuvable()
        {
            if (Butter.v == 1)

            {
                Console.WriteLine("work not found ");


            }
            else if (Butter.v == 2)

            {
                Console.WriteLine("Travail introuvable");


            }

        }



        public void Complet()


        {

            if (Butter.v == 1)

            {
                Console.WriteLine("full");
            }
            else if (Butter.v == 2)

            {
                Console.WriteLine("Complet");

            }
        }

        public void Gest_Tr_sauvegarde()


        {

            if (Butter.v == 1)

            {
                Console.WriteLine("Make a choice  !");
                Console.WriteLine($"1. Display                               2. Modify {Environment.NewLine} {Environment.NewLine}" +
                                   "3. Remove                              4. Exit");
            }
            else if (Butter.v == 2)

            {
                Console.WriteLine("Faites votre choix !");
                Console.WriteLine($"1. Afficher                                2. Modifier {Environment.NewLine} {Environment.NewLine}" +
                                   "3. Supprimer                               4. Sortir");

            }
        }


        public void Modifiernb()


        {

            if (Butter.v == 1)

            {
                Console.WriteLine("How many works do you want to modify ? ");
            }
            else if (Butter.v == 2)

            {
                Console.WriteLine("Combien de travaux voulez-vous modifier ?");

            }
        }

        public void ModifierTr()


        {

            if (Butter.v == 1)

            {
                Console.WriteLine("Which work do you want to modify ? ");
            }
            else if (Butter.v == 2)

            {
                Console.WriteLine("Quel travail voulez-vous modifier ?");

            }
        }


        public void Supprimer()


        {

            if (Butter.v == 1)

            {
                Console.WriteLine("Please enter the name of the work to be deleted ");
            }
            else if (Butter.v == 2)

            {
                Console.WriteLine("Veuillez saisir le nom du travail à supprimer ");

            }
        }

        public void Supprimer_Terminer()


        {

            if (Butter.v == 1)

            {
                Console.WriteLine("Deletion Completed");

            }
            else if (Butter.v == 2)

            {
                Console.WriteLine("Suppression Terminée ");



            }
        }




        public void Affichage()


        {

            if (Butter.v == 1)

            {
                string[] files = Directory.GetFiles(@"..\..\..\Config\Travaux_Sauvegarde", "*.json");
                Console.WriteLine("Your works: ");
                foreach (string file in files)
                {
                    JFile test = JsonConvert.DeserializeObject<JFile>(File.ReadAllText(file));
                    Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════════════════╗");
                    Console.WriteLine("Name :" + test.name);
                    Console.WriteLine("Source folder :" + test.source_name);
                    Console.WriteLine("Recipient file :" + test.dest_name);
                    Console.WriteLine("type of backup:" + test.type_save);
                    Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════════════╝");
                }
                Console.WriteLine("Press a key to return to the menu.");
            }
            else if (Butter.v == 2)

            {
                string[] files = Directory.GetFiles(@"..\..\..\Config\Travaux_Sauvegarde", "*.json");
                Console.WriteLine("Vos Travaux : ");
                foreach (string file in files)
                {
                    JFile test = JsonConvert.DeserializeObject<JFile>(File.ReadAllText(file));
                    Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════════════════╗");
                    Console.WriteLine("Nom :" + test.name);
                    Console.WriteLine("Dossier Source :" + test.source_name);
                    Console.WriteLine("Dossier Destinataire :" + test.dest_name);
                    Console.WriteLine("Type de Sauvegarde :" + test.type_save);
                    Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════════════╝");
                }
                Console.WriteLine("Appuyer sur une touche pour revenir au menu.");
            }



        }
        }





    }




