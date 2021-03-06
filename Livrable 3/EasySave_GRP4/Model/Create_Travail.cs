using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows;
using static EasySave_GRP4.Model.Model_Factory;

namespace EasySave_GRP4.Model
{
    public class JFile
    {
        public string name { get; set; }
        public string source_name { get; set; }
        public string dest_name { get; set; }
        public string type_save { get; set; }
    }
    public class Create_Travail
    {
        string ETAT;
        public void Create_Travail_Sauvegarde(string name, string source_name, string dest_name, string type_save) //function to create a work of saving
        {
                    try
                    {
                        Directory.GetFiles(source_name, "*", SearchOption.AllDirectories); //Check if the folder exists
                    }
                    catch
                    {

                StreamReader rlang = new StreamReader(@"..\..\..\Config\Parametres.json");
                string jsonlang = rlang.ReadToEnd();
                JFile_parametres Jlang = JsonConvert.DeserializeObject<JFile_parametres>(jsonlang);
                if (Jlang.Langue == "French")
                {
                    MessageBox.Show("Dossier Introuvable");
                }
                else if (Jlang.Langue == "English")
                {
                    MessageBox.Show("Directory not found");
                }
                    }

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
                    Butter.ST.Creer_Fichier_Etatx(name, source_name, dest_name, ETAT); //Function to create a state into the state file for the work

            StreamReader rlang2 = new StreamReader(@"..\..\..\Config\Parametres.json");
            string jsonlang2 = rlang2.ReadToEnd();
            JFile_parametres Jlang2 = JsonConvert.DeserializeObject<JFile_parametres>(jsonlang2);
            if (Jlang2.Langue == "French")
            {
            MessageBox.Show("Creation de Travail réussie");
            }
            else if (Jlang2.Langue == "English")
            {
                MessageBox.Show("Save job Created succesfully");
            }
        }


    }
}