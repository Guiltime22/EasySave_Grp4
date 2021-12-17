using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;

namespace EasySave_Grp4.ModelView
{
    public class JFile
    {
        public string name { get; set; }
        public string source_name { get; set; }
        public string dest_name { get; set; }
        public string type_save { get; set; }
    }

    class CL_Execute_Travail
    {
        public CL_Execute_Travail(){

        }
        public List<JFile> Afficher_Travail()
        {
            List<JFile> LT = new List<JFile>();
            string[] files = Directory.GetFiles(@"..\..\..\Config\Travaux_Sauvegarde", "*.json");
            foreach (string file in files)
            {
              JFile test = JsonConvert.DeserializeObject<JFile>(File.ReadAllText(file));
              
              LT.Add(new JFile() //parameter that the JSON file will contains
                {
                    name = test.name,
                    source_name = test.source_name,
                    dest_name = test.dest_name,
                    type_save = test.type_save
                });
            
            }
            return LT;
        }
        public void Executer_Travail_Unique(string nom_fichier)
        {
            VM_Factory.ET.Execute_Unique(nom_fichier);
        }
        public void Executer_Travail_Seq()
        {
            VM_Factory.ET.Execute_Seq();
        }
    }
}
