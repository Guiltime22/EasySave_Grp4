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
    public class State_List
    {
        public static string fileName = @"..\..\..\Config\Etats.json";
        public string Name { get; set; }
        public string source_name { get; set; }
        public string dest_name { get; set; }
        public string Progression { get; set; }

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

        public List<JFile> Afficher_le_travail()
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

        public List<State_List> Afficher_Progress()
        {
            List<State_List> State_List = new List<State_List>();
            string[] files = Directory.GetFiles(@"..\..\..\Config\Travaux_Sauvegarde", "*.json");
            foreach (string file in files)
            {

                State_List tesT = JsonConvert.DeserializeObject<State_List>(File.ReadAllText(file));
                var taille_fichier_source = tesT.source_name.Length;
                var taille_fichier_dest = tesT.dest_name.Length;
                var Action_Progress = (taille_fichier_dest * 100) / taille_fichier_source;
                State_List.Add(new State_List() //parameter that the JSON file will contains
                {
                    Name = tesT.Name,
                    Progression = Convert.ToString(Action_Progress)
                    // List<string> progressList = new List<string>();
                    //progressList.Add(tesT.name);
                    //progressList.Add(Convert.ToString(Action_Progress));
                });

            }
            return State_List;
        }
    }

    }
