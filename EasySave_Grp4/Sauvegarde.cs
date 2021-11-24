﻿using System;
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
        private States ST = new States();
        private Type_Save SV = new Type_Save();
        string ETAT;
        public void Create_Travail_Sauvegarde(int choice, int nbFichiersSD)
        {
            if (nbFichiersSD < 5)
            {
                while (choice > 5)
                {
                    Console.WriteLine("Vous avez depassé le seuil de travaux, veuillez réessayer ultérieurement");
                }
                for (int i = 1; i <= choice; i++)
                {
                    Console.Clear();
                    Console.WriteLine("Veuillez saisir le nom du travail");
                    string name = Console.ReadLine();

                    Console.WriteLine("Veuillez saisir le dossier source");
                    string source_name = Console.ReadLine();
                    try
                    {
                        var verifDest = Directory.GetFiles(source_name, "*", SearchOption.AllDirectories);
                    }
                    catch
                    {
                        Console.WriteLine("Dossier introuvable, veuillez réessayer");
                        Environment.Exit(0);
                    }
                    Console.WriteLine("Veuillez saisir le dossier destination");
                    string dest_name = Console.ReadLine();

                    Console.WriteLine("Veuillez saisir le type de sauvegarde : Complet / Differentiel");
                    string type_save = Console.ReadLine();

                    var jFile = new JFile
                    {
                        name = name,
                        source_name = source_name,
                        dest_name = dest_name,
                        type_save = type_save
                    };
                    /*
                    var toJSON = new List<JFile> {
                    new JFile{
                        backupName = "Save " + linesCount,
                        type = type,
                        sourcePath = sourcePath,
                        destinationPath = destinationPath,
                        }
                    };
                    */
                    string fileName = @"..\..\..\Config\Travaux_Sauvegarde\" + name + ".json";
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(jFile);
                    ETAT = "Inactif";
                    File.WriteAllText(fileName, jsonString);
                    ST.Creer_Fichier_Etat(name, source_name, dest_name, ETAT);

                    Console.Clear();
                    //Console.WriteLine(jsonString);
                }
                Console.WriteLine("Travail de sauvegarde enregistré avec succès !");
            }
            else
            {
                Console.WriteLine("Limite de nombres de travaux atteinte, veuillez libérer de l'espace");
                Environment.Exit(0);
            }

        }

        public void Execute_Travail_Sauvegarde()
        {
            Console.WriteLine("Choisissez le mode d'execution");
            Console.WriteLine("1. Unique                                2. Sequentielle");
            int EXE = Convert.ToInt32(Console.ReadLine());
            ETAT = "Actif";
            if (EXE == 1)
            {
                Console.Clear();
                Console.WriteLine("Veuillez saisir le nom du travail de sauvegarde");
                string nom_fichier = Console.ReadLine();
                string fileName = @"..\..\..\Config\Travaux_Sauvegarde\" + nom_fichier + ".json";
                string jsonString = File.ReadAllText(fileName);
                JFile jFile = System.Text.Json.JsonSerializer.Deserialize<JFile>(jsonString);


               //ST.Modifier_Fichier_Etat(jFile.name, jFile.source_name, jFile.dest_name, ETAT);
                if (jFile.type_save == "Complet")
                {
                    try
                    {
                        SV.CopyRepertoire(jFile.name,jFile.source_name, jFile.dest_name, ETAT);
                        //ST.Creer_Fichier_Etat(jFile.name, jFile.source_name, jFile.dest_name, ETAT);
                        File.Delete(fileName);
                        Console.Clear();
                        Console.WriteLine("Copie effectuée avec succès !");
                    }
                    catch
                    {
                        Console.WriteLine("Travail introuvable");
                    }
                } else if (jFile.type_save == "Differentiel")
                {
                    try
                    {
                        SV.CopyRepertoire_Modifier(jFile.name,jFile.source_name, jFile.dest_name, ETAT);
                        //ST.Creer_Fichier_Etat(jFile.name, jFile.source_name, jFile.dest_name, ETAT);
                        File.Delete(fileName);
                        Console.WriteLine("Copie effectuée avec succès !");
                    }
                    catch
                    {
                        Console.WriteLine("Travail introuvable");
                    }
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
                        SV.CopyRepertoire(jFile.name,jFile.source_name, jFile.dest_name, ETAT);
                        File.Delete(file);
                    } else if (jFile.type_save == "Differentiel")
                    {
                        SV.CopyRepertoire_Modifier(jFile.name,jFile.source_name, jFile.dest_name, ETAT);
                        File.Delete(file);
                        Console.Clear();
                    }
                }

                Console.WriteLine("Copie effectuée avec succès !");
            }

        }


    }
 
}
