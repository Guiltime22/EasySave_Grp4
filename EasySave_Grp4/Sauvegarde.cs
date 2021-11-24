﻿using Newtonsoft.Json;
using System;
using System.IO;

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
            if (nbFichiersSD <= 5)
            {
                while (choice > 5)
                {
                    Console.Clear();
                    Langue seuil = new Langue();
                    seuil.Seuil();  /* appel  fonction */
                    Console.ReadKey();
                    return;
                }
                for (int i = 1; i <= choice; i++)
                {
                    Console.Clear();
                    Langue source = new Langue();
                    source.Source();  /* appel  fonction */
                    string source_name = Console.ReadLine();
                    try
                    {
                        var verifDest = Directory.GetFiles(source_name, "*", SearchOption.AllDirectories);
                    }
                    catch
                    {
                        Console.Clear();
                        Langue introuvable = new Langue();
                        introuvable.Dossier_introuvable();  /* appel  fonction */
                        Console.ReadKey();
                        return;
                    }
                    Langue destination = new Langue();
                    destination.Destination();  /* appel  fonction */
                    string dest_name = Console.ReadLine();



                    Langue type = new Langue();
                    type.Type_sauvegarde();  /* appel  fonction */
                    string type_save = Console.ReadLine();

                    Langue saisir = new Langue();
                    saisir.Saisir();  /* appel  fonction */
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
                    ETAT = "Inactif";
                    File.WriteAllText(fileName, jsonString);
                    ST.Creer_Fichier_Etat(name, source_name, dest_name, ETAT);
                    Console.Clear();
                    //Console.WriteLine(jsonString);
                }

                Langue enregistre = new Langue();
                enregistre.Travail_enregistre();  /* appel  fonction */
                Console.ReadKey();
                return;

            }
            else
            {
                Console.Clear();

                Langue limite = new Langue();
                limite.Limite();  /* appel  fonction */
                Console.ReadKey();
                return;
            }
            return;
        }

        public void Execute_Travail_Sauvegarde()
        {
            Langue execute = new Langue();
            execute.Mode();  /* appel  fonction */
            int EXE = Convert.ToInt32(Console.ReadLine());
            ETAT = "Actif";
            if (EXE == 1)
            {
                Console.Clear();
                Langue Nom = new Langue();
                Nom.Nom_t();  /* appel  fonction */
                try
                {
                    string nom_fichier = Console.ReadLine();
                    string fileName = @"..\..\..\Config\Travaux_Sauvegarde\" + nom_fichier + ".json";
                    string jsonString = File.ReadAllText(fileName);
                    JFile jFile = System.Text.Json.JsonSerializer.Deserialize<JFile>(jsonString);
                    if (jFile.type_save == "Complet" || jFile.type_save == "Full")
                    {
                        SV.CopyRepertoire(jFile.name, jFile.source_name, jFile.dest_name, ETAT);
                        File.Delete(fileName);
                        Console.Clear();
                        Langue copie = new Langue();
                        copie.Copie();  /* appel  fonction */
                        Console.ReadKey();
                        return;

                    }
                    else if (jFile.type_save == "Differentiel" || jFile.type_save == " Differential")
                    {

                        SV.CopyRepertoire_Modifier(jFile.name, jFile.source_name, jFile.dest_name, ETAT);
                        File.Delete(fileName);
                        Langue copie1 = new Langue();
                        copie1.Copie();  /* appel  fonction */
                        Console.ReadKey();
                        return;

                    }

                }
                catch
                {
                    Console.Clear();

                    Langue introuvable = new Langue();
                    introuvable.Travail_introuvable();  /* appel  fonction */
                    Console.ReadKey();
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
                    if (jFile.type_save == "Complet" || jFile.type_save == "Full")
                    {
                        SV.CopyRepertoire(jFile.name, jFile.source_name, jFile.dest_name, ETAT);
                        File.Delete(file);
                    }
                    else if (jFile.type_save == "Differentiel" || jFile.type_save == " Differential")
                    {
                        SV.CopyRepertoire_Modifier(jFile.name, jFile.source_name, jFile.dest_name, ETAT);
                        File.Delete(file);
                        Console.Clear();
                    }
                }
                Langue copie2 = new Langue();
                copie2.Copie();  /* appel  fonction */
                Console.ReadKey();
                return;
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
            Langue gest_tr = new Langue();
            gest_tr.Gest_Tr_sauvegarde();  /* appel  fonction */
            int Gest = Convert.ToInt32(Console.ReadLine());
            if (Gest == 1)
            {
                {
                    Console.Clear();
                    Langue afficher = new Langue();
                    afficher.Affichage(); /*Appel fonction */

                    Console.ReadKey();
                    Console.Clear();
                }

            }
            else if (Gest == 2)
            {
                Langue modifier = new Langue();
                modifier.Modifiernb();  /* appel  fonction */
                int choice = Convert.ToInt32(Console.ReadLine());
                for (int i = 1; i <= choice; i++)
                {
                    Console.Clear();

                    Langue modifiertr = new Langue();
                    modifiertr.ModifierTr();  /* appel  fonction */
                    string modif = Console.ReadLine();
                    string m = @"..\..\..\Config\Travaux_Sauvegarde\" + modif + ".json";
                    try
                    {
                        File.Delete(m);
                    }
                    catch
                    {
                        Console.Clear();
                        Langue introuvable1 = new Langue();
                        introuvable1.Travail_introuvable();  /* appel  fonction */
                        Console.ReadKey();
                        return;
                    }
                    Create_Travail_Sauvegarde(choice, nbFichiersSD);
                }
            }
            else if (Gest == 3)
            {
                Console.Clear();
                Langue supptr = new Langue();
                supptr.Supprimer();  /* appel  fonction */

                string suppp = Console.ReadLine();
                string f = @"..\..\..\Config\Travaux_Sauvegarde\" + suppp + ".json";
                File.Delete(f);
                Langue supprfin = new Langue();
                supprfin.Supprimer_Terminer();  /* appel  fonction */
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