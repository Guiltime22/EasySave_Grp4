using System;
using System.IO;
using Newtonsoft.Json;
using System.Text.Json;
using System.Collections.Generic;

namespace test
{
    public class JFile
    {
        public string name { get; set; }
        public string source_name { get; set; }
        public string dest_name { get; set; }
        public string type_save { get; set; }
    }
    public class Sauvegarde
    {

        private Type_Save SV = new Type_Save();
        public void Create_Travail_Sauvegarde(int choice, int nbFichiersSD)
        {
            if (nbFichiersSD <= 5)
            {
                while (choice > 5)
                {
                    Console.Clear();
                    Console.WriteLine("Vous avez depassé le seuil de travaux, veuillez réessayer ultérieurement");
                    return;
                }
                for (int i = 1; i <= choice; i++)
                {
                    Console.Clear();

                    Console.WriteLine("Veuillez saisir le dossier source");
                    string source_name = Console.ReadLine();
                    try
                    {
                        var verifDest = Directory.GetFiles(source_name, "*", SearchOption.AllDirectories);
                    }
                    catch
                    {
                        Console.Clear();
                        Console.WriteLine("Dossier introuvable, veuillez réessayer");
                        return;
                    }
                    Console.WriteLine("Veuillez saisir le dossier destination");
                    string dest_name = Console.ReadLine();

                    Console.WriteLine("Veuillez saisir le type de sauvegarde : Complet / Differentiel");
                    string type_save = Console.ReadLine();

                    Console.WriteLine("Veuillez saisir le nom du travail");
                    string name = Console.ReadLine();



                    var jFile = new JFile
                    {
                        name = name,
                        source_name = source_name,
                        dest_name = dest_name,
                        type_save = type_save
                    };

                    string fileName = @"..\..\..\Config\Travaux_Sauvegarde\" + name + ".json";
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(jFile);
                    File.WriteAllText(fileName, jsonString);
                    Console.Clear();
                    //Console.WriteLine(jsonString);
                }
                Console.WriteLine("Travail de sauvegarde enrengistré avec succès !");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Limite de nombres de travaux atteints, veuillez libérer de l'espace");
                return;
            }
            return;
        }

        public void Execute_Travail_Sauvegarde()
        {
            Console.WriteLine("Choisissez le mode d'execution");
            Console.WriteLine($"1. Unique                                2. Sequentielle {Environment.NewLine}" +
                              $"3. Exit");
            int EXE = Convert.ToInt32(Console.ReadLine());
            if (EXE == 1)
            {
                Console.Clear();
                Console.WriteLine("Veuillez saisir le nom du travail de sauvegarde");
                try
                {
                    string nom_fichier = Console.ReadLine();
                    string fileName = @"..\..\..\Config\Travaux_Sauvegarde\" + nom_fichier + ".json";
                    string jsonString = File.ReadAllText(fileName);
                    JFile jFile = System.Text.Json.JsonSerializer.Deserialize<JFile>(jsonString);
                    if (jFile.type_save == "Complet")
                    {

                        SV.CopyRepertoire(jFile.source_name, jFile.dest_name);
                        File.Delete(fileName);
                        Console.Clear();
                        Console.WriteLine("Copie effectué avec succès !");

                    }
                    else if (jFile.type_save == "Differentiel")
                    {

                        SV.CopyRepertoire_Modifier(jFile.source_name, jFile.dest_name);
                        File.Delete(fileName);
                        Console.WriteLine("Copie effectué avec succès !");

                    }

                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Travail introuvable, veuillez réessayer");
                    return;
                }
            }
            if (EXE == 2)
            {
                Console.Clear();
                string[] files = Directory.GetFiles(@"..\..\..\Config\Travaux_Sauvegarde", "*.json");
                foreach (var file in files)
                {
                    string jsonString = File.ReadAllText(file);
                    JFile jFile = System.Text.Json.JsonSerializer.Deserialize<JFile>(jsonString);
                    if (jFile.type_save == "Complet")
                    {
                        SV.CopyRepertoire(jFile.source_name, jFile.dest_name);
                        File.Delete(file);
                    }
                    else if (jFile.type_save == "Differentiel")
                    {
                        SV.CopyRepertoire_Modifier(jFile.source_name, jFile.dest_name);
                        File.Delete(file);
                        Console.Clear();
                    }
                }

                Console.WriteLine("Copie effectué avec succès !");
            }
            if (EXE == 3)
            {
                Console.Clear();
                return;
            }
            return;
        }
        public void Gestion_Travail_Sauvegarde(int nbFichiersSD)
        {
            Console.WriteLine("Faites votre choix !");
            Console.WriteLine($"1. Afficher                                2. Modifier {Environment.NewLine} {Environment.NewLine}" +
                               "3. Supprimer                               4. Exit");
            int Gest = Convert.ToInt32(Console.ReadLine());
            if (Gest == 1)
            {
                Console.Clear();
                string[] files = Directory.GetFiles(@"..\..\..\Config\Travaux_Sauvegarde", "*.json");
                Console.WriteLine("Vos Travaux : ");
                foreach (string file in files)
                {
                    JFile test = JsonConvert.DeserializeObject<JFile>(File.ReadAllText(file));
                    Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════════════════╗");
                    Console.WriteLine("Nom :" + test.name);
                    Console.WriteLine("Dossier Source :" + test.source_name );
                    Console.WriteLine("Dossier Destinataire :" + test.dest_name );
                    Console.WriteLine("Type de Sauvegarde :" + test.type_save);
                    Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════════════╝");
                }
                    Console.WriteLine("Appuyer sur une touche pour revenir au menu.");
                    Console.ReadKey();
                    Console.Clear();
            }
            else if (Gest == 2)
            {
                Console.WriteLine("Combien de travaux voulez-vous modifier ?");
                int choice = Convert.ToInt32(Console.ReadLine());
                for (int i = 1; i <= choice; i++)
                {
                    Console.Clear();
                    Console.WriteLine("Quel travail voulez-vous modifier ?");
                    string modif = Console.ReadLine();
                    string m = @"..\..\..\Config\Travaux_Sauvegarde\" + modif + ".json";
                    try
                    {
                        File.Delete(m);
                    }
                    catch
                    {
                        Console.WriteLine("Travail introuvable");
                        return;
                    }
                    Create_Travail_Sauvegarde(choice, nbFichiersSD);
                }
            }
            else if (Gest == 3)
            {
                Console.Clear();
                Console.WriteLine("Veuillez saisir le nom du travail à supprimer");
                string supp = Console.ReadLine();
                string f = @"..\..\..\Config\Travaux_Sauvegarde\" + supp + ".json";
                try
                {
                    File.Delete(f);
                    Console.Clear();
                    Console.WriteLine("Suppression Terminée");

                }
                catch
                {
                    Console.WriteLine("Travail introuvable");
                    return;
                }

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
