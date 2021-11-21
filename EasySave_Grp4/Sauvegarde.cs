﻿using System;
using System.IO;
//using Newtonsoft.Json;
using System.Text.Json;

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

                    string fileName = @"C:\Users\ghile\Desktop\POO\JSON\" + name + ".json";
                    string jsonString = JsonSerializer.Serialize(jFile);
                    File.WriteAllText(fileName, jsonString);


                    Console.Clear();
                    //Console.WriteLine(jsonString);
                }
                Console.WriteLine("Travail de sauvegarde enrengistré avec succès !");
            }
            else
            {
                Console.WriteLine("Limite de nombres de travaux atteints, veuillez libérer de l'espace");
                Environment.Exit(0);
            }
            
        }
        
        public void Execute_Travail_Sauvegarde()
        {
            Console.WriteLine("Choisissez le mode d'execution");
            Console.WriteLine("1. Unique                                2. Sequentielle");
            int EXE = Convert.ToInt32(Console.ReadLine());
            if(EXE == 1)
            {
                Console.Clear();
                Console.WriteLine("Veuillez saisir le nom du travail de sauvegarde");
                string nom_fichier = Console.ReadLine();
                string fileName = @"C:\Users\ghile\Desktop\POO\JSON\"+nom_fichier+".json";
                string jsonString = File.ReadAllText(fileName);
                JFile jFile = JsonSerializer.Deserialize<JFile>(jsonString);
                if(jFile.type_save == "Complet")
                {
                try
                {
                    SV.CopyRepertoire(jFile.source_name, jFile.dest_name);
                    File.Delete(fileName);
                    Console.Clear();
                    Console.WriteLine("Copie effectué avec succès !");
                }
                catch
                {
                    Console.WriteLine("Travail introuvable");
                }
                }else if(jFile.type_save == "Differentiel")
                {
                    try
                    {
                        SV.CopyRepertoire_Modifier(jFile.source_name, jFile.dest_name);
                        File.Delete(fileName);
                        Console.WriteLine("Copie effectué avec succès !");
                    }
                    catch
                    {
                        Console.WriteLine("Travail introuvable");
                    }
                }
            }
            if(EXE == 2)
            {
                Console.Clear();
                string[] files = Directory.GetFiles(@"C:\Users\ghile\Desktop\POO\JSON", "*.json");
                foreach (var file in files)
                {
                    string jsonString = File.ReadAllText(file);
                    JFile jFile = JsonSerializer.Deserialize<JFile>(jsonString);
                    if (jFile.type_save == "Complet")
                    {
                        SV.CopyRepertoire(jFile.source_name, jFile.dest_name);
                        File.Delete(file);
                    }else if(jFile.type_save == "Differentiel")
                    {
                        SV.CopyRepertoire_Modifier(jFile.source_name, jFile.dest_name);
                        File.Delete(file);
                        Console.Clear();
                    }
                }
                
                Console.WriteLine("Copie effectué avec succès !");
            }
            
        }

    }
}
