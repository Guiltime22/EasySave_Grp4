using Newtonsoft.Json;
using System;
using System.IO;
using static test.Program;

namespace test
{
    public class JFile
    {
        public string name { get; set; }
        public string source_name { get; set; }
        public string dest_name { get; set; }
        public string type_save { get; set; }
    }
    public class Travail
    {
        string ETAT;
        public void Create_Travail_Sauvegarde(int choice, int nbFichiersSD) //function to create a work of saving
        {
            if (nbFichiersSD <= 5) // To check the slots of work
            {
                while (choice > 5) // To check that the input of works don't overload the folder of work
                {
                    Console.Clear();
                    Butter.LGUE.Seuil();  /* Calling a function */
                    Console.ReadKey();
                    return;
                }
                for (int i = 1; i <= choice; i++) // Create works depend on the choice of the user
                {
                    Console.Clear();
                    Butter.LGUE.Source();  /* Calling a function */
                    string source_name = Console.ReadLine(); // Input of the User
                    try
                    {
                        Directory.GetFiles(source_name, "*", SearchOption.AllDirectories); //Check if the folder exists
                    }
                    catch
                    {
                        Console.Clear();
                        Butter.LGUE.Dossier_introuvable();  /* Calling a function */
                        Console.ReadKey();
                        return;
                    }
                    Butter.LGUE.Destination();  /* Calling a function */
                    string dest_name = Console.ReadLine();

                    Butter.LGUE.Type_sauvegarde();  /* Calling a function */
                    string type_save = Console.ReadLine();

                    Butter.LGUE.Saisir();  /* Calling a function */
                    string name = Console.ReadLine();

                    var jFile = new JFile //Objects to insert into our JSON file
                    {
                        name = name,
                        source_name = source_name,
                        dest_name = dest_name,
                        type_save = type_save
                    };

                    string fileName = @"..\..\..\Config\Travaux_Sauvegarde\" + name + ".json"; // Name of the work 
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(jFile); // Convert the objects into string for JSON
                    ETAT = "Inactif";
                    File.WriteAllText(fileName, jsonString); // Create the work with the informations
                    Butter.ST.Creer_Fichier_Etat(name, source_name, dest_name, ETAT); //Function to create a state into the state file for the work
                    Console.Clear();
                }
                Butter.LGUE.Travail_enregistre();  /* Calling a function */
                Console.ReadKey();
                return;

            }
            else
            {
                Console.Clear();
                Butter.LGUE.Limite();  /* Calling a function */
                Console.ReadKey();
                return;
            }
        }

        public void Execute_Travail_Sauvegarde() //function to execute a work of saving
        {
            Butter.LGUE.Mode();  /* Calling a function */
            int EXE = Convert.ToInt32(Console.ReadLine()); // The Input of the User
            ETAT = "Actif";
            if (EXE == 1)
            {
                Console.Clear();
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
                Butter.LGUE.Nom_t();  /* Calling a function */
                try
                {
                    string nom_fichier = Console.ReadLine(); // Input of the User
                    string fileName = @"..\..\..\Config\Travaux_Sauvegarde\" + nom_fichier + ".json";
                    string jsonString = File.ReadAllText(fileName); //Open the file to read the work
                    JFile jFile = System.Text.Json.JsonSerializer.Deserialize<JFile>(jsonString); //Convert the content of the file into Objects
                    if (jFile.type_save == "Complet" || jFile.type_save == "Full")
                    {
                        Butter.SVU.CopyRepertoire(jFile.name, jFile.source_name, jFile.dest_name, ETAT); //Function to copy the files completly
                        File.Delete(fileName); //Delete the work after the execution
                        Console.Clear();
                        Butter.LGUE.Copie();  /* Calling a function */
                        Console.ReadKey();
                        return;

                    }
                    else if (jFile.type_save == "Differentiel" || jFile.type_save == " Differential")
                    {

                        Butter.SVS.CopyRepertoire_Modifier(jFile.name, jFile.source_name, jFile.dest_name, ETAT); //Function to copy the files differential
                        File.Delete(fileName);
                        Butter.LGUE.Copie();  /* Calling a function */
                        Console.ReadKey();
                        return;

                    }

                }
                catch
                {
                    Console.Clear();
                    Butter.LGUE.Travail_introuvable();  /* Calling a function */
                    Console.ReadKey();
                    return;
                }
            }
            if (EXE == 2)
            {
                Console.Clear();
                string[] files = Directory.GetFiles(@"..\..\..\Config\Travaux_Sauvegarde", "*.json"); //Table to put the different works
                foreach (var file in files) //For each work
                {
                    string jsonString = File.ReadAllText(file); //Open the file to read the work
                    JFile jFile = System.Text.Json.JsonSerializer.Deserialize<JFile>(jsonString);//Convert the content of the file into Objects
                    if (jFile.type_save == "Complet" || jFile.type_save == "Full")
                    {
                        Butter.SVU.CopyRepertoire(jFile.name, jFile.source_name, jFile.dest_name, ETAT); //Function to copy the files completly
                        File.Delete(file);
                    }
                    else if (jFile.type_save == "Differentiel" || jFile.type_save == " Differential")
                    {
                        Butter.SVS.CopyRepertoire_Modifier(jFile.name, jFile.source_name, jFile.dest_name, ETAT); //Function to copy the files Differential
                        File.Delete(file);
                        Console.Clear();
                    }
                }
                Butter.LGUE.Copie();  /* Calling a function */
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

    }
}