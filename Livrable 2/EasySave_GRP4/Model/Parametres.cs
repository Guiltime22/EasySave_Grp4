using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;

namespace EasySave_GRP4.Model
{
    public class JFile_parametres
    {
        public string Langue { get; set; }
        public string Cryptage { get; set; }
       
    }
    class Parametres
    {
        public void Parametres_Generaux(string Langue, string Cryptage)
        {

            var jFile_parametres = new JFile_parametres //Objects to insert into our JSON file
            {
                Langue = Langue,
                Cryptage = Cryptage
            };

            string fileName = @"..\..\..\Config\Parametres.json"; // Name of the work 
            string jsonString = System.Text.Json.JsonSerializer.Serialize(jFile_parametres); // Convert the objects into string for JSON
            File.WriteAllText(fileName, jsonString); // Create the work with the informations
            MessageBox.Show("Parametres enrengistre");

        }
    }
}
