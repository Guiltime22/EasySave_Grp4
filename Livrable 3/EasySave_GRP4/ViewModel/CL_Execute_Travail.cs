using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
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
        public string SourceFilePath { get; set; }
        public string TargetFilePath { get; set; }
        public string State { get; set; }
        public string TotalFilesToCopy { get; set; }
        public string TotalFilesSize { get; set; }
        public string NbFilesLeftToDo { get; set; }
        public string Progression { get; set; }
        public string Time { get; set; }


    }
    class CL_Execute_Travail
    {
        private static Mutex mutex = new Mutex();
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

       /* public List<State_List> Afficher_Progress()
        {
            State_List ST = new State_List();
            List<State_List> State_Liste = new List<State_List>();

           var jsonDataWork = File.ReadAllText(State_List.fileName); //Read the JSON file
            
            var workList = JsonConvert.DeserializeObject<List<State_List>>(jsonDataWork) ?? new List<State_List>(); //convert a string into an object for JSON
            foreach (string file in files)
            {

                State_List tesT = JsonConvert.DeserializeObject<State_List>(File.ReadAllText(file));
                var taille_fichier_source = tesT.SourceFilePath.Length;
                var taille_fichier_dest = tesT.TargetFilePath.Length;
                var Action_Progress = (taille_fichier_dest / taille_fichier_source) * 100;

                long Taille = 0;
                int TotalFichiersACopier = Directory.GetFiles(source, "*.*", SearchOption.AllDirectories).Length;
                int TotalFichiersDestination = Directory.GetFiles(destination, "*.*", SearchOption.AllDirectories).Length;
                int TotalFichiersRestants = TotalFichiersACopier - TotalFichiersDestination; //To calculate the remaining files

                State_Liste.Add(new State_List() //parameter that the JSON file will contains
                {
                    Name = tesT.Name,
                    SourceFilePath = tesT.SourceFilePath,
                    TargetFilePath = tesT.TargetFilePath,
                    TotalFilesToCopy = Convert.ToString(TotalFichiersACopier),
                    TotalFilesSize = Convert.ToString(Taille),
                    Progression = Convert.ToString(Action_Progress) + "%"


                    // List<string> progressList = new List<string>();
                    //progressList.Add(tesT.name);
                    //progressList.Add(Convert.ToString(Action_Progress));
                });

            }
            return State_Liste;
        }*/
        public List<State_List> Afficher_Data()//Show the information of state file
        {
            mutex.WaitOne();
            var Fichier_Json = File.ReadAllText(State_List.fileName); //Read the JSON file
            var Etat_Travail = JsonConvert.DeserializeObject<List<State_List>>(Fichier_Json) ?? new List<State_List>(); //convert a string into an object for JSON
            mutex.ReleaseMutex();
            return Etat_Travail;

        }
        public void Play_Travail()
        {
            VM_Factory.ET.Play();
        }
        public void Pause_Travail()
        {
            VM_Factory.ET.Pause();
        }
        public void Stop_Travail()
        {
            VM_Factory.ET.Stop();
        }
    }

    }
