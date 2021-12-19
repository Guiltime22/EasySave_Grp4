using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;

namespace EasySave_GRP4.Model
{
    class Parametres
    {
        public void Parametres_Generaux(string Langue, string Cryptage, string Metier, string Prioritaire, string Taille)
        {

            var jFile_parametres = new Model_Factory.JFile_parametres //Objects to insert into our JSON file
            {
                Langue = Langue,
                Cryptage = Cryptage,
                Metier = Metier,
                Prioritaire = Prioritaire,
                Taille = Taille
            };

            string fileName = @"..\..\..\Config\Parametres.json"; // Name of the work 
            string jsonString = System.Text.Json.JsonSerializer.Serialize(jFile_parametres); // Convert the objects into string for JSON
            File.WriteAllText(fileName, jsonString); // Create the work with the informations

            if (jFile_parametres.Langue == "French")
            {
            MessageBox.Show("Parametres enrengistré,Veuillez relancer l'application");
                Environment.Exit(1);
            }
            else if (jFile_parametres.Langue == "English")
            {
                MessageBox.Show("Parameters saved, Relaunch the app");
                Environment.Exit(1);
            }

        }
    }
}
